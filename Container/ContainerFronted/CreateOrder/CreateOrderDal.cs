using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateOrder
{
    internal class CreateOrderDal
    {
        public void Send(Product product)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand
                ("INSERT INTO orders (OrdertId, OrderName, OrderDescription, containerNo,ProductId) VALUES (@OrderID, @OrderName, @OrderDescription, @containerNo,@ProductId)", _connection);
            command.Parameters.AddWithValue("@OrdertID", orders.ProductId);
            command.Parameters.AddWithValue("@OrderName", product.ProductName);
            command.Parameters.AddWithValue("@OrderDescription", product.Descriptions);
            command.Parameters.AddWithValue("@containerNo", product.StockQuantity);

            command.ExecuteNonQuery();
            _connection.Close();
        }
    }
}
