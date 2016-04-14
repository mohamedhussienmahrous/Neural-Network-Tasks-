using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
namespace Neural_Network_Tasks
{
    class LMS
    {



        
        public Vector<float> error1 = Vector<float>.Build.Dense(90);
        public Vector<float> error2 = Vector<float>.Build.Dense(90);
        public Vector<float> error3 = Vector<float>.Build.Dense(90);


        public Vector<float> Guassian(Matrix<float> centroid, int NumofClusters,
                              Vector<float> sample, Vector<float> sigma)
        {
            Vector<float> r = Vector<float>.Build.Dense(NumofClusters);
            Vector<float> Phi = Vector<float>.Build.Dense(NumofClusters + 1);

            for (int j = 0; j < NumofClusters; j++)
            {

                Phi[j] = 0;
            }
            for (int j = 0; j < NumofClusters; j++)
            {



                r[j] = (float)Math.Sqrt(Math.Pow(sample[0] - centroid[j, 0], 2) +
                                        Math.Pow(sample[1] - centroid[j, 1], 2) +
                                        Math.Pow(sample[2] - centroid[j, 2], 2) +
                                        Math.Pow(sample[3] - centroid[j, 3], 2));
                if (sigma[j] != 0)
                {
                    Phi[j] = (float)Math.Exp(-r[j] / (2 * sigma[j]));
                }
                else
                {
                    Phi[j] = 0;
                }
            }
            Phi[NumofClusters] = 1;
            return Phi;


        }
        public Vector<float> StartTraining(Vector<float> Sigma, int NumofClusters,
                                           Matrix<float> centroid,Matrix<float> TestingData,
                                           Matrix<float> TrainingData,int epoch, float Rate,
                                           float mse_thresh)
        {
            Vector<float> accuracy_counters = Vector<float>.Build.Dense(9);
            Vector<float> Phi = Vector<float>.Build.Dense(NumofClusters + 1);
            Vector<float> weigts1 = Vector<float>.Build.Dense(NumofClusters + 1);
            Vector<float> weigts2 = Vector<float>.Build.Dense(NumofClusters + 1);
            Vector<float> weigts3 = Vector<float>.Build.Dense(NumofClusters + 1);
            for (int i = 0; i < NumofClusters + 1; i++)
            {
                weigts1[i] = 0;
                weigts2[i] = 0;
                weigts3[i] = 0;
            }
            float C = 0;
            Vector<float> X = Vector<float>.Build.Dense(4);
            Vector<float> d;
            for (int i = 0; i < epoch; i++)
            {
                TrainingData= Shuffle(TrainingData,90,5);
                for (int x = 0; x < 90; x++)
                {
                    d = Vector<float>.Build.Dense(3);
                    for (int j = 0; j < 4; j++)
                    {
                        X[j] = TrainingData[x, j];

                    }

                    C = TrainingData.Row(x).At(4);

                    Phi = Guassian(centroid, NumofClusters, X, Sigma);
                    float res1 = 0, res2 = 0, res3 = 0;
                    res1 = Adder(weigts1, Phi, NumofClusters);
                    res2 = Adder(weigts2, Phi, NumofClusters);
                    res3 = Adder(weigts3, Phi, NumofClusters);
                    float e1, e2, e3;
                    float y1 = res1;
                    float y2 = res2;
                    float y3 = res3;
                    if (C == 1)
                    {
                        d[0] = 1;
                        d[1] = 0;
                        d[2] = 0;
                        
                    }
                    else if (C == 2)
                    {
                        d[0] = 0;
                        d[1] = 1;
                        d[2] = 0;
                       
                    }
                    else if(C==3)
                    {
                        d[0] = 0;
                        d[1] = 0;
                        d[2] = 1;
                       
                    }
                    e1 = (d[0] - y1);
                    e2 = (d[1] - y2);
                    e3 = (d[2] - y3);
                    error1[x] = e1;
                    error2[x] = e2;
                    error3[x] = e3;
                    weigts1 = weigts1 + (Phi.Multiply(Rate * e1));
                    weigts2 = weigts2 + (Phi.Multiply(Rate * e2));
                    weigts3 = weigts3 + (Phi.Multiply(Rate * e3));
                }
                error1 = (error1.PointwisePower(2)).Multiply((float)0.5);
                error2 = (error2.PointwisePower(2)).Multiply((float)0.5);
                error3 = (error3.PointwisePower(2)).Multiply((float)0.5);
                float mse1 = (error1.Sum()) / (float)NumofClusters;
                float mse2 = (error2.Sum()) / (float)NumofClusters;
                float mse3 = (error3.Sum()) / (float)NumofClusters;
                mse1 = Math.Max(mse1, mse2);
                mse1 = Math.Max(mse1, mse3);
                if (mse1 < mse_thresh)
                    break;

            }
            Vector<float> accuracy = StartTesting(Rate, weigts1, weigts2, weigts3,
                                         centroid, NumofClusters, TestingData, Sigma);
            return accuracy;
        }
        public Vector<float> StartTesting(float Rate, Vector<float> weigts1, Vector<float> weigts2,
                                        Vector<float> weigts3, Matrix<float> centroid, int NumofClusters,
                                         Matrix<float> TestingData, Vector<float> Sigma)
        {
            Vector<float> accuracy_counters = Vector<float>.Build.Dense(9);
            Vector<float> Phi = Vector<float>.Build.Dense(NumofClusters + 1);
            Vector<float> X = Vector<float>.Build.Dense(4);
            
            for (int i = 0; i < 60; i++)
            {


                for (int j = 0; j < 4; j++)
                {
                    X[j] = TestingData[i, j];

                }
               

                Phi = Guassian(centroid, NumofClusters, X, Sigma);
                float y1 = 0;
                float y2 = 0;
                float y3 = 0;
                y1 = Adder(weigts1, Phi, NumofClusters);
                y2 = Adder(weigts2, Phi, NumofClusters);
                y3 = Adder(weigts3, Phi, NumofClusters);
                  if (y1 > y2 && y1 > y3)
                        accuracy_counters = accuracy(i, 1, accuracy_counters);
                    else if (y2 > y1 && y2 > y3)
                        accuracy_counters = accuracy(i, 2, accuracy_counters);
                    else
                        accuracy_counters = accuracy(i, 3, accuracy_counters);
                
            }
            return accuracy_counters;
        }
        public float Adder(Vector<float> w, Vector<float> k, int NumOfCluster)
        {
            Vector<float> temp = Vector<float>.Build.Dense(NumOfCluster);
            float res =0;
            for (int i = 0; i < NumOfCluster; i++)
            {
                res+= w[i] * k[i];

            }
               
           
            return res;
        }

        public Vector<float> accuracy(int i, int index, Vector<float> accuracy_counters)
        {

            if (i >= 0 && i <= 19)               ///// awel 20
            {
                if (index == 1)
                    accuracy_counters[0] += 1;   //// kam wa7da mn class 1

                else if (index == 2)
                    accuracy_counters[1] += 1;
                else if (index == 3)
                    accuracy_counters[2] += 1;
            }
            else if (i >= 20 && i <= 39)      ////// tany 20
            {
                if (index == 1)
                    accuracy_counters[3] += 1;     //// kam wa7da mn class 1

                else if (index == 2)
                    accuracy_counters[4] += 1;     //// kam wa7da mn class 3
                else if (index == 3)
                    accuracy_counters[5] += 1;
            }
            else
            {
                if (index == 1)
                    accuracy_counters[6] += 1;     //// kam wa7da mn class 1
                else if (index == 2)
                    accuracy_counters[7] += 1;     //// kam wa7da mn class 3
                else if (index == 3)
                    accuracy_counters[8] += 1;
            }

            return accuracy_counters;

        }
        static Random random = new Random();
        public Matrix<float> Shuffle(Matrix<float> array,int row,int col)
        {
            int n = row;
            for (int i = 0; i < n; i++)
            {
                int r = i + (int)(random.NextDouble() * (n - i));
                for (int j = 0; j < col; j++)
                {
                    // NextDouble returns a random number between 0 and 1.
                    // ... It is equivalent to Math.random() in Java.

                    float t = array[r, j];
                    array[r, j] = array[i, j];
                    array[i, j] = t;
                }

            }
            return array;
        }
    }
}
