namespace AddTaskToEmp
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbxTask = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbxno = new System.Windows.Forms.ComboBox();
            this.Task = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "EmpNo";
            // 
            // cbxTask
            // 
            this.cbxTask.FormattingEnabled = true;
            this.cbxTask.Location = new System.Drawing.Point(314, 141);
            this.cbxTask.Name = "cbxTask";
            this.cbxTask.Size = new System.Drawing.Size(231, 21);
            this.cbxTask.TabIndex = 2;
            this.cbxTask.SelectedIndexChanged += new System.EventHandler(this.cbxTask_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(370, 242);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbxno
            // 
            this.cmbxno.FormattingEnabled = true;
            this.cmbxno.Location = new System.Drawing.Point(74, 141);
            this.cmbxno.Name = "cmbxno";
            this.cmbxno.Size = new System.Drawing.Size(121, 21);
            this.cmbxno.TabIndex = 4;
            this.cmbxno.SelectedIndexChanged += new System.EventHandler(this.cmbxno_SelectedIndexChanged);
            // 
            // Task
            // 
            this.Task.AutoSize = true;
            this.Task.Location = new System.Drawing.Point(311, 116);
            this.Task.Name = "Task";
            this.Task.Size = new System.Drawing.Size(31, 13);
            this.Task.TabIndex = 5;
            this.Task.Text = "Task";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AddTaskToEmp.Properties.Resources.Ekran_görüntüsü_2024_12_28_204220;
            this.ClientSize = new System.Drawing.Size(611, 408);
            this.Controls.Add(this.Task);
            this.Controls.Add(this.cmbxno);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbxTask);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Add Task To Employee";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxTask;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbxno;
        private System.Windows.Forms.Label Task;
    }
}

