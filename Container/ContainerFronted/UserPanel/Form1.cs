using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserPanel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
        
           
        }

        private void btnSee_Click(object sender, EventArgs e)

        {
            PastOrder.Form1 form = new PastOrder.Form1();
            form.Show();
            this.Hide();
        }
    }
}
