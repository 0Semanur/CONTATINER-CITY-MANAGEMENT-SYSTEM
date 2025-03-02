namespace TaskView
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.employeeTasksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.containerDataSet = new TaskView.ContainerDataSet();
            this.employeeTasksTableAdapter = new TaskView.ContainerDataSetTableAdapters.EmployeeTasksTableAdapter();
            this.containerDataSet1 = new TaskView.ContainerDataSet1();
            this.pastOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pastOrderTableAdapter = new TaskView.ContainerDataSet1TableAdapters.pastOrderTableAdapter();
            this.containerDataSet2 = new TaskView.ContainerDataSet2();
            this.containerDataSet2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.containerDataSet3 = new TaskView.ContainerDataSet3();
            this.containerDataSet3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeTasksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.containerDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.containerDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pastOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.containerDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.containerDataSet2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.containerDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.containerDataSet3BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(743, 425);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // employeeTasksBindingSource
            // 
            this.employeeTasksBindingSource.DataMember = "EmployeeTasks";
            this.employeeTasksBindingSource.DataSource = this.containerDataSet;
            // 
            // containerDataSet
            // 
            this.containerDataSet.DataSetName = "ContainerDataSet";
            this.containerDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // employeeTasksTableAdapter
            // 
            this.employeeTasksTableAdapter.ClearBeforeFill = true;
            // 
            // containerDataSet1
            // 
            this.containerDataSet1.DataSetName = "ContainerDataSet1";
            this.containerDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pastOrderBindingSource
            // 
            this.pastOrderBindingSource.DataMember = "pastOrder";
            this.pastOrderBindingSource.DataSource = this.containerDataSet1;
            // 
            // pastOrderTableAdapter
            // 
            this.pastOrderTableAdapter.ClearBeforeFill = true;
            // 
            // containerDataSet2
            // 
            this.containerDataSet2.DataSetName = "ContainerDataSet2";
            this.containerDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // containerDataSet2BindingSource
            // 
            this.containerDataSet2BindingSource.DataSource = this.containerDataSet2;
            this.containerDataSet2BindingSource.Position = 0;
            // 
            // containerDataSet3
            // 
            this.containerDataSet3.DataSetName = "ContainerDataSet3";
            this.containerDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // containerDataSet3BindingSource
            // 
            this.containerDataSet3BindingSource.DataSource = this.containerDataSet3;
            this.containerDataSet3BindingSource.Position = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeTasksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.containerDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.containerDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pastOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.containerDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.containerDataSet2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.containerDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.containerDataSet3BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private ContainerDataSet containerDataSet;
        private System.Windows.Forms.BindingSource employeeTasksBindingSource;
        private ContainerDataSetTableAdapters.EmployeeTasksTableAdapter employeeTasksTableAdapter;
        private System.Windows.Forms.BindingSource containerDataSet3BindingSource;
        private ContainerDataSet3 containerDataSet3;
        private ContainerDataSet1 containerDataSet1;
        private System.Windows.Forms.BindingSource pastOrderBindingSource;
        private ContainerDataSet1TableAdapters.pastOrderTableAdapter pastOrderTableAdapter;
        private ContainerDataSet2 containerDataSet2;
        private System.Windows.Forms.BindingSource containerDataSet2BindingSource;
    }
}

