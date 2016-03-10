using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neural_Network_Tasks
{
    public partial class Task_2 : Form
    {
        Task_1_View_Handler object_view_handler;
        public Task_2()
        {
            InitializeComponent();
            object_view_handler = new Task_1_View_Handler();
            chart1.Series.Clear();

            var employmentStatus = new BindingList<KeyValuePair<string, string>>();
            employmentStatus.Add(new KeyValuePair<string, string>("0", "[Select Status]"));
            employmentStatus.Add(new KeyValuePair<string, string>("1", "The Perceptron Algorithm"));
            employmentStatus.Add(new KeyValuePair<string, string>("2", "The Batch Perceptron Algorithm"));
            employmentStatus.Add(new KeyValuePair<string, string>("3", "LMS"));



            employmentStatus.Add(new KeyValuePair<string, string>("4", "Other"));
            comboBox5.DataSource = employmentStatus;
            comboBox5.ValueMember = "Key";
            comboBox5.DisplayMember = "Value";
            comboBox5.SelectedIndex = 0;
            comboBox5.Width = 180;

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
