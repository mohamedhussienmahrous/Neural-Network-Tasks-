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
        GenericDataSet object_data_set;
        DataGridView confusion_matrix_control, NumberOfNeuronsInEachLayer;
        TextBox overall_accuracy_control;
        int NumberOfHiddenLayers, Epochs;
        double Eta;



        public void handle_load_data_set_button_click(Form parent_form, TextBox Epoch, TextBox Eta, TextBox NumberOfHiddenLayers,
            TextBox file_path_text_box,
            DataGridView dgrdv_confusion_matrix,
            DataGridView NumberOfNeuronsinHidden,
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
            this.Eta = double.Parse(Eta.Text.ToString());
            this.Epochs = int.Parse(Epoch.Text.ToString());
            this.NumberOfHiddenLayers = int.Parse(NumberOfHiddenLayers.Text.ToString());
            this.NumberOfNeuronsInEachLayer = NumberOfNeuronsinHidden;
            CreateHiddenLayersDGV();
            MessageBox.Show("File Loaded!");
            array_states_of_nature = object_data_set.array_of_states_natures;
            array_states_of_nature = new Normalization(array_states_of_nature).makeNormalizationalldataset();
            //  Run();
        }
        public void Run()
        {
            int[] w = GetNumberOfNeurins();
            MultiLayerPerceptron ML = new MultiLayerPerceptron(array_states_of_nature, Eta, Epochs, NumberOfHiddenLayers, w);
            ML.MLPTraining();
            double[] output = new double[array_states_of_nature.Length];
            for (int i = 0; i < array_states_of_nature.Length; ++i)
                for (int j = 0; j < array_states_of_nature[0].num_of_test_samples; ++j)
                {
                    output=ML.MLPTesting(array_states_of_nature[i].test_samples[j]);
                }
        }

        private int[] GetNumberOfNeurins()
        {
            //this.NumberOfNeuronsInEachLayer;
            int[] NF = new int[this.NumberOfHiddenLayers];
            for (int w = 0; w < this.NumberOfHiddenLayers; w++)
                NF[w] = int.Parse(this.NumberOfNeuronsInEachLayer.Rows[w].Cells[1].Value.ToString());
            return NF;
        }
        public void CreateHiddenLayersDGV()
        {
            this.NumberOfNeuronsInEachLayer.Rows.Clear();
            this.NumberOfNeuronsInEachLayer.Columns.Clear();
            DataGridView_Helpers object_data_grid_view_helpers = new DataGridView_Helpers();
            object_data_grid_view_helpers.add_grid_column("Hidden Layer Number ", "Layer Number", new DataGridViewTextBoxCell(), this.NumberOfNeuronsInEachLayer);
            object_data_grid_view_helpers.add_grid_column("Number Of Neurons", "#Neurons", new DataGridViewTextBoxCell(), this.NumberOfNeuronsInEachLayer);
            for (int i = 1; i <= this.NumberOfHiddenLayers; ++i)
                this.NumberOfNeuronsInEachLayer.Rows.Add(i.ToString());
        }
        public void display_results(DataGridView dgrdv_confusion_matrix, TextBox textbox_overall_accuracy)
        {
            //dgrdv_confusion_matrix.Rows.Clear();
            //dgrdv_confusion_matrix.Columns.Clear();
            //textbox_overall_accuracy.Text = overall_accuracy.ToString();
            //DataGridView_Helpers object_data_grid_view_helpers = new DataGridView_Helpers();
            //object_data_grid_view_helpers.add_grid_column("actions", "/", new DataGridViewTextBoxCell(), dgrdv_confusion_matrix);

            //object_data_grid_view_helpers.add_grid_column(array_states_of_nature[C1].label, array_states_of_nature[C1].label, new DataGridViewTextBoxCell(), dgrdv_confusion_matrix);
            //object_data_grid_view_helpers.add_grid_column(array_states_of_nature[C2].label, array_states_of_nature[C2].label, new DataGridViewTextBoxCell(), dgrdv_confusion_matrix);


            //dgrdv_confusion_matrix.Rows.Add(array_states_of_nature[C1].label);
            //dgrdv_confusion_matrix.Rows.Add(array_states_of_nature[C2].label);
            //for (int i = 0; i < 2; i++)
            //{
            //    for (int j = 0; j < 2; j++)
            //    {
            //        dgrdv_confusion_matrix.Rows[i].Cells[j + 1].Value = confusion_matrix[i, j];
            //    }
            //}
        }
    }
}
