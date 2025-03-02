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
                // Redirect to another form or perform additional actions
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); // Mevcut formu gizler
            if (userLoginForm == null)
            {
                userLoginForm = new UserLogin.Form1(); // Doğru namespace ve form adı kullanılır
                userLoginForm.FormClosed += (s, args) => this.Close();
            }
            userLoginForm.Show();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
