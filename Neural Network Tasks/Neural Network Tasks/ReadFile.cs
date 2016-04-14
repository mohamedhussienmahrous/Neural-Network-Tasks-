using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Windows.Forms;
using System.Drawing;
namespace Neural_Network_Tasks
{
    class ReadFile
    {


        private static OpenFileDialog open;
       
        private Matrix<float> TrainingData = Matrix<float>.Build.Dense(90, 5);
        private Matrix<float> TestingData = Matrix<float>.Build.Dense(60, 4);
        private List<Matrix<float>> Data= new List<Matrix<float>>();
/// <summary>
/// //////////
/// </summary>
/// <param name="AllData"></param>
/// <returns></returns>
        public Matrix<float> NormlizedData(Matrix<float> AllData)
        {
            Vector<float> sumtion = Vector<float>.Build.Dense(4);
            Vector<float> max = Vector<float>.Build.Dense(4);
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 150; i++)
                {
                    sumtion[j] += AllData[i, j];
                }
            }
            sumtion = sumtion / 150;
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 150; i++)
                {
                    AllData[i, j] = AllData[i, j] - sumtion[j] ;
                }
            }
            for (int j = 0; j < 4; j++)
            {

                max[j]=AllData.Column(j).Max();
                
            }
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 150; i++)
                {
                    AllData[i, j] = AllData[i, j] / max[j];
                }
            }
       
            return AllData;
        }
        public List<Matrix<float>> read_from_file(ref TextBox filepath)
        {
            Matrix<float> AllData = Matrix<float>.Build.Dense(150, 4);
            open = new OpenFileDialog();
            open.Filter = "Text files (*.txt)|*.txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new
                                 FileStream(open.FileName, FileMode.Open, FileAccess.Read);
                StreamReader r = new StreamReader(fs);
                filepath.Text = open.FileName;
                string line;
                string[] temp;
                line = r.ReadLine();

                for (int i = 0; i < 150; i++)
                {
                    line = r.ReadLine();
                    for (int j = 0; j < 4; j++)
                    {
                        temp = line.Split(',');

                        AllData[i, j] = float.Parse(temp[j]);
                    }
                }
                   r.Close();
            }
            AllData = NormlizedData(AllData);
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    TrainingData[i, j] = AllData[i, j];

                }
            }
            for (int i = 30; i < 50; i++)
            {

                for (int j = 0; j < 4; j++)
                {

                    TestingData[i-30, j] = AllData[i, j];
                }
            }
            for (int i = 50; i < 80; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    TrainingData[i-20, j] = AllData[i, j];

                }

            }
            for (int i = 80; i < 100; i++)
            {

                for (int j = 0; j < 4; j++)
                {
                    TestingData[i-60, j] = AllData[i, j];

                }
            }
            for (int i = 100; i < 130; i++)
            {

                for (int j = 0; j < 4; j++)
                {

                    TrainingData[i-40, j] = AllData[i, j];
                }
            }
            for (int i = 130; i < 150; i++)
            {

                for (int j = 0; j < 4; j++)
                {

                    TestingData[i-90, j] = AllData[i, j];
                }
            }
                
            for (int i = 0; i < 90; i++)
            {
                if (i >= 0 && i <= 29)
                    TrainingData[i,4] = 1;
                else if (i >= 30 && i <= 59)
                    TrainingData[i,4] = 2;
                else
                    TrainingData[i,4] = 3;
            }
            for (int i = 0; i < 60; i++)
            {
                if (i >= 0 && i <= 19)
                    TrainingData[i, 4] = 1;
                else if (i >= 20 && i <= 39)
                    TrainingData[i, 4] = 2;
                else
                    TrainingData[i, 4] = 3;
            }
            Data.Add(TrainingData);
            Data.Add(TestingData);
            return Data;
           //return data



        }
    }
}
