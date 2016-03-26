using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network_Tasks
{
    class MultiLayerPerceptron
    {
       
        public int NumberOfEpochs;
        public int NumberOfHiddenLayers;
        public int[] NumberOfNeuronsForEachHiddenLayer;
        public Layer[] AllLayers;
        public Generic_State_Of_Nature[]Classes;
        public MultiLayerPerceptron(Generic_State_Of_Nature[] Cs,double Eta,int NumberOfEpochs,int NumberOfHiddenLayers,int[]NumberOfNeuronsForEachHiddenLayer)
        {
            
            this.NumberOfEpochs = NumberOfEpochs;
            this.NumberOfHiddenLayers = NumberOfHiddenLayers;
            this.NumberOfNeuronsForEachHiddenLayer = NumberOfNeuronsForEachHiddenLayer;
            this.AllLayers = new Layer[NumberOfHiddenLayers + 2];
            this.Classes = Cs;
            AllLayers[0] = new Layer(Classes[0].num_of_features,Eta,Classes[0].num_of_features);
            AllLayers[this.NumberOfHiddenLayers + 1] = new Layer(Classes.Length,Eta, NumberOfNeuronsForEachHiddenLayer[NumberOfNeuronsForEachHiddenLayer.Length-1]);
            for (int i = 1; i <= this.NumberOfHiddenLayers; ++i)
              AllLayers[i] = new Layer(NumberOfNeuronsForEachHiddenLayer[i - 1],Eta, AllLayers[i-1].NumberOfNeurons);
            
        }
        public void MLPTraining()
        {
            for (int i = 0; i < this.NumberOfEpochs; ++i)
            {

                //Raye7
              for(int c=0;c<Classes.Length;++c)
                    for(int s=0;s<Classes[c].num_of_training_samples;++s)
                    {
                        ///take feature input
                        AllLayers[0].SetY(Classes[c].training_samples[s].features_values);
                        ///forward finished
                        for (int L = 1; L < AllLayers.Length; ++L)
                            AllLayers[L].Forward(AllLayers[L - 1]);
                        ////Back Propagation
                        ////Output Layer 
                        AllLayers[AllLayers.Length - 1].CalculateOutputLayerSignalError(Map(c));
                        ////All Hidden
                        for (int x = AllLayers.Length - 2; x > 0; x--)
                            AllLayers[x].CalculateSignalError(AllLayers[x + 1]);
                        //////Update Weights
                        for (int p = 1; p < AllLayers.Length; ++p)
                            AllLayers[p].UpdateWeight(AllLayers[p - 1]);



                    }

            }
        }
        private double[] Map(int C)
        {
            double[] d =new double[Classes.Length];
            for (int i = 0; i < d.Length; ++i)
                d[i] = 0;
            d[C] = 1;
            return d;
        }
        public double[] MLPTesting(Sample InputSample)
        {
            double[] x = new double[AllLayers[AllLayers.Length - 1].Neurons.Length];
            
            AllLayers[0].SetY(InputSample.features_values);
            
            ///forward finished
            for (int L = 1; L < AllLayers.Length; ++L)
                AllLayers[L].Forward(AllLayers[L - 1]);

            for (int i = 0; i < AllLayers[AllLayers.Length - 1].Neurons.Length; i++)
            {
                x[i] = AllLayers[AllLayers.Length - 1].Neurons[i].Y;

            }
            return x;
        }
    }
}
