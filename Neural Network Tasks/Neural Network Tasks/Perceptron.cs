using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network_Tasks
{
    class Perceptron
    {
        double[] Weights;
        double Bias;
        Generic_State_Of_Nature[] Classes;
        int C1, C2, F1, F2, Epoch;

        public Perceptron(Generic_State_Of_Nature[] C, double B, double[] W, int c1, int c2, int Feature1, int Feature2)
        {
            F1 = Feature1;
            F2 = Feature2;
            Classes = C;
            Bias = B;
            Weights = W;
            C1 = c1;
            C2 = c2;
            Weights = new double[2];

        }
        public void Training()
        {
            for (int Ep = 0; Ep < Epoch; ++Ep)
            {
                for (int num = 0; num < Classes.Length; num++)
                    for (int i = 0; i < Classes[0].num_of_training_samples; ++i)
                    {
                        double V = new Adder().ApplySpeacialAdder(Bias, Weights[0], Weights[1], Classes[num].training_samples[i].features_values[F1, 0], Classes[num].training_samples[i].features_values[F2, 0]);
                        double Y = new ActivationFunctions().sign(V, C1, C2);
                        int d = 0;
                        if (d == Y)
                            d = 1;
                        else d = -1;

                        Weights[0] = Weights[0] + (d - Y) * Classes[num].training_samples[i].features_values[F1, 0];
                        Weights[1] = Weights[1] + (d - Y) * Classes[num].training_samples[i].features_values[F2, 0];


                    }
            }

        }
        private void initializeWeights()
        {
            for (int i = 0; i < Weights.Length; ++i)
                Weights[i] = 0;
        }

        //public int 
    }
}
