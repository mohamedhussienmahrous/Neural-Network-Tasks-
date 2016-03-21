using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network_Tasks
{
    class Neuron
    {
        public double Bias;
        public double[] Weights;
        public double SignalError;
        public double Y;
        public double V;
        public double ErrorRate;
        public Neuron(double B, double n, int NumberOfWeights)
        {
            Bias = B;
            ErrorRate = n;
            Weights = new double[NumberOfWeights + 1];
            GenerateRandomWeights();
        }
        private void CalculateV(double[] Features)
        {
            V = Bias * Weights[0];
            for (int i = 0; i < Features.Length; ++i)
                V += Features[i] * Weights[i + 1];
        }
        private void GenerateRandomWeights()
        {
            Random rnd = new Random();
            for (int i = 0; i < Weights.Length; i++)
            {
                double w= rnd.Next(0,11);
                Weights[i] = w/10;
            }
        }
        private void CalculateY()
        {
           // Y = new ActivationFunctions().Sigmoid(V);
        }
        public void Run(double[] Features)
        {

        }


    }
}
