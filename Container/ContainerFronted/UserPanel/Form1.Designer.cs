namespace UserPanel
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnSee = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.BackgroundImage = global::UserPanel.Properties.Resources.Ekran_görüntüsü_2024_12_28_203809;
            this.btnCreate.Location = new System.Drawing.Point(130, 145);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(156, 56);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create Order";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnSee
            // 
            this.btnSee.BackgroundImage = global::UserPanel.Properties.Resources.Ekran_görüntüsü_2024_12_28_203809;
            this.btnSee.Location = new System.Drawing.Point(413, 145);
            this.btnSee.Name = "btnSee";
            this.btnSee.Size = new System.Drawing.Size(156, 56);
            this.btnSee.TabIndex = 1;
            this.btnSee.Text = "See My Past Order";
            this.btnSee.UseVisualStyleBackColor = true;
            this.btnSee.Click += new System.EventHandler(this.btnSee_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UserPanel.Properties.Resources.Ekran_görüntüsü_2024_12_28_203809;
            this.ClientSize = new System.Drawing.Size(775, 450);
            this.Controls.Add(this.btnSee);
            this.Controls.Add(this.btnCreate);
            this.Name = "Form1";
            this.Text = "User Panel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnSee;
    }
}

