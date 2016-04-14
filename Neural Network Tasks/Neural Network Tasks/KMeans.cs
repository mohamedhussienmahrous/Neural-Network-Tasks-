using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Neural_Network_Tasks
{
    class KMeans
    {

        public Matrix<float> TrainingData = Matrix<float>.Build.Dense(90, 5);
        public Matrix<float> centroid;
        public Matrix<float> remainData;
        EculdianDistance ecludian = new EculdianDistance();
  
        static Random random = new Random();

        public static List<int> GenerateRandom(int count)
        {
            // generate count random values.
            HashSet<int> candidates = new HashSet<int>();
            while (candidates.Count < count)
            {
                // May strike a duplicate.
                candidates.Add(random.Next(0,89));
            }

            // load them in to a list.
            List<int> result = new List<int>();
            result.AddRange(candidates);

            // shuffle the results:
            int i = result.Count;
            while (i > 1)
            {
                i--;
                int k = random.Next(i + 1);
                int value = result[k];
                result[k] = result[i];
                result[i] = value;
            }
            return result;
        }
        public  Vector<float>  Kmeans(int NumofClusters, List<Matrix<float>> Data,int epoch,float Lrate,float mse_thresh)
        {
            List<int>g=GenerateRandom(NumofClusters);
            centroid = Matrix<float>.Build.Dense(NumofClusters, 4);
            remainData = Matrix<float>.Build.Dense(90 - NumofClusters, 4);
            TrainingData = Data[0];
            int j=0;
            int v=0;
            for (int i = 0; i < 90; i++)
            {
               
                    if (g.Contains(i))
                    {
                        centroid.SetRow(j, TrainingData.Row(i).SubVector(0, 4));
                        j++;
                    }
                    else
                    {
                        remainData.SetRow(v, TrainingData.Row(i).SubVector(0, 4));
                        v++;
                    }
                  
            }
               
            Vector<float> accuracy= ecludian.Init_Eculidian_Distance(NumofClusters, centroid, remainData, TrainingData,Data[1], epoch, Lrate, mse_thresh);
            return accuracy;
        }
      
     
    }
}
