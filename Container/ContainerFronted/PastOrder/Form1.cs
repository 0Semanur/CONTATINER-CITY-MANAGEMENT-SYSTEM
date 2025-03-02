using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PastOrder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (long.TryParse(txtSSN.Text, out long ssN))
            {
                ShowPastOrders(ssN); // Assuming you have a textbox for SSN input
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir SSN girin.", "Geçersiz Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ShowPastOrders(long ssN)
        {
            using (SqlConnection conn = new SqlConnection(@"server=DESKTOP-KD63QHB\SQLEXPRESS;initial catalog=Container;integrated security=true"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("EXEC pastOrder @ssN", conn))
                {
                    cmd.Parameters.AddWithValue("@ssN", ssN);

                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            dataGridView1.DataSource = dt; // Assuming you have a DataGridView to show the results
                            MessageBox.Show("Siparişler başarıyla yüklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Geçmiş sipariş bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }

    public class View
    {
        public long ssN { get; set; }
    }
}
