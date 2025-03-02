using System;
using System.Data;
using System.Windows.Forms;

namespace DeletePerson
{
    public partial class Form1 : Form
    {
        private DeletePerson _deletePerson;

        public Form1()
        {
            InitializeComponent();
            _deletePerson = new DeletePerson();
            LoadData();
        }

        private void LoadData()
        {
            DataTable employeeTable = _deletePerson.GetEmployees();
            dataGridView1.DataSource = employeeTable;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string ssn = dataGridView1.SelectedRows[0].Cells["ssN"].Value.ToString();
                _deletePerson.DeletePersonBySSN(ssn);
                LoadData();
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}