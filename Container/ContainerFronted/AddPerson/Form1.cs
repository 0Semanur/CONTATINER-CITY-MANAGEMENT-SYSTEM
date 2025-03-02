using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AddPerson
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadData(); // Call LoadData method in the constructor
        }

        // Method to retrieve data from the PERSON table
        public DataTable GetAll2()
        {
            SqlConnection connection = new SqlConnection(@"server=DESKTOP-KD63QHB\SQLEXPRESS;initial catalog=Container;integrated security=true");
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand("Select * from PersonReceivingService", connection);
            SqlDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            reader.Close();
            connection.Close();
            return dataTable;
        }

        // Method to load data into the DataGridView
        private void LoadData()
        {
            dataGridView1.DataSource = GetAll2();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Your code here
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string ssn = txtssn.Text; // Keep ssn as string
            if (!int.TryParse(txtcntno.Text, out int containerNo))
            {
                MessageBox.Show("Invalid container number. Please enter a valid integer.");
                return;
            }

            AddPersonReceivingService(ssn, containerNo);
            LoadData(); // Refresh data after adding a person receiving service
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Your code here
        }

        private void txtssn_TextChanged(object sender, EventArgs e)
        {
            // Your code here
        }

        private void txtcntno_TextChanged(object sender, EventArgs e)
        {
            // Your code here
        }

        private void AddPersonReceivingService(string ssn, int containerNo)
        {
            string connectionString = @"server=DESKTOP-KD63QHB\SQLEXPRESS;initial catalog=Container;integrated security=true"; // Correct format for connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("addPersonReceivingService", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ssn", ssn);
                command.Parameters.AddWithValue("@containerNo", containerNo);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("PersonReceivingService record added successfully.");
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // Unique constraint error number
                    {
                        MessageBox.Show("Error: Duplicate key. The record already exists in PersonReceivingService.");
                    }
                    else
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}
