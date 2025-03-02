using System.Data;
using System.Data.SqlClient;

namespace add_Employee.add_Employee
{
    public class AddEmployeeDal
    {
        private string connectionString = @"server=DESKTOP-KD63QHB\SQLEXPRESS;initial catalog=Container;integrated security=true";

        // Method to add a new employee
        public void AddEmployee(Emp employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("addEmp", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@empname", employee.ename);
                command.Parameters.AddWithValue("@deptno", employee.deptno);
                command.Parameters.AddWithValue("@salary", employee.salary);
                command.Parameters.AddWithValue("@ssn", employee.ssn); // Added ssn parameter
                command.Parameters.AddWithValue("@deptdecription", employee.deptDescription);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Method to retrieve all employees
        public DataTable GetEmployees()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM emp", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
    }
}


public class Emp
    {
        public string ename { get; set; }
        public int deptno { get; set; }
        public float salary { get; set; }
        public string ssn {  get; set; }
        public string deptDescription { get; set; }
    }

