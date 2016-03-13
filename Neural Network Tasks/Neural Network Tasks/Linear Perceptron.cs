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
        double sum, V;

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
           
            Matrix Idel = Matrix.Multiply(lamda, (Matrix.IdentityMatrix(2, 2)));
            Matrix RXXmat = RXX(Classes, C1, C2, F1, F2);
            Matrix RDXmat = RDX(Classes, C1, C2, F1, F2);
            Matrix result = Matrix.Power((RXXmat + Idel), -1)*RDXmat;
            Weights[0] = result[0, 0];
            Weights[1] = result[1, 0];
            return Weights;
        }


        public double testing(Sample s, int F1, int F2)
        {
            V = new Adder().ApplySpeacialAdder(Bias, Weights[0], Weights[1], s.features_values[F1, 0], s.features_values[F2, 0]);
            return V;
        }
        public Matrix RXX(Generic_State_Of_Nature[] C, int C1, int C2, int featureindex1, int featureindex2)
        {
            Matrix max_x = new Matrix((C[C1].num_of_training_samples + C[C2].num_of_training_samples), 2);
            Matrix max_d = new Matrix((C[C1].num_of_training_samples + C[C2].num_of_training_samples), 1);


            for (int g = 0; g < C[C1].num_of_training_samples; g++)
            {
                max_x[g, 0] = C[C1].training_samples[g].features_values[featureindex1, 0];
                max_x[g, 1] = C[C1].training_samples[g].features_values[featureindex2, 0];
                max_d[g, 0] = 1;

            }
            for (int g = 0; g < C[C2].num_of_training_samples; g++)
            {
                max_x[g + C[C1].num_of_training_samples - 1, 0] = C[C2].training_samples[g].features_values[featureindex1, 0];
                max_x[g + C[C1].num_of_training_samples - 1, 1] = C[C2].training_samples[g].features_values[featureindex2, 0];
                max_d[g + C[C1].num_of_training_samples - 1, 0] = -1;
            }

            Matrix DD = Matrix.Transpose(max_x);
            return DD*max_x;
        }

        public Matrix RDX(Generic_State_Of_Nature[] C, int C1, int C2, int featureindex1, int featureindex2)
        {
            Matrix max_x = new Matrix((C[0].num_of_training_samples + C[0].num_of_training_samples), 2);
            Matrix max_d = new Matrix((C[0].num_of_training_samples + C[0].num_of_training_samples), 1);


            for (int g = 0; g < C[C1].num_of_training_samples; g++)
            {
                max_x[g, 0] = C[C1].training_samples[g].features_values[featureindex1, 0];
                max_x[g, 1] = C[C1].training_samples[g].features_values[featureindex2, 0];
                max_d[g, 0] = 1;

            }
            for (int g = 0; g < C[C2].num_of_training_samples; g++)
            {
                max_x[g + C[C2].num_of_training_samples-1, 0] = C[C2].training_samples[g].features_values[featureindex1, 0];
                max_x[g + C[C2].num_of_training_samples-1, 1] = C[C2].training_samples[g].features_values[featureindex2, 0];
                max_d[g + C[C2].num_of_training_samples-1, 0] = -1;
            }

            max_x = Matrix.Transpose(max_x);
            return Matrix.StrassenMultiply(max_x, max_d);
        }

    }
}
