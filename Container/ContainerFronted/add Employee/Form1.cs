using add_Employee.add_Employee;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace add_Employee
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Çalışanları göster
            DisplayEmployees();
            // Load department numbers into cmbxdeptno
            LoadDepartmentNumbers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AddEmployeeDal addEmployeeDal = new AddEmployeeDal();

                // Create a new instance of Emp and set its properties from the text boxes
                Emp newEmployee = new Emp
                {
                    ename = txtName.Text,
                    salary = float.Parse(txtSalary.Text),
                    ssn = txtSSN.Text,
                    deptDescription = cmbxdepartmentname.Text,
                    deptno = Convert.ToInt32(cmbxdeptno.Text),
                };

                // Call AddEmployee method to add the new employee
                addEmployeeDal.AddEmployee(newEmployee);

                MessageBox.Show("Çalışan başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Çalışanları göster
                DisplayEmployees();

                // Calculate and display total and average salary
                DataTable employees = addEmployeeDal.GetEmployees();
                decimal totalSalary = 0;
                decimal averageSalary = 0;
                if (employees.Rows.Count > 0)
                {
                    foreach (DataRow row in employees.Rows)
                    {
                        totalSalary += Convert.ToDecimal(row["salary"]);
                    }
                    averageSalary = totalSalary / employees.Rows.Count;
                }
                MessageBox.Show($"Toplam Maaş: {totalSalary}\nOrtalama Maaş: {averageSalary}", "Maaş Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayEmployees()
        {
            AddEmployeeDal addEmployeeDal = new AddEmployeeDal();
            DataTable employees = addEmployeeDal.GetEmployees();
            dataGridView1.DataSource = employees;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbxdeptno_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Load department name based on selected department number
            LoadDepartmentName(Convert.ToInt32(cmbxdeptno.SelectedItem));
        }

        private void cmbxdepartmentname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadDepartmentNumbers()
        {
            string connectionString = @"server=DESKTOP-KD63QHB\SQLEXPRESS;initial catalog=Container;integrated security=true";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT deptno FROM department", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cmbxdeptno.Items.Add(reader["deptno"].ToString());
                }
                reader.Close();
            }
        }

        private void LoadDepartmentName(int deptno)
        {
            string connectionString = @"server=DESKTOP-KD63QHB\SQLEXPRESS;initial catalog=Container;integrated security=true";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT deptname FROM department WHERE deptno = @deptno", connection);
                command.Parameters.AddWithValue("@deptno", deptno);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    cmbxdepartmentname.Items.Clear();
                    cmbxdepartmentname.Items.Add(reader["deptname"].ToString());
                    cmbxdepartmentname.SelectedIndex = 0;
                }
                reader.Close();
            }
        }
    }
}
