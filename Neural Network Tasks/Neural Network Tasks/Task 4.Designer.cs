namespace Neural_Network_Tasks
{
    partial class Task_4
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
            this.label_overall_accuracy = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label_confusion_matrix = new System.Windows.Forms.Label();
            this.dataGridView_confusion_matrix = new System.Windows.Forms.DataGridView();
            this.textBox_overall_accuracy = new System.Windows.Forms.TextBox();
            this.textBox_file_path = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.NumberOfClusters = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Eta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Epoch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ReadFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.textBox_mse = new System.Windows.Forms.TextBox();
            this.mse = new System.Windows.Forms.Label();
            this.Iris_setosa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iris_versicolor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iris_virginica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_confusion_matrix)).BeginInit();
            this.SuspendLayout();
            // 
            // label_overall_accuracy
            // 
            this.label_overall_accuracy.AutoSize = true;
            this.label_overall_accuracy.Location = new System.Drawing.Point(454, 353);
            this.label_overall_accuracy.Name = "label_overall_accuracy";
            this.label_overall_accuracy.Size = new System.Drawing.Size(88, 13);
            this.label_overall_accuracy.TabIndex = 36;
            this.label_overall_accuracy.Text = "Overall Accuracy";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(577, 181);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 23);
            this.button2.TabIndex = 34;
            this.button2.Text = "Apply";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label_confusion_matrix
            // 
            this.label_confusion_matrix.AutoSize = true;
            this.label_confusion_matrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_confusion_matrix.Location = new System.Drawing.Point(30, 170);
            this.label_confusion_matrix.Name = "label_confusion_matrix";
            this.label_confusion_matrix.Size = new System.Drawing.Size(127, 20);
            this.label_confusion_matrix.TabIndex = 33;
            this.label_confusion_matrix.Text = "Confusion Matrix";
            // 
            // dataGridView_confusion_matrix
            // 
            this.dataGridView_confusion_matrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_confusion_matrix.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Iris_setosa,
            this.Iris_versicolor,
            this.Iris_virginica});
            this.dataGridView_confusion_matrix.Location = new System.Drawing.Point(24, 197);
            this.dataGridView_confusion_matrix.Name = "dataGridView_confusion_matrix";
            this.dataGridView_confusion_matrix.Size = new System.Drawing.Size(390, 176);
            this.dataGridView_confusion_matrix.TabIndex = 32;
            // 
            // textBox_overall_accuracy
            // 
            this.textBox_overall_accuracy.Location = new System.Drawing.Point(548, 353);
            this.textBox_overall_accuracy.Name = "textBox_overall_accuracy";
            this.textBox_overall_accuracy.Size = new System.Drawing.Size(133, 20);
            this.textBox_overall_accuracy.TabIndex = 31;
            // 
            // textBox_file_path
            // 
            this.textBox_file_path.Location = new System.Drawing.Point(548, 32);
            this.textBox_file_path.Name = "textBox_file_path";
            this.textBox_file_path.Size = new System.Drawing.Size(169, 20);
            this.textBox_file_path.TabIndex = 30;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(393, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 23);
            this.button1.TabIndex = 29;
            this.button1.Text = "Select Data set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NumberOfClusters
            // 
            this.NumberOfClusters.Location = new System.Drawing.Point(254, 130);
            this.NumberOfClusters.Name = "NumberOfClusters";
            this.NumberOfClusters.Size = new System.Drawing.Size(100, 20);
            this.NumberOfClusters.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 20);
            this.label3.TabIndex = 27;
            this.label3.Text = "Number of Clusters";
            // 
            // Eta
            // 
            this.Eta.Location = new System.Drawing.Point(254, 83);
            this.Eta.Name = "Eta";
            this.Eta.Size = new System.Drawing.Size(100, 20);
            this.Eta.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Learning Rate";
            // 
            // Epoch
            // 
            this.Epoch.Location = new System.Drawing.Point(254, 32);
            this.Epoch.Name = "Epoch";
            this.Epoch.Size = new System.Drawing.Size(100, 20);
            this.Epoch.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Epoch";
            // 
            // ReadFileDialog
            // 
            this.ReadFileDialog.FileName = "openFileDialog1";
            // 
            // textBox_mse
            // 
            this.textBox_mse.Location = new System.Drawing.Point(614, 82);
            this.textBox_mse.Name = "textBox_mse";
            this.textBox_mse.Size = new System.Drawing.Size(100, 20);
            this.textBox_mse.TabIndex = 40;
            // 
            // mse
            // 
            this.mse.AutoSize = true;
            this.mse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mse.Location = new System.Drawing.Point(420, 80);
            this.mse.Name = "mse";
            this.mse.Size = new System.Drawing.Size(113, 20);
            this.mse.TabIndex = 39;
            this.mse.Text = "Mse Threshold";
            // 
            // Iris_setosa
            // 
            this.Iris_setosa.HeaderText = "Iris-setosa";
            this.Iris_setosa.Name = "Iris_setosa";
            // 
            // Iris_versicolor
            // 
            this.Iris_versicolor.HeaderText = "Iris-versicolor";
            this.Iris_versicolor.Name = "Iris_versicolor";
            // 
            // Iris_virginica
            // 
            this.Iris_virginica.HeaderText = "Iris-virginica";
            this.Iris_virginica.Name = "Iris_virginica";
            // 
            // Task_4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 379);
            this.Controls.Add(this.textBox_mse);
            this.Controls.Add(this.mse);
            this.Controls.Add(this.label_overall_accuracy);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label_confusion_matrix);
            this.Controls.Add(this.dataGridView_confusion_matrix);
            this.Controls.Add(this.textBox_overall_accuracy);
            this.Controls.Add(this.textBox_file_path);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NumberOfClusters);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Eta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Epoch);
            this.Controls.Add(this.label1);
            this.Name = "Task_4";
            this.Text = "Task_4";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_confusion_matrix)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_overall_accuracy;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label_confusion_matrix;
        private System.Windows.Forms.DataGridView dataGridView_confusion_matrix;
        private System.Windows.Forms.TextBox textBox_overall_accuracy;
        private System.Windows.Forms.TextBox textBox_file_path;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox NumberOfClusters;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Eta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Epoch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog ReadFileDialog;
        private System.Windows.Forms.TextBox textBox_mse;
        private System.Windows.Forms.Label mse;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iris_setosa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iris_versicolor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iris_virginica;
    }
}