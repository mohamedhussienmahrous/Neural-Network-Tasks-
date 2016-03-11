using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.ComponentModel;
using Patterns_Recognition___Task_1;

namespace Neural_Network_Tasks
{
    public partial class Task_2 : Form
    {
        Task_2_View_Handler object_view_handler;
        public Task_2()
        {
            InitializeComponent();
            object_view_handler = new Task_2_View_Handler();
            chart1.Series.Clear();

            var Algorithms = new BindingList<KeyValuePair<string, string>>();
            Algorithms.Add(new KeyValuePair<string, string>("0", "[Select Algorithm]"));
            Algorithms.Add(new KeyValuePair<string, string>("2", "The Batch Perceptron Algorithm"));
            Algorithms.Add(new KeyValuePair<string, string>("3", "Least Mean Square"));
            Algorithms.Add(new KeyValuePair<string, string>("4", "Other"));
            comboBox5.DataSource = Algorithms;
            comboBox5.ValueMember = "Key";
            comboBox5.DisplayMember = "Value";
            comboBox5.SelectedIndex = 0;
            comboBox5.Width = 180;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[] wigh = new double[2];

            if (Convert.ToString(comboBox5.SelectedValue) == "1")
                wigh = object_view_handler.Apply(ref chart1, comboBox1.SelectedIndex, comboBox2.SelectedIndex, comboBox4.SelectedIndex, comboBox3.SelectedIndex, textBox2, textBox1);

            else if (Convert.ToString(comboBox5.SelectedValue) == "3")
                wigh = object_view_handler.ApplyLMS(ref chart1, comboBox1.SelectedIndex, comboBox2.SelectedIndex, comboBox4.SelectedIndex, comboBox3.SelectedIndex, textBox2, textBox1);
            // else if ((int)comboBox5.SelectedValue == 3)


            label5.Text = "the first weigth = " + wigh[0].ToString();
            label6.Text = "the second weigth = " + wigh[1].ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //    Cur= Cursors.WaitCursor;
            object_view_handler.handle_load_data_set_button_click(comboBox3, comboBox4, comboBox1, comboBox2, this, textBox_file_path, dataGridView_confusion_matrix, textBox_overall_accuracy);
            //Cursor.Current = Cursors.Default;
        }
    }
}
