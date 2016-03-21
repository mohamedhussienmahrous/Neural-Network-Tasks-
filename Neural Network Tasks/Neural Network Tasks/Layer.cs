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
       public Layer(int NumberOfNeurons)
        {
            this.NumberOfNeurons = NumberOfNeurons;
            this.Neurons = new Neuron[this.NumberOfNeurons];
        }
        
    }
}
