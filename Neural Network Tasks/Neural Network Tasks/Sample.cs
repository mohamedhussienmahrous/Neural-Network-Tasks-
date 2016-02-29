using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neural_Network_Tasks
{
    class Sample
    {
        public int number_of_features;

        public double[,] features_values;

        public Sample(int _num_of_features, double[,] _features_values)
        {
            number_of_features = _num_of_features;
            features_values = _features_values;
        }
    }
}
