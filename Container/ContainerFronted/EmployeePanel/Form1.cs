using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskView;

namespace EmployeePanel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            TaskView.Form1 taskview = new TaskView.Form1();
            taskview.Show();
            taskview.FormClosed += (s, args) => this.Close();
            taskview.Show();
        }
    }
}
