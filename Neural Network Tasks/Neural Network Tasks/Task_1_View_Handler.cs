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
        int C1, C2;
        GenericDataSet object_data_set;
        DataGridView confusion_matrix_control;
        TextBox overall_accuracy_control;
        Perceptron a;
        public void handle_load_data_set_button_click(ComboBox Cbx3, ComboBox Cbx4,ComboBox Cbx1, ComboBox Cbx2,
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
            for (int i = 0; i < array_states_of_nature.Length; ++i)
            {
                Cbx3.Items.Add(array_states_of_nature[i].label);
                Cbx4.Items.Add(array_states_of_nature[i].label);

            }
                MessageBox.Show("File Loaded!");
        }















        public double[] Apply(ref Chart c, int F1, int F2, int Class1,int class2,TextBox lamda,TextBox Epoch)
        {
            double[] wieg = null;
            C1 = Class1;
            C2 = class2;
            if (F1 == F2||Class1==class2)
            {
                MessageBox.Show("You Must Choose Different Features Or Classes!!!!!!");
            }
            else
            {
                Normalization N = new Normalization(array_states_of_nature, Class1, class2, F1, F2);
                Generic_State_Of_Nature[] outnorm = N.makeNormalization();
                ApplyDrawing(ref c, F1, F2,Class1,class2);
                a = new Perceptron(outnorm, 1, Class1, class2, F1, F2, int.Parse(Epoch.Text.ToString()), double.Parse(lamda.Text.ToString()));
                wieg = a.Training();
                confusion_matrix = new int[2, 2];

                for (int j = 0; j < number_of_test_samples_per_state_of_nature; j++)
                {
                    int class_index = a.testing(outnorm[Class1].test_samples[j], F1, F2);
                    if (class_index >= 0.0)
                        confusion_matrix[0, 0]++;
                    else confusion_matrix[0, 1]++;
                    }
                    for (int j = 0; j < number_of_test_samples_per_state_of_nature; j++)
                    {
                        int class_index = a.testing(outnorm[class2].test_samples[j], F1, F2);
                        if (class_index < 0.0)
                            confusion_matrix[1, 1]++;
                        else confusion_matrix[1, 0]++;
                        //confusion_matrix[1, class_index]++;
                        //confusion_matrix[i, i]++;
                    } 
                overall_accuracy = 0;
                for (int i = 0; i < 2; i++)
                {
                    overall_accuracy += confusion_matrix[i, i];
                }
                overall_accuracy /= (2 * number_of_test_samples_per_state_of_nature);
                overall_accuracy *= 100;
                display_results(confusion_matrix_control, overall_accuracy_control);
                Graphdrawing.drawline("Line",ref c, a.Bias, a.Weights);

                


            }
           
            return wieg;
        }
        public void ApplyDrawing(ref Chart c, int F1, int F2,int C1,int C2)
        {
                c.Series.Clear();
                c.Series.Add("Line");
               for (int cl = 0; cl < array_states_of_nature.Length; cl++)
                {
                    c.Series.Add(array_states_of_nature[cl].label);
               } 
            for (int S = 0; S < array_states_of_nature[C1].test_samples.Length;++S )
                        c = Graphdrawing.DrawSample(c, array_states_of_nature[C1].test_samples[S], F1, F2, array_states_of_nature[C1].label);
                     for (int T=0;T<array_states_of_nature[C1].training_samples.Length;++T)
                         c = Graphdrawing.DrawSample(c, array_states_of_nature[C1].training_samples[T], F1, F2, array_states_of_nature[C1].label);

                     for (int S = 0; S < array_states_of_nature[C2].test_samples.Length; ++S)
                         c = Graphdrawing.DrawSample(c, array_states_of_nature[C2].test_samples[S], F1, F2, array_states_of_nature[C2].label);
                     for (int T = 0; T < array_states_of_nature[C2].training_samples.Length; ++T)
                         c = Graphdrawing.DrawSample(c, array_states_of_nature[C2].training_samples[T], F1, F2, array_states_of_nature[C2].label);
            
               //}
                     c.Series["Line"].Color = Color.Orange;
                c.Series[array_states_of_nature[0].label].Color = Color.Green;
                c.Series[array_states_of_nature[1].label].Color = Color.Red;
                c.Series[array_states_of_nature[2].label].Color = Color.Blue;
                c.Series["Line"].ChartType = SeriesChartType.Line;
                c.Series[array_states_of_nature[0].label].ChartType = SeriesChartType.Point;
                c.Series[array_states_of_nature[1].label].ChartType = SeriesChartType.Point;
                c.Series[array_states_of_nature[2].label].ChartType = SeriesChartType.Point;

            
        }
        public void apply_bayesian_inference()
        {
            
        }

        public void display_results(DataGridView dgrdv_confusion_matrix, TextBox textbox_overall_accuracy)
        {
            dgrdv_confusion_matrix.Rows.Clear();
            dgrdv_confusion_matrix.Columns.Clear();
            textbox_overall_accuracy.Text = overall_accuracy.ToString();
            DataGridView_Helpers object_data_grid_view_helpers = new DataGridView_Helpers();
            object_data_grid_view_helpers.add_grid_column("actions", "/", new DataGridViewTextBoxCell(), dgrdv_confusion_matrix);
           
                object_data_grid_view_helpers.add_grid_column(array_states_of_nature[C1].label, array_states_of_nature[C1].label, new DataGridViewTextBoxCell(), dgrdv_confusion_matrix);
                object_data_grid_view_helpers.add_grid_column(array_states_of_nature[C2].label, array_states_of_nature[C2].label, new DataGridViewTextBoxCell(), dgrdv_confusion_matrix);
            

                dgrdv_confusion_matrix.Rows.Add(array_states_of_nature[C1].label);
                dgrdv_confusion_matrix.Rows.Add(array_states_of_nature[C2].label);            
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    dgrdv_confusion_matrix.Rows[i].Cells[j + 1].Value = confusion_matrix[i, j];
                }
            }
        }
    }
}
