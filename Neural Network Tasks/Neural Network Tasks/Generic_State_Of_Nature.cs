using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/**
 * Math DOT NET Numerics
 * PM> Install-Package MathNet.Numerics
 **/
//using MathNet.Numerics.LinearAlgebra;
//using MathNet.Numerics.LinearAlgebra.Double;

namespace Neural_Network_Tasks
{
    class Generic_State_Of_Nature
    {
        public int num_of_features,
            num_of_training_samples,
            num_of_test_samples;
        public Sample[] training_samples,
            test_samples;
        public string label;
        public double priori;
        public Generic_State_Of_Nature(int _num_of_features, int _num_training_samples, int _num_of_test_samples, double _priori)
        {
            num_of_features = _num_of_features;

            num_of_training_samples = _num_training_samples;
            num_of_test_samples = _num_of_test_samples;

            priori = _priori;

            training_samples = new Sample[num_of_training_samples];
            test_samples = new Sample[_num_of_test_samples];
        }

        

        
    }
}
