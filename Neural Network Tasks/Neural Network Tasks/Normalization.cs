using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network_Tasks
{
    class Normalization
    {
        Generic_State_Of_Nature[] c;
        double[] max1;
        double[] mean;
        int C1, C2;
        int F1, F2;
        Generic_State_Of_Nature[] afternormailzed;

        public Normalization(Generic_State_Of_Nature[] input, int C1, int C2, int feat1, int feat2)
        {
            this.c = input;
            max1 = new double[2];
            mean = new double[2];

            for (int p = 0; p < 2; p++)
                max1[p] = double.MinValue;

            for (int p = 0; p < 2; p++)
                mean[p] = 0;
            this.C1 = C1;
            this.C2 = C2;

        }

        public Generic_State_Of_Nature[] makeNormalization()
        {
            for (int feat = 0; feat < 2; feat++)

                for (int g = 0; g < c.Length; g++)
                {
                    if (C1 == g) continue;
                    if (C2 == g) continue;

                    for (int S = 0; S < c[g].training_samples.Length; S++)
                    {
                        if (c[g].training_samples[S].features_values[feat, 0] > max1[feat])
                            max1[feat] = c[g].training_samples[S].features_values[feat, 0];
                        mean[feat] += c[g].training_samples[S].features_values[feat, 0];
                    }
                }

            for (int feat = 0; feat < 2; feat++)
                for (int g = 0; g < c.Length; g++)
                {
                    if (C1 == g) continue;
                    if (C2 == g) continue;

                    for (int S = 0; S < c[g].test_samples.Length; S++)
                    {
                        if (c[g].test_samples[S].features_values[feat, 0] > max1[feat])
                            max1[feat] = c[g].test_samples[S].features_values[feat, 0];
                        mean[feat] += c[g].test_samples[S].features_values[feat, 0];

                    }
                }

            for (int p = 0; p < 2; p++)
                mean[p] /= (2 * (c[0].num_of_test_samples + c[0].num_of_training_samples));



            for (int feat = 0; feat < 2; feat++)
                for (int g = 0; g < c.Length; g++)
                {
                    if (C1 == g) continue;
                    if (C2 == g) continue;

                    for (int S = 0; S < c[g].training_samples.Length; S++)
                    {

                        afternormailzed[g].training_samples[S].features_values[feat, 0] = (c[g].training_samples[S].features_values[feat, 0] - mean[feat]) / max1[feat];


                    }
                }

            for (int feat = 0; feat < c[0].num_of_features; feat++)
                for (int g = 0; g < c.Length; g++)
                {
                    if (C1 == g) continue;
                    if (C2 == g) continue;

                    for (int S = 0; S < c[g].test_samples.Length; S++)
                    {
                        afternormailzed[g].test_samples[S].features_values[feat, 0] = (c[g].test_samples[S].features_values[feat, 0] - mean[feat]) / max1[feat];

                    }

                }
            return afternormailzed;
        }

    }
}
