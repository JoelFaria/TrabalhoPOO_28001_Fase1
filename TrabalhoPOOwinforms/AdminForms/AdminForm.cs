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
using Funcoes;
using System.Text.RegularExpressions;


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

            HideFields();

            LoadStockData();
        }

        xyz a = new xyz();



        /// <summary>
        /// Insere os dados do produto na DataGridView
        /// </summary>
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

        private void SaveGPUData(int productId)
        {
            string connectionString = "Data Source=JOELFARIA\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;TrustServerCertificate=True";
            string query = "INSERT INTO GpuTable (productId, vram, baseClock, boostClock) VALUES (@ProductId, @VRAM, @BaseClock, @BoostClock)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    cmd.Parameters.AddWithValue("@VRAM", int.Parse(textVRAM.Text));
                    cmd.Parameters.AddWithValue("@BaseClock", int.Parse(textBaseClock.Text));
                    cmd.Parameters.AddWithValue("@BoostClock", int.Parse(textBoostClock.Text));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("GPU adicionada com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar GPU: " + ex.Message);
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
            // Primeiro, oculta todos os campos
            HideFields();

            // Exibe apenas os campos específicos do tipo de produto selecionado
            switch (comboBox1.SelectedItem)
            {
                case "GPU":
                    textVRAM.Visible = true;
                    textBaseClock.Visible = true;
                    textBoostClock.Visible = true;
                    VRAMlabel.Visible = true;
                    Baselabel.Visible = true;
                    Boostlabel.Visible = true;
                    break;

                case "CPU":
                    textCache.Visible = true;
                    textSocket.Visible = true;
                    textMem.Visible = true;
                    textFrequency.Visible = true;
                    CacheLabel.Visible = true;
                    SocketLabel.Visible = true;
                    MemoryLabel.Visible = true;
                    FrequencyLabel.Visible = true;
                    break;

                case "Motherboard":
                    textSocketMB.Visible = true;
                    textMemorySupport.Visible = true;
                    textFormFactor.Visible = true;
                    SocketLabelMB.Visible = true;
                    MemorySupportLabelMB.Visible = true;  // Memória suportada para Motherboard
                    FormFactorLabel.Visible = true;
                    break;

                case "RAM":
                    textFrequencyRAM.Visible = true;
                    textCapacity.Visible = true;
                    textType.Visible = true;
                    textLatency.Visible = true;
                    FrequencylabelRAM.Visible = true;
                    Capacitylabel.Visible = true;
                    Typelabel.Visible = true;
                    Latencylabel.Visible = true;
                    break;
            }
        }

        private void label8_Click_1(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// Extrai os dados da linha selecionada e preenche as TextBoxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ignora cabeçalhos
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                textId.Text = selectedRow.Cells["id"].Value.ToString();
                textName.Text = selectedRow.Cells["name"].Value.ToString();
                textDescription.Text = selectedRow.Cells["description"].Value.ToString();
                textPrice.Text = selectedRow.Cells["price"].Value.ToString();
                textStock.Text = selectedRow.Cells["stock"].Value.ToString();
                textBrand.Text = selectedRow.Cells["brand"].Value.ToString();
                textGuarantee.Text = selectedRow.Cells["guarantee"].Value.ToString();
                comboBox1.SelectedItem = selectedRow.Cells["type"].Value.ToString();
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
        /// <summary>
        /// Butao para adicionar um produto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
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

            bool Sucesso = a.AddProduct(produto);

            if (Sucesso) 
            {
                LoadStockData();
                MessageBox.Show("Produto adicionado com sucesso!");

            }
            else
            {
                MessageBox.Show("Erro ao adicionar produto.");
            }

        }
        /// <summary>
        /// Butao para atualizar um produto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
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

            bool Sucesso = a.UpdateProduct(produto, int.Parse(textId.Text));

            if (Sucesso) {
                MessageBox.Show("Produto atualizado com sucesso!");
                LoadStockData();
            }
            else
            {
                MessageBox.Show("Erro ao atualizar produto.");
            }
        }


        /// <summary>
        /// Butao para eliminar um produto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
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

            bool Sucesso = a.DeleteProduct(int.Parse(textId.Text));

            if (Sucesso) {
                MessageBox.Show("Produto eliminado com sucesso!");
                LoadStockData();
            }
            else
            {
                MessageBox.Show("Erro ao eliminar produto.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void HideFields()
        {
            // Oculta todos os campos relacionados a todos os tipos de produtos
            textVRAM.Visible = false;
            textBaseClock.Visible = false;
            textBoostClock.Visible = false;
            VRAMlabel.Visible = false;
            Baselabel.Visible = false;
            Boostlabel.Visible = false;

            textCache.Visible = false;
            textSocket.Visible = false;
            textMem.Visible = false;
            textFrequency.Visible = false;
            CacheLabel.Visible = false;
            SocketLabel.Visible = false;
            MemoryLabel.Visible = false;  // Para CPU
            FrequencyLabel.Visible = false;

            textSocketMB.Visible = false;
            textMemorySupport.Visible = false;  // Torna textMemorySupport invisível
            textFormFactor.Visible = false;
            SocketLabelMB.Visible = false;
            MemorySupportLabelMB.Visible = false; // Rótulo específico para Memory Support da Motherboard
            FormFactorLabel.Visible = false;

            textFrequencyRAM.Visible = false;
            textCapacity.Visible = false;
            textType.Visible = false;
            textLatency.Visible = false;
            FrequencylabelRAM.Visible = false;
            Capacitylabel.Visible = false;
            Typelabel.Visible = false;
            Latencylabel.Visible = false;
        }

        private void textCache_TextChanged(object sender, EventArgs e)
        {

        }

        private void Capacitylabel_Click(object sender, EventArgs e)
        {

        }

        private void textName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
