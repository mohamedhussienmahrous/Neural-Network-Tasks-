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

            return Weights;
        }


        public int testing(Sample s, int F1, int F2)
        {
            return 0;
        }

    }
}
