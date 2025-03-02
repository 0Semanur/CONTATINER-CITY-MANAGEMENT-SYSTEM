using ProductAdd;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ContainerFronted
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProductDal _productDal = new ProductDal();
        private void dgwProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            dgwProduct.DataSource = _productDal.GetAll();
        }

      
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                ProductId = Convert.ToDecimal(txtID.Text),
                ProductName = tbxName.Text,
                Descriptions = tbxDescription.Text,
                StockQuantity = Convert.ToInt32(tbxStock.Text)
            });
            MessageBox.Show("Product Added!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value);
            _productDal.Delete(ID);
            MessageBox.Show("Deleted");
        }

        private void tbxStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value);
            _productDal.Delete(ID);
            MessageBox.Show("Deleted");
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            Product product = new Product()
            {
                ProductId = Convert.ToDecimal(dgwProduct.CurrentRow.Cells[0].Value),
                ProductName = tbxNameUpdate.Text,
                Descriptions = tbxDescriptionUpdate.Text,
                StockQuantity = Convert.ToInt32(tbxStockUpdate.Text) // Corrected to use the TextBox for StockQuantity
            };
            _productDal.Update(product);

            MessageBox.Show("Updated!");
        }


        private void dgwProduct_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            txtıd.Text = dgwProduct.CurrentRow.Cells[0].Value.ToString();
            tbxNameUpdate.Text = dgwProduct.CurrentRow.Cells[1].Value.ToString();
            tbxDescriptionUpdate.Text = dgwProduct.CurrentRow.Cells[2].Value.ToString();
            tbxStockUpdate.Text = dgwProduct.CurrentRow.Cells[3].Value.ToString();

        
    }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
