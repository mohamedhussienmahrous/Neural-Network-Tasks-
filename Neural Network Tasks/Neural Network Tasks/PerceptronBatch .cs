﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network_Tasks
{
    class PerceptronBatch
    {
        public double[] Weights;
        public double Bias;
        Generic_State_Of_Nature[] Classes;
        int C1, C2, F1, F2, Epoch;
        double lamda;
        double Totalerror;

        public PerceptronBatch(Generic_State_Of_Nature[] C, double B, int c1, int c2, int Feature1, int Feature2, int E, double lamda)
        {
            Epoch = E;
            F1 = Feature1;
            F2 = Feature2;
            Classes = C;
            Bias = B;
            C1 = c1;
            C2 = c2;
            Weights = new double[2] { 0, 0 };
            this.lamda = lamda;

        }
        public double[] Training()
        {
            for (int Ep = 0; Ep < Epoch; ++Ep)
            {
                Totalerror = 0;
                double[,] Mis_X = new double[3, 1];
                for (int i = 0; i < Classes[0].num_of_training_samples; ++i)
                {
                    double V = new Adder().ApplySpeacialAdder(Bias, Weights[0], Weights[1], Classes[C1].training_samples[i].features_values[F1, 0], Classes[C1].training_samples[i].features_values[F2, 0]);
                    double Y = new ActivationFunctions().sign(V, C1, C2);
                    int d = 0;
                    if (d == Y)
                        d = 1;
                    else d = -1;

                    //Totalerror += ((d - Y) * (d - Y)) / 2;
                    Mis_X[0, 0] += (d - Y);
                    Mis_X[1, 0] += (d - Y) * Classes[C1].training_samples[i].features_values[F1, 0];
                    Mis_X[2, 0] += (d - Y) * Classes[C1].training_samples[i].features_values[F2, 0];

                }

                for (int i = 0; i < Classes[0].num_of_training_samples; ++i)
                {
                    double V = new Adder().ApplySpeacialAdder(Bias, Weights[0], Weights[1], Classes[C2].training_samples[i].features_values[F1, 0], Classes[C2].training_samples[i].features_values[F2, 0]);
                    double Y = new ActivationFunctions().sign(V, C1, C2);
                    int d = 0;
                    if (d == Y)
                        d = 1;
                    else d = -1;

                    Mis_X[0, 0] += (d - Y);
                    Mis_X[1, 0] += (d - Y) * Classes[C2].training_samples[i].features_values[F1, 0];
                    Mis_X[2, 0] += (d - Y) * Classes[C2].training_samples[i].features_values[F2, 0];

                    //Totalerror += ((d - Y) * (d - Y)) / 2;
                    // Mis_X += (d-Y)* Classes[C1].training_samples[i]
                }
                //Totalerror /= (Classes[C1].num_of_training_samples + Classes[C2].num_of_training_samples);

                Weights[0] = Weights[0] + lamda * Mis_X[1, 0];
                Weights[1] = Weights[1] + lamda * Mis_X[2, 0];

            }
            return Weights;
        }


        public int testing(Sample s, int F1, int F2)
        {
            double V = new Adder().ApplySpeacialAdder(Bias, Weights[0], Weights[1], s.features_values[F1, 0], s.features_values[F2, 0]);
            int Y = new ActivationFunctions().sign(V, C1, C2);
            return Y;
        }
    }
}

