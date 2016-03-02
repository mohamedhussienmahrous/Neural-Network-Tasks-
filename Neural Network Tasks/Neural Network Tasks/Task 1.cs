using Patterns_Recognition___Task_1;
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
    public partial class Task_1 : Form
    {
        Task_1_View_Handler object_view_handler;
        public Task_1()
        {
            InitializeComponent();
            object_view_handler = new Task_1_View_Handler();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            object_view_handler.handle_load_data_set_button_click(comboBox1,comboBox2,this, textBox_file_path, dataGridView_confusion_matrix, textBox_overall_accuracy);
            Cursor.Current = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
         //  new Task_1_View_Handler().Apply(comboBox1.SelectedItem.ToString(),comboBox2.SelectedItem.ToString());
        }

        private void chart1_Click(object sender, EventArgs e)
        {
         
        }
    }
}
