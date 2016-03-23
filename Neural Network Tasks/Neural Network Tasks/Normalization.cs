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
            F1 = feat1;
            F2 = feat2;
            afternormailzed = c;

        }
        public Normalization(Generic_State_Of_Nature[] input)
        {
            this.c = input;
            max1 = new double[4];
            mean = new double[4];

            for (int p = 0; p < 4; p++)
                max1[p] = double.MinValue;

            for (int p = 0; p < 4; p++)
                mean[p] = 0;
            afternormailzed = c;

        }
        public Generic_State_Of_Nature[] makeNormalization()
        {

            for (int g = 0; g < c.Length; g++)
            {
                if (C1 == g || C2 == g)
                    for (int S = 0; S < c[g].training_samples.Length; S++)
                    {
                        if (c[g].training_samples[S].features_values[F1, 0] > max1[0])
                            max1[0] = c[g].training_samples[S].features_values[F1, 0];
                        mean[0] += c[g].training_samples[S].features_values[F1, 0];
                    }
            }


            for (int g = 0; g < c.Length; g++)
            {
                if (C1 == g || C2 == g)
                    for (int S = 0; S < c[g].training_samples.Length; S++)
                    {
                        if (c[g].training_samples[S].features_values[F2, 0] > max1[1])
                            max1[1] = c[g].training_samples[S].features_values[F2, 0];
                        mean[1] += c[g].training_samples[S].features_values[F2, 0];
                    }
            }


            for (int g = 0; g < c.Length; g++)
            {
                if (C1 == g || C2 == g)

                    for (int S = 0; S < c[g].test_samples.Length; S++)
                    {
                        if (c[g].test_samples[S].features_values[F1, 0] > max1[0])
                            max1[0] = c[g].test_samples[S].features_values[F1, 0];
                        mean[0] += c[g].test_samples[S].features_values[F1, 0];

                    }
            }


            for (int g = 0; g < c.Length; g++)
            {
                if (C1 == g || C2 == g)

                    for (int S = 0; S < c[g].test_samples.Length; S++)
                    {
                        if (c[g].test_samples[S].features_values[F2, 0] > max1[1])
                            max1[1] = c[g].test_samples[S].features_values[F2, 0];
                        mean[1] += c[g].test_samples[S].features_values[F2, 0];

                    }
            }

            for (int p = 0; p < 2; p++)
                mean[p] /= (2 * (c[0].num_of_test_samples + c[0].num_of_training_samples));


            for (int g = 0; g < c.Length; g++)
            {
                if (C1 == g || C2 == g)

                    for (int S = 0; S < c[g].training_samples.Length; S++)
                    {

                        afternormailzed[g].training_samples[S].features_values[F1, 0] = (c[g].training_samples[S].features_values[F1, 0] - mean[0]) / max1[0];


                    }
            }


            for (int g = 0; g < c.Length; g++)
            {
                if (C1 == g || C2 == g)

                    for (int S = 0; S < c[g].training_samples.Length; S++)
                    {

                        afternormailzed[g].training_samples[S].features_values[F2, 0] = (c[g].training_samples[S].features_values[F2, 0] - mean[1]) / max1[1];


                    }
            }


            ////////////////////////

            for (int g = 0; g < c.Length; g++)
            {
                if (C1 == g || C2 == g)

                    for (int S = 0; S < c[g].test_samples.Length; S++)
                    {
                        afternormailzed[g].test_samples[S].features_values[F1, 0] = (c[g].test_samples[S].features_values[F1, 0] - mean[0]) / max1[0];

                    }

            }


            for (int g = 0; g < c.Length; g++)
            {
                if (C1 == g || C2 == g)

                    for (int S = 0; S < c[g].test_samples.Length; S++)
                    {
                        afternormailzed[g].test_samples[S].features_values[F2, 0] = (c[g].test_samples[S].features_values[F2, 0] - mean[1]) / max1[1];

                    }

            }
            return afternormailzed;
        }
        public Generic_State_Of_Nature[] makeNormalizationalldataset()
        {
            //to get mean
            for (int w = 0; w < 4; w++)
                for (int g = 0; g < c.Length; g++)
                {
                    for (int S = 0; S < c[g].training_samples.Length; S++)
                    {
                        mean[w] += c[g].training_samples[S].features_values[w, 0];

                    }
                }

            for (int w = 0; w < 4; w++)
                for (int g = 0; g < c.Length; g++)
                {
                    for (int S = 0; S < c[g].test_samples.Length; S++)
                    {
                        mean[w] += c[g].test_samples[S].features_values[w, 0];

                    }
                }
            for (int a = 0; a < 4; a++)
                mean[a] /= (3 * (c[0].num_of_test_samples + c[0].num_of_training_samples));


            for (int w = 0; w < 4; w++)
                for (int g = 0; g < c.Length; g++)
                    for (int S = 0; S < c[g].training_samples.Length; S++)
                        c[g].training_samples[S].features_values[w, 0] = c[g].training_samples[S].features_values[w, 0] - mean[w];



            for (int w = 0; w < 4; w++)
                for (int g = 0; g < c.Length; g++)
                    for (int S = 0; S < c[g].test_samples.Length; S++)
                        c[g].test_samples[S].features_values[w, 0] = c[g].test_samples[S].features_values[w, 0] - mean[w];

            ///////////to get max
            for (int w = 0; w < 4; w++)
                for (int g = 0; g < c.Length; g++)
                    for (int S = 0; S < c[g].training_samples.Length; S++)
                        if (c[g].training_samples[S].features_values[w, 0] > max1[w])
                            max1[w] = c[g].training_samples[S].features_values[w, 0];


            for (int w = 0; w < 4; w++)
                for (int g = 0; g < c.Length; g++)
                    for (int S = 0; S < c[g].test_samples.Length; S++)
                        if (c[g].test_samples[S].features_values[w, 0] > max1[w])
                            max1[w] = c[g].test_samples[S].features_values[w, 0];



            for (int w = 0; w < 4; w++)
                for (int g = 0; g < c.Length; g++)
                    for (int S = 0; S < c[g].training_samples.Length; S++)
                        c[g].training_samples[S].features_values[w, 0] /= max1[w];


            for (int w = 0; w < 4; w++)
                for (int g = 0; g < c.Length; g++)
                    for (int S = 0; S < c[g].test_samples.Length; S++)
                        c[g].test_samples[S].features_values[w, 0] /= max1[w];

            return c;
        }
    }
}
