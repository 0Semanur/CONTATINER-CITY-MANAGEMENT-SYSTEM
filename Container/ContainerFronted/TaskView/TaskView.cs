using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskView
{

    public class EmployeeTasksForm : Form
    {
        private DataGridView dataGridView;

        public EmployeeTasksForm()
        {
            InitializeComponents();
            LoadEmployeeTasks();
        }

        private void InitializeComponents()
        {
            this.dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            this.Controls.Add(dataGridView);
            this.Text = "Employee Tasks";
            this.Size = new System.Drawing.Size(800, 600);
        }

        private void LoadEmployeeTasks()
        {
            string connectionString = @"server=DESKTOP-KD63QHB\SQLEXPRESS;initial catalog=Container;integrated security=true";
            string query = @"
            CREATE VIEW EmployeeTasks AS
            SELECT 
                e.empno,
                e.ename,
                e.salary,
                e.deptno,
                e.hireDate,
                e.deptDescription,
                et.task
            FROM 
                emp e
            JOIN 
                Emptask et ON e.empno = et.empno;

            SELECT * FROM EmployeeTasks;
        ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView.DataSource = table;
            }
        }
    }
}
