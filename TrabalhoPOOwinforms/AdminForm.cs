using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using TrabalhoPOO;

namespace TrabalhoPOOwinforms
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();

            comboBox1.Items.Add("GPU");
            comboBox1.Items.Add("CPU");
            comboBox1.Items.Add("RAM");
            comboBox1.Items.Add("Motherboard");

            LoadStockData();
        }

        private void LoadStockData()
        {
            string connectionString = "Data Source=JOELFARIA\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;TrustServerCertificate=True";
            string query = "SELECT * FROM StockTable";

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
/*
        private void SaveData(Produto produto) 
        { 
            string connectionString = "Data Source=JOELFARIA\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;TrustServerCertificate=True";
            string query = "INSERT INTO StockTable (type, name, price, stock, brand, guarantee, id) VALUES (@Type, @Name, @Price, @Stock, @Brand, @Guarantee, @Id)";

            using(SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", produto.NomeProduto);
                    cmd.Parameters.AddWithValue("@Id", produto.IdProduto);
                    cmd.Parameters.AddWithValue("@Price", produto.PrecoProduto);
                    cmd.Parameters.AddWithValue("@Type", produto.CategoriaProduto);
                    cmd.Parameters.AddWithValue("@Stock", produto.StockProduto);
                    cmd.Parameters.AddWithValue("@Brand", produto.MarcaProduto);
                    cmd.Parameters.AddWithValue("@Guarantee", produto.GarantiaMesesProdutos);
                    cmd.ExecuteNonQuery();
                    LoadStockData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar dados: " + ex.Message);
                }
            }
        }
*/

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label8_Click_1(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }
    }
}
