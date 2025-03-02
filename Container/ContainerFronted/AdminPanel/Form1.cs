using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using add_Employee;
using DeleteEmp;
using DeletePerson;
using AddPerson;
using AddTaskToEmp;
using ProductAdd;

namespace AdminPanel
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
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            StartLoadingAnimation();

            // Create an instance of the add_Employee class
            this.Hide();
            add_Employee.Form1 addEmployeeForm = new add_Employee.Form1();
            addEmployeeForm.Show();
            addEmployeeForm.Closed += (s, args) => this.Close();
            addEmployeeForm.Show();

            StopLoadingAnimation();
            // Add your logic here
        }


        private void btnDeleteStaff_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeleteEmp.Form1 DeleteEmp = new DeleteEmp.Form1();
            DeleteEmp.Show();
            DeleteEmp.FormClosed += (s, args) => this.Close();
            DeleteEmp.Show();
            StartLoadingAnimation();
            StopLoadingAnimation();
            // Add your logic here
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddPerson.Form1 AddPersonForm = new AddPerson.Form1();
            AddPersonForm.Show();
            AddPersonForm.FormClosed += (s, args) => this.Close();
            AddPersonForm.Show();
            StartLoadingAnimation();
            StopLoadingAnimation();
            // Add your logic here
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            
           
            StartLoadingAnimation();
            StopLoadingAnimation();
            this.Hide();
            DeletePerson.Form1 DeletePersonForm = new DeletePerson.Form1();
            DeletePersonForm.Show();
            DeletePersonForm.FormClosed += (s, args) => this.Close();
            DeletePersonForm.Show();
            // Add your logic here
        }

        private void btnTask_Click(object sender, EventArgs e)
        {
           
           
            StartLoadingAnimation();
            StopLoadingAnimation();
            AddTaskToEmp.Form1 AddTask = new AddTaskToEmp.Form1();
            AddTask.Show();
            AddTask.FormClosed += (s, args) => this.Close();
            AddTask.Show();
            this.Hide();
            // Add your logic here
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ProductAdd.Form1 ProductAddForm = new ProductAdd.Form1();
            ProductAddForm.Show();
            this.Hide();
            StartLoadingAnimation();
            StopLoadingAnimation();
            // Add your logic here
           
        }

    }
}
