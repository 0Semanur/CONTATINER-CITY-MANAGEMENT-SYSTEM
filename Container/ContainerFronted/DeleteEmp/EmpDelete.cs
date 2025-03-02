using System;
using System.Data;
using System.Data.SqlClient;

namespace DeleteEmp
{
    internal class EmpDelete
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

            using (SqlCommand command = new SqlCommand("SELECT * FROM emp", _connection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable employeeTable = new DataTable();
                    adapter.Fill(employeeTable);
                    return employeeTable;
                }
            }
        }

        public void DeleteEmployee(Emp employee)
        {
            ConnectionControl();

            using (SqlCommand command1 = new SqlCommand("DELETE FROM emptask WHERE empno = @empno", _connection))
            {
                command1.Parameters.AddWithValue("@empno", employee.empno);
                command1.ExecuteNonQuery();
            }

            using (SqlCommand command2 = new SqlCommand("DELETE FROM emp WHERE empno = @empno", _connection))
            {
                command2.Parameters.AddWithValue("@empno", employee.empno);
                command2.ExecuteNonQuery();
            }

            _connection.Close();
        }
    }

    public class Emp
    {
        public int empno { get; set; }
    }
}
