using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserLogin; // UserLogin namespace'ini eklediğinizden emin olun

namespace Loginn
{
    public partial class Form1 : Form
    {
        private UserLogin.Form1 userLoginForm; // Önceki formu saklamak için doğru türü kullanın

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            LoginDal dal = new LoginDal();
            Login login = new Login { Username = username, Password = password };
            bool isAuthenticated = dal.Login(login);

            if (isAuthenticated)
            {
                MessageBox.Show("Login successful!");
               
                this.Hide();
                // Redirect to another form or perform additional actions
                UserPanel.Form1 Form = new UserPanel.Form1();
                Form.Show(); Form.Closed += (s, args) => this.Close();
                Form.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

       

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
