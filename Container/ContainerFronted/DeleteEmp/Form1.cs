using System;
using System.Data;
using System.Windows.Forms;

namespace DeleteEmp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DisplayEmployees(); // Form yüklendiğinde çalışanları gösterecek.
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayEmployees(); // Form yüklendiğinde çalışanları gösterecek.
        }

        private void DisplayEmployees()
        {
            EmpDelete empDelete = new EmpDelete();
            DataTable employees = empDelete.GetEmployees();
            dataGridView1.DataSource = employees;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                EmpDelete empDelete = new EmpDelete();
                Emp newEmployee = new Emp
                {
                    empno = Convert.ToInt32(txtempno.Text),
                };
                empDelete.DeleteEmployee(newEmployee);
                MessageBox.Show("Çalışan başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplayEmployees(); // Silme işleminden sonra tabloyu günceller.

                // Eklenen kod: Çalışanların toplam ve ortalama maaşını gösteren mesaj kutusu
                DataTable employees = empDelete.GetEmployees();
                decimal totalSalary = 0;
                decimal averageSalary = 0;
                if (employees.Rows.Count > 0)
                {
                    foreach (DataRow row in employees.Rows)
                    {
                        totalSalary += Convert.ToDecimal(row["salary"]);
                    }
                    averageSalary = totalSalary / employees.Rows.Count;
                }
                MessageBox.Show($"Toplam Maaş: {totalSalary}\nOrtalama Maaş: {averageSalary}", "Maaş Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Diğer metodlar
        private void dgwProduct_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void btnAdd_Click(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }
        private void tbxStock_TextChanged(object sender, EventArgs e) { }
        private void btnRemove_Click(object sender, EventArgs e) { }
        private void btnUpdate_Click_1(object sender, EventArgs e) { }
        private void dgwProduct_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }
        private void groupBox1_Enter_1(object sender, EventArgs e) { }
        private void txtID_TextChanged(object sender, EventArgs e) { }

        private void Form1_Load_1(object sender, EventArgs e) { }
    }
}
