using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
namespace Neural_Network_Tasks
{
    class EculdianDistance
    {
        int index;
        Vector<float> ED;
        Vector<float> r;
        
        Vector<float> Sigma_;
        LMS lms = new LMS();
        Vector<float> Lablcluster;
        Vector<float> Oldlabel = Vector<float>.Build.Dense(90);
        
       
        public  Vector<float>  Init_Eculidian_Distance(int NumofClusters, Matrix<float> centroid,
                                            Matrix<float> remainData, Matrix<float> TrainingData,Matrix<float> TestingData,
                                            int epoch, float Lrate, float mse_thresh)
        {
            
            int NumofData = 90 - NumofClusters;
            Lablcluster = Vector<float>.Build.Dense(NumofData);
            
            
            ED = Vector<float>.Build.Dense(NumofClusters);
            
           
            for (int i = 0; i < NumofData; i++)
            {
                
                for (int j = 0; j < NumofClusters; j++)
                {
                    ED[j] = (float)Math.Sqrt(Math.Pow(remainData[i, 0] - centroid[j, 0], 2) +
                                             Math.Pow(remainData[i, 1] - centroid[j, 1], 2) +
                                             Math.Pow(remainData[i, 2] - centroid[j, 2], 2) +
                                             Math.Pow(remainData[i, 3] - centroid[j, 3], 2));

                }
                index = ED.MinimumIndex();
                Lablcluster[i] = index;
             
            }
            
            for (int j = 0; j < NumofData; j++)
            {
                Oldlabel[j] = Lablcluster[j];

            }
             Vector<float> accuracy=New_Centroids(Lablcluster, NumofClusters, centroid, TrainingData, TestingData, epoch, Lrate, mse_thresh);
             return accuracy;

        }
        public  Vector<float>  Eculidian_Distance(int NumofClusters, Matrix<float> centroid,
                                        Matrix<float> TrainingData,
                                       Matrix<float>TestingData,
                                       int epoch, float Lrate,
                                       float mse_thresh)
        {
            Vector<float> accuracy = Vector<float>.Build.Dense(9); ;
            
            ED = Vector<float>.Build.Dense(NumofClusters);
            
            Lablcluster = Vector<float>.Build.Dense(90);
            for (int i = 0; i < 90; i++)
            {
                for (int j = 0; j < NumofClusters; j++)
                {
                    ED[j] = (float)Math.Sqrt(Math.Pow(TrainingData[i, 0] - centroid[j, 0], 2) +
                                             Math.Pow(TrainingData[i, 1] - centroid[j, 1], 2) +
                                             Math.Pow(TrainingData[i, 2] - centroid[j, 2], 2) +
                                             Math.Pow(TrainingData[i, 3] - centroid[j, 3], 2));

                }
                
                    index = ED.MinimumIndex();
                    Lablcluster[i] = index;
               

            }
        
            int count = 0;

            if (Oldlabel.Count == Lablcluster.Count)
            {
                for (int i = 0; i < Lablcluster.Count; i++)
                {

                    if (Lablcluster[i] == Oldlabel[i])
                    {
                        count++;
                    }
                    else
                    {

                        break;
                    }


                }
            }
            if (count == Lablcluster.Count)
            {
                 accuracy=Sigma(centroid, NumofClusters, TrainingData, Lablcluster, TestingData, epoch, Lrate, mse_thresh);
                 return accuracy;

            }
            for (int j = 0; j < 90; j++)
            {
                Oldlabel[j] = Lablcluster[j];

            }
            accuracy= New_Centroids(Lablcluster, NumofClusters, centroid, TrainingData
                                      ,TestingData, epoch, Lrate, mse_thresh);
            return accuracy;

        }
        public  Vector<float>  New_Centroids(Vector<float>lablcluster,
                                  int NumofClusters, Matrix<float> centroid,
                                  Matrix<float> TrainingData,Matrix<float>TestingData,
                                  int epoch, float Lrate, float mse_thresh)
        {
            for (int i = 0; i < NumofClusters; i++)
            {
                float[] sum = new float[4];
                int counter = 1;
                for (int j=0;j<lablcluster.Count;j++)
                {

                    if (lablcluster[j] == i)
                    {
                        
                            sum[0] += TrainingData[j,0];
                            sum[1] += TrainingData[j,1];
                            sum[2] += TrainingData[j,2];
                            sum[3] += TrainingData[j,3];
                            
                        
                        counter ++;
                    }
                }
                sum[0] = (sum[0] + centroid[i, 0]) / counter;
                sum[1] = (sum[1] + centroid[i, 1]) / counter;
                sum[2] = (sum[2] + centroid[i, 2]) / counter;
                sum[3] = (sum[3] + centroid[i, 3]) / counter;
                centroid[i, 0] = sum[0];
                centroid[i, 1] = sum[1];
                centroid[i, 2] = sum[2];
                centroid[i, 3] = sum[3];

            }
          
               
             Vector<float> accuracy=Eculidian_Distance(NumofClusters, centroid, TrainingData,TestingData, epoch, Lrate, mse_thresh);
             return accuracy;
        }
        public Vector<float> Sigma(Matrix<float> centroid, int NumofClusters, Matrix<float> TrainingData,
                              Vector<float> lablecluster,Matrix<float>TestingData,
                              int epoch, float Lrate, float mse_thresh)
        {
           
            r = Vector<float>.Build.Dense(NumofClusters);
            Sigma_ = Vector<float>.Build.Dense(NumofClusters);
            
            for (int i = 0; i < NumofClusters; i++)
            {
                float counter = 0;
                for (int j = 0; j < Lablcluster.Count; j++)
                {

                    if (Lablcluster[j] == i)
                    {

                        r[i] += (float)Math.Sqrt(Math.Pow(TrainingData[j, 0] - centroid[i, 0], 2) +
                                              Math.Pow(TrainingData[j, 1] - centroid[i, 1], 2) +
                                              Math.Pow(TrainingData[j, 2] - centroid[i, 2], 2) +
                                              Math.Pow(TrainingData[j, 3] - centroid[i, 3], 2));


                        counter++;
                    }
                   
                }
                if (counter != 0)
                {
                    Sigma_[i] = (r[i]) / counter;
                }
                else
                    Sigma_[i] = 0;
            }
           
            Vector<float>accuracy=lms.StartTraining(Sigma_, NumofClusters, centroid,TestingData,TrainingData, epoch, Lrate, mse_thresh);
            return accuracy;
        }

    }
}
