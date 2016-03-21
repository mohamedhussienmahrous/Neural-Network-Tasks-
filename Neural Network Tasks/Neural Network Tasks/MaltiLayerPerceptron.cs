using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network_Tasks
{
    class MaltiLayerPerceptron
    {
        public double ErrorRate;
        public int NumberOfEpochs;
        public int NumberOfHiddenLayers;
        public int[] NumberOfNeuronsForEachHiddenLayer;
        public Layer[] AllLayers;
        public Generic_State_Of_Nature[]Classes;
        MaltiLayerPerceptron(Generic_State_Of_Nature[] Cs,double ErrorRate,int NumberOfEpochs,int NumberOfHiddenLayers,int[]NumberOfNeuronsForEachHiddenLayer)
        {
            this.ErrorRate = ErrorRate;
            this.NumberOfEpochs = NumberOfEpochs;
            this.NumberOfHiddenLayers = NumberOfHiddenLayers;
            this.NumberOfNeuronsForEachHiddenLayer = NumberOfNeuronsForEachHiddenLayer;
            this.AllLayers = new Layer[NumberOfHiddenLayers + 2];
            this.Classes = Cs;
            AllLayers[0] = new Layer(Classes[0].num_of_features);
            AllLayers[this.NumberOfHiddenLayers + 1] = new Layer(Classes.Length);
            for (int i = 1; i <= this.NumberOfHiddenLayers; ++i)
              AllLayers[i] = new Layer(NumberOfNeuronsForEachHiddenLayer[i - 1]);
            
        }
        public void MLPTraining()
        {
            for (int i = 0; i < this.NumberOfEpochs; ++i)
            {

            }
        }
    }
}
