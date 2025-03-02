using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TaskView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                containerDataSet.EnforceConstraints = false; // Kısıtlamaları geçici olarak devre dışı bırak
                FillEmployeeTasksGrid();
                containerDataSet.EnforceConstraints = true; // Kısıtlamaları tekrar etkinleştir
            }
            catch (ConstraintException ex)
            {
                MessageBox.Show("Kısıtlamalar etkinleştirilemedi: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void FillEmployeeTasksGrid()
        {
            string connectionString = @"server=DESKTOP-KD63QHB\SQLEXPRESS;initial catalog=Container;integrated security=true";
            string query = "SELECT empno, ename, salary, deptno, hireDate, deptDescription, task FROM EmployeeTasks";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        
        }
    }
}
