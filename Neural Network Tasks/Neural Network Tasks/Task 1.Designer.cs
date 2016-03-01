namespace Neural_Network_Tasks
{
    partial class Task_1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label_overall_accuracy = new System.Windows.Forms.Label();
            this.label_confusion_matrix = new System.Windows.Forms.Label();
            this.dataGridView_confusion_matrix = new System.Windows.Forms.DataGridView();
            this.textBox_overall_accuracy = new System.Windows.Forms.TextBox();
            this.textBox_file_path = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_confusion_matrix)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(339, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Select Data set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_overall_accuracy
            // 
            this.label_overall_accuracy.AutoSize = true;
            this.label_overall_accuracy.Location = new System.Drawing.Point(114, 386);
            this.label_overall_accuracy.Name = "label_overall_accuracy";
            this.label_overall_accuracy.Size = new System.Drawing.Size(88, 13);
            this.label_overall_accuracy.TabIndex = 9;
            this.label_overall_accuracy.Text = "Overall Accuracy";
            // 
            // label_confusion_matrix
            // 
            this.label_confusion_matrix.AutoSize = true;
            this.label_confusion_matrix.Location = new System.Drawing.Point(114, 211);
            this.label_confusion_matrix.Name = "label_confusion_matrix";
            this.label_confusion_matrix.Size = new System.Drawing.Size(85, 13);
            this.label_confusion_matrix.TabIndex = 8;
            this.label_confusion_matrix.Text = "Confusion Matrix";
            // 
            // dataGridView_confusion_matrix
            // 
            this.dataGridView_confusion_matrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_confusion_matrix.Location = new System.Drawing.Point(117, 227);
            this.dataGridView_confusion_matrix.Name = "dataGridView_confusion_matrix";
            this.dataGridView_confusion_matrix.Size = new System.Drawing.Size(481, 150);
            this.dataGridView_confusion_matrix.TabIndex = 7;
            // 
            // textBox_overall_accuracy
            // 
            this.textBox_overall_accuracy.Location = new System.Drawing.Point(220, 383);
            this.textBox_overall_accuracy.Name = "textBox_overall_accuracy";
            this.textBox_overall_accuracy.Size = new System.Drawing.Size(378, 20);
            this.textBox_overall_accuracy.TabIndex = 5;
            // 
            // textBox_file_path
            // 
            this.textBox_file_path.Location = new System.Drawing.Point(117, 27);
            this.textBox_file_path.Name = "textBox_file_path";
            this.textBox_file_path.Size = new System.Drawing.Size(169, 20);
            this.textBox_file_path.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(117, 102);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(141, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(339, 102);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(140, 21);
            this.comboBox2.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(114, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Select the Two Feature First";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(339, 171);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Apply";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(123, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Write The Number of Epoch";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(339, 145);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(140, 20);
            this.textBox1.TabIndex = 15;
            // 
            // Task_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 416);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label_overall_accuracy);
            this.Controls.Add(this.label_confusion_matrix);
            this.Controls.Add(this.dataGridView_confusion_matrix);
            this.Controls.Add(this.textBox_overall_accuracy);
            this.Controls.Add(this.textBox_file_path);
            this.Controls.Add(this.button1);
            this.Name = "Task_1";
            this.Text = "Task 1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_confusion_matrix)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_overall_accuracy;
        private System.Windows.Forms.Label label_confusion_matrix;
        private System.Windows.Forms.DataGridView dataGridView_confusion_matrix;
        private System.Windows.Forms.TextBox textBox_overall_accuracy;
        private System.Windows.Forms.TextBox textBox_file_path;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
    }
}