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

            SqlCommand command = new SqlCommand(@"
        SELECT p.ssn, prs.containerNo
        FROM person p
        JOIN PersonReceivingService prs ON p.ssn = prs.ssn
        WHERE prs.containerNo = @containerNo AND p.ssn = @ssn", _connection);

            string containerNo = login.Password;
            string ssn = login.Username;

            command.Parameters.AddWithValue("@containerNo", containerNo);
            command.Parameters.AddWithValue("@ssn", ssn);

            SqlDataReader reader = command.ExecuteReader();

            bool isAuthenticated = reader.Read();
            reader.Close();
            _connection.Close();

            return isAuthenticated;
        }






    }
}
