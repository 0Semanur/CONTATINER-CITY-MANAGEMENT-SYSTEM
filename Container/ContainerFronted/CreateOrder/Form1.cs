using System.Data.SqlClient;
using System.Windows.Forms;
using System;

namespace CreateOrder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            using (SqlConnection conn = new SqlConnection(@"server=DESKTOP-KD63QHB\SQLEXPRESS;initial catalog=Container;integrated security=true"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT ProductName FROM Products", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["ProductName"].ToString());
                    }
                    reader.Close();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string productName = comboBox1.SelectedItem.ToString();
                // İlgili işlemler burada yapılabilir.
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && int.TryParse(txtcnt.Text, out int containerNo))
            {
                string productName = comboBox1.SelectedItem.ToString();
                string orderName = GetPersonFullName(containerNo);

                try
                {
                    using (SqlConnection conn = new SqlConnection(@"server=DESKTOP-KD63QHB\SQLEXPRESS;initial catalog=Container;integrated security=true"))
                    {
                        conn.Open();

                        using (SqlTransaction transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                decimal productId = GetProductId(conn, transaction, productName);

                                using (SqlCommand cmd = new SqlCommand("INSERT INTO Orders (OrderName, OrderDescription, containerNo, ProductId) VALUES (@OrderName, @OrderDescription, @containerNo, @ProductId)", conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@OrderName", orderName);
                                    cmd.Parameters.AddWithValue("@OrderDescription", productName);
                                    cmd.Parameters.AddWithValue("@containerNo", containerNo);
                                    cmd.Parameters.AddWithValue("@ProductId", productId);

                                    cmd.ExecuteNonQuery();
                                }

                                transaction.Commit();
                                MessageBox.Show("Sipariş başarıyla eklendi.");
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show("SQL Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir ürün seçin ve container numarasını girin.", "Geçersiz Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string GetPersonFullName(int containerNo)
        {
            using (SqlConnection conn = new SqlConnection(@"server=DESKTOP-KD63QHB\SQLEXPRESS;initial catalog=Container;integrated security=true"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT p.FullName FROM PersonReceivingService prs INNER JOIN Person p ON prs.ssN = p.ssN WHERE prs.containerNo = @containerNo", conn))
                {
                    cmd.Parameters.AddWithValue("@containerNo", containerNo);
                    return cmd.ExecuteScalar() as string;
                }
            }
        }

        private decimal GetProductId(SqlConnection conn, SqlTransaction transaction, string productName)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT ProductId FROM Products WHERE ProductName = @ProductName", conn, transaction))
            {
                cmd.Parameters.AddWithValue("@ProductName", productName);
                return (decimal)cmd.ExecuteScalar();
            }
        }

        private void txtcnt_TextChanged(object sender, EventArgs e)
        {
            btnSend.Enabled = int.TryParse(txtcnt.Text, out _);
        }
    }
}

public class order
{
    public int OrderID { get; set; }
    public string OrderName { get; set; }
    public string OrderDescription { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int containerNo { get; set; }
    public string FullName { get; set; }
}
