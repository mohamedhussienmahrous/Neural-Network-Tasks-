using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
namespace Neural_Network_Tasks
{
    class Task_3_View_handler
    {

        public Generic_State_Of_Nature[] array_states_of_nature;
        int[,] confusion_matrix;
        double overall_accuracy;
        Normalization N;
        const int number_of_features = 4,
            number_of_states_of_nature = 3,
            number_of_samples_per_state_of_nature = 50,
            number_of_training_samples_per_state_of_nature = 30,
            number_of_test_samples_per_state_of_nature = 20;

        const char file_delimeter = ',';
        int C1, C2;
        GenericDataSet object_data_set;
        DataGridView confusion_matrix_control;
        TextBox overall_accuracy_control;
        Perceptron a;
        Least_Mean_Squarecs x;
        Linear_Perceptron l;
        PerceptronBatch B;

        public void handle_load_data_set_button_click(/*ComboBox Cbx3, ComboBox Cbx4, ComboBox Cbx1, ComboBox Cbx2,*/
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
            //for (int i = 0; i < (Features.Length) - 1; ++i)
            //{
            //    Cbx1.Items.Add(Features[i]);
            //    Cbx2.Items.Add(Features[i]);

            //}
            //array_states_of_nature = object_data_set.array_of_states_natures;
            //for (int i = 0; i < array_states_of_nature.Length; ++i)
            //{
            //    Cbx3.Items.Add(array_states_of_nature[i].label);
            //    Cbx4.Items.Add(array_states_of_nature[i].label);

            //}




            MessageBox.Show("File Loaded!");
        }

    }
}
