using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DeletePerson
{
    internal class DeletePerson
    {
        private readonly SqlConnection _connection = new SqlConnection(@"server=DESKTOP-KD63QHB\SQLEXPRESS;initial catalog=Container;integrated security=true");

        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public DataTable GetEmployees()
        {
            ConnectionControl();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Person", _connection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable employeeTable = new DataTable();
                    adapter.Fill(employeeTable);
                    return employeeTable;
                }
            }
        }
        public void DeletePersonBySSN(string ssn)
        {
            try
            {
                ConnectionControl();

                using (SqlCommand command = new SqlCommand("DELETE FROM Person WHERE ssN = @ssN", _connection))
                {
                    command.Parameters.AddWithValue("@ssN", ssn);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }


    }
}


