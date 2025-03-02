namespace add_Employee
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
            this.lblName = new System.Windows.Forms.Label();
            this.lbldeptno = new System.Windows.Forms.Label();
            this.lblsalary = new System.Windows.Forms.Label();
            this.lblDeptDescription = new System.Windows.Forms.Label();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSSN = new System.Windows.Forms.TextBox();
            this.cmbxdeptno = new System.Windows.Forms.ComboBox();
            this.cmbxdepartmentname = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(104, 237);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            this.lblName.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbldeptno
            // 
            this.lbldeptno.AutoSize = true;
            this.lbldeptno.Location = new System.Drawing.Point(104, 311);
            this.lbldeptno.Name = "lbldeptno";
            this.lbldeptno.Size = new System.Drawing.Size(82, 13);
            this.lbldeptno.TabIndex = 1;
            this.lbldeptno.Text = "Department No:";
            // 
            // lblsalary
            // 
            this.lblsalary.AutoSize = true;
            this.lblsalary.Location = new System.Drawing.Point(104, 347);
            this.lblsalary.Name = "lblsalary";
            this.lblsalary.Size = new System.Drawing.Size(36, 13);
            this.lblsalary.TabIndex = 2;
            this.lblsalary.Text = "Salary";
            // 
            // lblDeptDescription
            // 
            this.lblDeptDescription.AutoSize = true;
            this.lblDeptDescription.Location = new System.Drawing.Point(106, 393);
            this.lblDeptDescription.Name = "lblDeptDescription";
            this.lblDeptDescription.Size = new System.Drawing.Size(118, 13);
            this.lblDeptDescription.TabIndex = 3;
            this.lblDeptDescription.Text = "Department Description";
            // 
            // txtSalary
            // 
            this.txtSalary.Location = new System.Drawing.Point(280, 347);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(100, 20);
            this.txtSalary.TabIndex = 6;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(621, 426);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(82, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(659, 188);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "SSN";
            // 
            // txtSSN
            // 
            this.txtSSN.Location = new System.Drawing.Point(280, 275);
            this.txtSSN.Name = "txtSSN";
            this.txtSSN.Size = new System.Drawing.Size(100, 20);
            this.txtSSN.TabIndex = 11;
            // 
            // cmbxdeptno
            // 
            this.cmbxdeptno.FormattingEnabled = true;
            this.cmbxdeptno.Location = new System.Drawing.Point(280, 311);
            this.cmbxdeptno.Name = "cmbxdeptno";
            this.cmbxdeptno.Size = new System.Drawing.Size(121, 21);
            this.cmbxdeptno.TabIndex = 12;
            this.cmbxdeptno.SelectedIndexChanged += new System.EventHandler(this.cmbxdeptno_SelectedIndexChanged);
            // 
            // cmbxdepartmentname
            // 
            this.cmbxdepartmentname.FormattingEnabled = true;
            this.cmbxdepartmentname.Location = new System.Drawing.Point(280, 393);
            this.cmbxdepartmentname.Name = "cmbxdepartmentname";
            this.cmbxdepartmentname.Size = new System.Drawing.Size(121, 21);
            this.cmbxdepartmentname.TabIndex = 13;
            this.cmbxdepartmentname.SelectedIndexChanged += new System.EventHandler(this.cmbxdepartmentname_SelectedIndexChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(280, 237);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 4;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::add_Employee.Properties.Resources.Ekran_görüntüsü_2024_12_28_140914;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbxdepartmentname);
            this.Controls.Add(this.cmbxdeptno);
            this.Controls.Add(this.txtSSN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtSalary);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblDeptDescription);
            this.Controls.Add(this.lblsalary);
            this.Controls.Add(this.lbldeptno);
            this.Controls.Add(this.lblName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lbldeptno;
        private System.Windows.Forms.Label lblsalary;
        private System.Windows.Forms.Label lblDeptDescription;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSSN;
        private System.Windows.Forms.ComboBox cmbxdeptno;
        private System.Windows.Forms.ComboBox cmbxdepartmentname;
        private System.Windows.Forms.TextBox txtName;
    }
}

