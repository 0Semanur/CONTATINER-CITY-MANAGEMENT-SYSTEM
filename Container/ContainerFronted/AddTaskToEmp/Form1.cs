using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TaskView;

namespace AddTaskToEmp
{
    public partial class Form1 : Form
    {
        private readonly SqlConnection _connection = new SqlConnection(@"server=DESKTOP-KD63QHB\SQLEXPRESS;initial catalog=Container;integrated security=true");

        public Form1()
        {
            InitializeComponent();
            LoadEmpNos();
            LoadTasks();
        }

        private void LoadEmpNos()
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT empno FROM emp", _connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbxno.Items.Add(reader["empno"].ToString());
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadTasks()
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT task FROM Emptask", _connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbxTask.Items.Add(reader["task"].ToString());
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO empTask (empno, task) VALUES (@empno, @task)", _connection);
                cmd.Parameters.AddWithValue("@empno", cmbxno.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@task", cbxTask.SelectedItem.ToString());
                cmd.ExecuteNonQuery();
                _connection.Close();
                MessageBox.Show("Task added successfully!");
                TaskView.Form1 form1 = new TaskView.Form1();
                form1.Show();
                this.Hide();

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cbxTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Görev seçimi değiştirildiğinde yapılacak işlemler
        }

        private void cmbxno_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Çalışan numarası seçimi değiştirildiğinde yapılacak işlemler
        }
    }
}
