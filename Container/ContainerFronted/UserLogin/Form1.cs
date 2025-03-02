using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Loginn; // UserPanel namespace'ini eklediğinizden emin olun

namespace UserLogin
{
    public partial class Form1 : Form
    {
        private Label lblLoading;
        private Timer loadingTimer;
        private int dotCount = 0;

        public Form1()
        {
            InitializeComponent();
            InitializeLoadingLabel();
            InitializeLoadingTimer();
        }

        private void InitializeLoadingLabel()
        {
            lblLoading = new Label
            {
                AutoSize = true,
                Location = new Point(10, 10),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.Red,
                Text = ""
            };
            this.Controls.Add(lblLoading);
        }

        private void InitializeLoadingTimer()
        {
            loadingTimer = new Timer();
            loadingTimer.Interval = 500; // Adjust interval for animation speed
            loadingTimer.Tick += LoadingTimer_Tick;
        }

        private void LoadingTimer_Tick(object sender, EventArgs e)
        {
            dotCount = (dotCount + 1) % 4; // Cycles through 0, 1, 2, 3
            lblLoading.Text = "Loading" + new string('.', dotCount);
        }

        private void StartLoadingAnimation()
        {
            dotCount = 0;
            lblLoading.Text = "Loading";
            loadingTimer.Start();
        }

        private async void StopLoadingAnimation()
        {
            await Task.Delay(2000); // Simulate a loading delay
            loadingTimer.Stop();
            lblLoading.Text = "";
        }

        private async Task ShowLoadingAsync()
        {
            StartLoadingAnimation();
            await Task.Delay(2000); // Simulate a loading delay
            StopLoadingAnimation();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await ShowLoadingAsync();
            ShowLoginForm();
        }

        private async void btnStaff_Click(object sender, EventArgs e)
        {
            await ShowLoadingAsync();
            ShowLoginForm();
        }

        private async void btnAdmin_Click(object sender, EventArgs e)
        {
            await ShowLoadingAsync();
            ShowLoginForm();
        }

        private void ShowLoginForm()
        {
            this.Hide(); // Current form hides
            Loginn.Form1 loginForm = new Loginn.Form1(); // Use the correct namespace and form name
            loginForm.Closed += (s, args) => this.Close();
            loginForm.Show();
        }
    }
}
