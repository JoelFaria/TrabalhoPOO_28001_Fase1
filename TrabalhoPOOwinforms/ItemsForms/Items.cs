using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace TrabalhoPOOwinforms
{
    public partial class Items : Form
    {
        public Items()
        {
            InitializeComponent();

            LoadData();
        }

        private int selctedproductid;

        private void LoadData()
        {
            string query = "SELECT * FROM StockTable";
            string connectionString = "Data Source=JOELFARIA\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
        private void UpdateStock(int productId)
        {
            string connectionString = "Data Source=JOELFARIA\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;TrustServerCertificate=True";
            string query = "UPDATE StockTable SET Stock = Stock - 1 WHERE Id = @Id AND Stock > 0";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", productId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Compra realizada com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Produto sem stock disponível!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao atualizar o stock: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                selctedproductid = Convert.ToInt32(row.Cells["Id"].Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(selctedproductid > 0)
            {
                UpdateStock(selctedproductid);
                LoadData();
            }
            else
            {
                MessageBox.Show("Selecione um produto para comprar!");
            }
        }
    }
}
