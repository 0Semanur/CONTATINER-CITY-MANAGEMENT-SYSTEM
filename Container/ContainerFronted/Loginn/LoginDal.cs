using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loginn
{
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsStaff { get; set; }
    }

    public class LoginDal
    {
        SqlConnection _connection = new SqlConnection(@"server=DESKTOP-KD63QHB\SQLEXPRESS;initial catalog=Container;integrated security=true");

        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public bool Login(Login login)
        {
            ConnectionControl();

            SqlCommand command;

            if (login.IsStaff)
            {
                // Staff login: empno as Username and ssn as Password
                command = new SqlCommand(@"
                SELECT e.empno, e.ssN, e.ename, p.Pname
                FROM emp e
                JOIN person p ON e.ssN = p.ssN
                WHERE e.ssN = @ssn AND e.empno = @empno", _connection);
                command.Parameters.AddWithValue("@ssn", login.Password);
                command.Parameters.AddWithValue("@empno", login.Username);

            }
            else
            {
                // Normal login: ssn as Username and containerNo as Password
                command = new SqlCommand(@"
            SELECT p.ssn, prs.containerNo
            FROM person p
            JOIN PersonReceivingService prs ON p.ssn = prs.ssn
            WHERE prs.containerNo = @containerNo AND p.ssn = @ssn", _connection);
                command.Parameters.AddWithValue("@containerNo", login.Username);
                command.Parameters.AddWithValue("@ssn", login.Password);
            }

            SqlDataReader reader = command.ExecuteReader();

            bool isAuthenticated = reader.Read();
            reader.Close();
            _connection.Close();

            if (isAuthenticated)
            {
                // Hide the current form and show the appropriate form based on the user type
                if (login.IsStaff)
                {
                    EmployeePanel.Form1 form = new EmployeePanel.Form1();
                    form.Show();
                }
                else
                {
                    UserPanel.Form1 form = new UserPanel.Form1();
                    form.Show();
                }
            }

            return isAuthenticated;
        }
    }
}
