using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network_Tasks
{
    class Linear_Perceptron
    {
        public double[] Weights;
        public double Bias;
        Generic_State_Of_Nature[] Classes;
        int C1, C2, F1, F2, Epoch;
        double lamda;
        int d;
        double sum;

        public Linear_Perceptron(Generic_State_Of_Nature[] C, double B, int c1, int c2, int Feature1, int Feature2, int E, double lamda)
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
            Weights[0] = 1 / (RXX(Classes, C1, C2, F1) * lamda) * RDX(Classes, C1, C2, F1);
            Weights[1] = 1 / (RXX(Classes, C1, C2, F2) * lamda) * RDX(Classes, C1, C2, F2);
            return Weights;
        }


        public int testing(Sample s, int F1, int F2)
        {
            double V = new Adder().ApplySpeacialAdder(Bias, Weights[0], Weights[1], s.features_values[F1, 0], s.features_values[F2, 0]);
            d = C1;
            if (d == V)
                d = 1;
            else d = -1;

            return d;
        }
        public double RXX(Generic_State_Of_Nature[] C, int C1, int C2, int featureindex)
        {
            sum = 0;
            for (int x = 0; x < C[C1].num_of_training_samples; x++)
                for (int y = 0; y < C[C2].num_of_training_samples; y++)
                    sum += C[C1].training_samples[x].features_values[featureindex, 0] * C[C2].training_samples[y].features_values[featureindex, 0];
            return -sum;
        }

        public double RDX(Generic_State_Of_Nature[] C, int C1, int C2, int featureindex)
        {
            sum = 0;
            for (int g = 0; g < C[C1].num_of_training_samples; g++)
            {
                sum += C[C1].training_samples[g].features_values[featureindex, 0] * 1;
            }
            for (int g = 0; g < C[C2].num_of_training_samples; g++)
            {
                sum += C[C1].training_samples[g].features_values[featureindex, 0] * -1;
            }
            return -sum;
        }

    }
}
