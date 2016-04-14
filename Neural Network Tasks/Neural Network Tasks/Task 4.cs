using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
namespace Neural_Network_Tasks
{
    public partial class Task_4 : Form
    {
        KMeans kmeans = new KMeans();
        int epoch;
        float Lrate;
        float mse_thresh;
        int NumOftr = 90;
        int Numofte = 60;
        int Numoftr_features = 5;
        int Numofte_features = 4;
        int NumofClusters;
        public List<Matrix<float>> Data = new List<Matrix<float>>();
        public Task_4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            epoch =int.Parse(Epoch.Text.ToString());
            Lrate = float.Parse(Eta.Text.ToString());
            mse_thresh = float.Parse(textBox_mse.Text.ToString());
            NumofClusters=int.Parse(NumberOfClusters.Text.ToString());
            Vector<float> accuracy;
             accuracy=kmeans.Kmeans(NumofClusters, Data, epoch, Lrate, mse_thresh);
           //  dataGridView_confusion_matrix.Rows.Add("Iris-setosa", "Iris-versicolor", "Iris-virginica");
             dataGridView_confusion_matrix.Rows.Clear();
             dataGridView_confusion_matrix.Rows.Add(accuracy[0], accuracy[1], accuracy[2]);
             dataGridView_confusion_matrix.Rows.Add(accuracy[3], accuracy[4], accuracy[5]);
             dataGridView_confusion_matrix.Rows.Add(accuracy[6], accuracy[7], accuracy[8]);
             
             float overall = (float)(((accuracy[0] + accuracy[4] + accuracy[8])/60.0)*100.0);

             textBox_overall_accuracy.Text = overall.ToString();
             accuracy = Vector<float>.Build.Dense(9);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReadFile read =new ReadFile();
            Data=read.read_from_file(ref textBox_file_path);
        }

    }
}
