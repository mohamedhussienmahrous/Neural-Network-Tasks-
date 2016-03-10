using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.ComponentModel;


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
            employmentStatus.Add(new KeyValuePair<string, string>("3", "Least Mean Square"));
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
