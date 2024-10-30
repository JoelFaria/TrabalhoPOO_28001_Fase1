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

        private void SaveProductData(Produto produto)
        {
            string connectionString = "Data Source=JOELFARIA\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;TrustServerCertificate=True";
            string query = "INSERT INTO StockTable (type, name, price, stock, brand, guarantee, description) VALUES (@Type, @Name, @Price, @Stock, @Brand, @Guarantee, @Description)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Type", produto.CategoriaProduto);
                    cmd.Parameters.AddWithValue("@Name", produto.NomeProduto);
                    cmd.Parameters.AddWithValue("@Price", produto.PrecoProduto);
                    cmd.Parameters.AddWithValue("@Stock", produto.StockProduto);
                    cmd.Parameters.AddWithValue("@Brand", produto.MarcaProduto);
                    cmd.Parameters.AddWithValue("@Guarantee", produto.GarantiaMesesProdutos);
                    cmd.Parameters.AddWithValue("@Description", produto.DescricaoProduto);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Produto adicionado com sucesso!");
                    LoadStockData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar produto: " + ex.Message);
                }
            }
        }

        private void UpdateProductData(Produto produto, int id)
        {
            string connectionString = "Data Source=JOELFARIA\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;TrustServerCertificate=True";
            string query = "UPDATE StockTable SET type = @Type, name = @Name, price = @Price, stock = @Stock, brand = @Brand, guarantee = @Guarantee, description=@Description WHERE id = @Id";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Type", produto.CategoriaProduto);
                    cmd.Parameters.AddWithValue("@Name", produto.NomeProduto);
                    cmd.Parameters.AddWithValue("@Price", produto.PrecoProduto);
                    cmd.Parameters.AddWithValue("@Stock", produto.StockProduto);
                    cmd.Parameters.AddWithValue("@Brand", produto.MarcaProduto);
                    cmd.Parameters.AddWithValue("@Guarantee", produto.GarantiaMesesProdutos);
                    cmd.Parameters.AddWithValue("@Description", produto.DescricaoProduto);
                    cmd.Parameters.AddWithValue("@Id", id); 

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Produto atualizado com sucesso!");
                    LoadStockData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao atualizar produto: " + ex.Message);
                }
            }
        }

        private void DeleteProductData(int id)
        {
            string connectionString = "Data Source=JOELFARIA\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;TrustServerCertificate=True";
            string query = "DELETE FROM StockTable WHERE id = @Id";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Produto eliminado com sucesso!");
                    LoadStockData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao eliminar produto: " + ex.Message);
                }
            }
        }

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
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                
                textId.Text = row.Cells["id"].Value.ToString(); 
                textName.Text = row.Cells["name"].Value.ToString();
                textDescription.Text = row.Cells["description"].Value.ToString();
                textPrice.Text = row.Cells["price"].Value.ToString();
                textStock.Text = row.Cells["stock"].Value.ToString();
                textBrand.Text = row.Cells["brand"].Value.ToString();
                textGuarantee.Text = row.Cells["guarantee"].Value.ToString();
                comboBox1.SelectedItem = row.Cells["type"].Value.ToString();
            }
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione uma categoria.");
                return;
            }

           
            if (
                string.IsNullOrWhiteSpace(textPrice.Text) ||
                !double.TryParse(textPrice.Text, out double preco) ||
                string.IsNullOrWhiteSpace(textStock.Text) ||
                !int.TryParse(textStock.Text, out int stock) ||
                string.IsNullOrWhiteSpace(textGuarantee.Text) ||
                !int.TryParse(textGuarantee.Text, out int garantia) ||
                string.IsNullOrWhiteSpace(textDescription.Text) 
            )
            {
                MessageBox.Show("Por favor, preencha todos os campos corretamente.");
                return;
            }

            Produto produto = new Produto(
                nome: textName.Text,
                descricao: textDescription.Text, 
                preco: preco,
                cat: comboBox1.SelectedItem?.ToString() ?? string.Empty,
                stock: stock,
                marca: textBrand.Text,
                garantia: garantia
            );

            SaveProductData(produto);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textId.Text, out int id))
            {
                Produto produto = new Produto(
                    nome: textName.Text,
                    descricao: textDescription.Text,
                    preco: double.Parse(textPrice.Text),
                    cat: comboBox1.SelectedItem?.ToString() ?? string.Empty,
                    stock: int.Parse(textStock.Text),
                    marca: textBrand.Text,
                    garantia: int.Parse(textGuarantee.Text)
                );

                UpdateProductData(produto, id);
            }
            else
            {
                MessageBox.Show("ID inválido.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textId.Text, out int id))
            {
                DeleteProductData(id);
            }
            else
            {
                MessageBox.Show("ID inválido.");
            }
        }
    }
}
