using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network_Tasks
{
    class Layer
    {
        public int NumberOfNeurons;
        public Neuron[] Neurons;
       public Layer(int NumberOfNeurons,double Eta,int NF)
        {
            this.NumberOfNeurons = NumberOfNeurons;
            this.Neurons = new Neuron[this.NumberOfNeurons];
            for (int i = 0; i < Neurons.Length; ++i)
                Neurons[i] = new Neuron(1,Eta,NF);
        }
        public void SetY(double[,] F)
        {
            for(int i=0;i<F.Length;++i)
            this.Neurons[i].Y = F[i,0];
        }
        public void Forward(Layer L)
        {
            for (int i = 0; i < this.Neurons.Length; ++i)
                this.Neurons[i].CalculateV(L);
        }
        public void CalcSigma()
        {
            for(int i=0;i<this.NumberOfNeurons;++i)
                ///////
        }
    }
}
