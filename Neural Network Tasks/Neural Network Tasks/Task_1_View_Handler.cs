﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace Neural_Network_Tasks
{
    class Task_1_View_Handler
    {
        public Generic_State_Of_Nature[] array_states_of_nature;
        int[,] confusion_matrix;
        double overall_accuracy;

        const int number_of_features = 4,
            number_of_states_of_nature = 3,
            number_of_samples_per_state_of_nature = 50,
            number_of_training_samples_per_state_of_nature = 30,
            number_of_test_samples_per_state_of_nature = 20;

        const char file_delimeter = ',';

        GenericDataSet object_data_set;
        DataGridView confusion_matrix_control;
        TextBox overall_accuracy_control;
        public void handle_load_data_set_button_click(ComboBox Cbx1, ComboBox Cbx2,
            Form parent_form,
            TextBox file_path_text_box,
            DataGridView dgrdv_confusion_matrix,
            TextBox textbox_overall_accuracy
            )
        {
            confusion_matrix_control = dgrdv_confusion_matrix;
            overall_accuracy_control = textbox_overall_accuracy;
            Stream data_set_file_stream = new ReadTestCasesFromFile().open_file_dialog(parent_form, file_path_text_box);
            object_data_set = new GenericDataSet(data_set_file_stream,
                file_delimeter,
                number_of_features,
                number_of_states_of_nature,
                number_of_samples_per_state_of_nature,
                number_of_training_samples_per_state_of_nature,
                number_of_test_samples_per_state_of_nature);
            string[] Features = object_data_set.FeaturesLable.Split(',');
            for (int i = 0; i < (Features.Length) - 1; ++i)
            {
                Cbx1.Items.Add(Features[i]);
                Cbx2.Items.Add(Features[i]);

            }
            array_states_of_nature = object_data_set.array_of_states_natures;
            MessageBox.Show("File Loaded!");
        }

        public void Apply(ref Chart c, int F1, int F2)
        {
            c.Series["Series1"].Points.Clear();
            c.Series["Series1"].ChartType = SeriesChartType.Point;
            for (int g = 0; g < array_states_of_nature.Length; g++)
            {
                c = Graphdrawing.draw(c, array_states_of_nature[g].test_samples, array_states_of_nature[g].test_samples,F1,F2);
                c.Series["Series1"].Color = Color.Red;
            }

            if (F1 == F2)
            {
                MessageBox.Show("You Must Choose Different Features!!!!!!");
            }
            else
            {

                //apply_bayesian_inference();
                // display_results(confusion_matrix_control, overall_accuracy_control);

            }
        }
        public void ApplyDrawing(ref Chart c, int F1, int F2)
        {
            //c = Graphdrawing.draw(c, array_states_of_nature[0].test_samples[F1].features_values, array_states_of_nature[1].test_samples[0].features_values);
            if (F1 == F2)
            {
                MessageBox.Show("You Must Choose Different Features!!!!!!");
            }
            else
            {

                //apply_bayesian_inference();
                // display_results(confusion_matrix_control, overall_accuracy_control);

            }
        }
        public void apply_bayesian_inference()
        {
            confusion_matrix = new int[number_of_states_of_nature, number_of_states_of_nature];
            for (int i = 0; i < array_states_of_nature.Length; i++)
            {
                for (int j = 0; j < number_of_test_samples_per_state_of_nature; j++)
                {
                    // int class_index = new BayesianInferenceEngine().classify_using_discriminent_function(array_states_of_nature, array_states_of_nature[i].test_samples[j].features_values);
                    //  confusion_matrix[i, class_index]++;
                    //confusion_matrix[i, i]++;
                }
            }
            overall_accuracy = 0;
            for (int i = 0; i < number_of_states_of_nature; i++)
            {
                overall_accuracy += confusion_matrix[i, i];
            }
            overall_accuracy /= (number_of_states_of_nature * number_of_test_samples_per_state_of_nature);
        }

        public void display_results(DataGridView dgrdv_confusion_matrix, TextBox textbox_overall_accuracy)
        {
            textbox_overall_accuracy.Text = overall_accuracy.ToString();
            DataGridView_Helpers object_data_grid_view_helpers = new DataGridView_Helpers();
            object_data_grid_view_helpers.add_grid_column("actions", "/", new DataGridViewTextBoxCell(), dgrdv_confusion_matrix);
            for (int i = 0; i < number_of_states_of_nature; i++)
            {
                object_data_grid_view_helpers.add_grid_column(array_states_of_nature[i].label, array_states_of_nature[i].label, new DataGridViewTextBoxCell(), dgrdv_confusion_matrix);
            }
            for (int i = 0; i < number_of_states_of_nature; i++)
            {
                dgrdv_confusion_matrix.Rows.Add(array_states_of_nature[i].label);
            }
            for (int i = 0; i < number_of_states_of_nature; i++)
            {
                for (int j = 0; j < number_of_states_of_nature; j++)
                {
                    dgrdv_confusion_matrix.Rows[i].Cells[j + 1].Value = confusion_matrix[i, j];
                }
            }
        }
    }
}
