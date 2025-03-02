using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductAdd;
using System.Windows.Forms;

namespace ProductAdd
{
    public class ProductDal
    {
        SqlConnection _connection = new SqlConnection(@"server=DESKTOP-KD63QHB\SQLEXPRESS;initial catalog=Container;integrated security=true");

        public List<Product> GetAll()
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from PRODUCTS", _connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                Product product = new Product
                {
                    ProductId = Convert.ToDecimal(reader["ProductID"]),
                    ProductName = reader["ProductName"].ToString(),
                    Descriptions = reader["Descriptions"].ToString(),
                    StockQuantity = Convert.ToInt32(reader["StockQuantity"])
                };
                products.Add(product);
            }
            reader.Close();
            _connection.Close();
            return products;
        }

        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public DataTable GetAll2()
        {
            SqlConnection connection = new SqlConnection(@"server=DESKTOP-KD63QHB\SQLEXPRESS;initial catalog=Container;integrated security=true");
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand("Select * from PRODUCTS", connection);
            SqlDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            reader.Close();
            connection.Close();
            return dataTable;
        }

        public void Add(Product product)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand
                ("INSERT INTO Products (ProductId, ProductName, Descriptions, StockQuantity) VALUES (@ProductID, @ProductName, @Descriptions, @StockQuantity)", _connection);
            command.Parameters.AddWithValue("@ProductID", product.ProductId);
            command.Parameters.AddWithValue("@ProductName", product.ProductName);
            command.Parameters.AddWithValue("@Descriptions", product.Descriptions);
            command.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void Update(Product product)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand
                ("UPDATE Products SET ProductName=@ProductName, Descriptions=@Descriptions, StockQuantity=@StockQuantity WHERE ProductId=@ID", _connection);
            command.Parameters.AddWithValue("@ProductName", product.ProductName);
            command.Parameters.AddWithValue("@Descriptions", product.Descriptions);
            command.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);
            command.Parameters.AddWithValue("@ID", product.ProductId);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void Delete(int ID)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand
                ("DELETE FROM Products WHERE ProductId=@ID", _connection);
            command.Parameters.AddWithValue("@ID", ID);
            command.ExecuteNonQuery();
            _connection.Close();
        }
    }
}

