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
    public partial class Task3 : Form
    {
        Task_3_View_handler object_view_handler;

        public Task3()
        {
            
            InitializeComponent();
            object_view_handler = new Task_3_View_handler();
            chart1.Series.Clear();
            chart1.Visible = false;
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            object_view_handler.handle_load_data_set_button_click( this,Epoch,Eta,NumberOfHidden, textBox_file_path, dataGridView_confusion_matrix,NNlayers, textBox_overall_accuracy);

        }

        private void textBox_file_path_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            object_view_handler.Run();
        }
    }
}
