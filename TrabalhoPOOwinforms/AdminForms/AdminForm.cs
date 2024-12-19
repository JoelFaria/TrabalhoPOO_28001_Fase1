using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using TrabalhoPOO;
using Funcoes;

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

        Funcoes1 a = new Funcoes1();
        string connectionString = "Data Source=JOELFARIA\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;TrustServerCertificate=True";

        #region Login
        private void button4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        #endregion

        #region Metodo de salvar produtos

        public void SaveGPU()
        {
            Gpu gpu = new Gpu(
                vram: int.Parse(textVRAM.Text),
                baseClock: int.Parse(textBaseClock.Text),
                boostClock: int.Parse(textBoostClock.Text),
                nome: textName.Text,
                descricao: textDescription.Text,
                preco: double.Parse(textPrice.Text),
                cat: comboBox1.SelectedItem?.ToString() ?? string.Empty,
                stock: int.Parse(textStock.Text),
                marca: textBrand.Text,
                garantia: int.Parse(textGuarantee.Text)
            );
                a.AddNewProduct(gpu);
        }

        public void SaveCPU()
        {
            Cpu cpu = new Cpu(
                cache: int.Parse(textCache.Text),
                socket: textSocket.Text,
                memorySupport: textMem.Text,
                frequency: int.Parse(textFrequency.Text),
                nome: textName.Text,
                descricao: textDescription.Text,
                preco: double.Parse(textPrice.Text),
                cat: comboBox1.SelectedItem?.ToString() ?? string.Empty,
                stock: int.Parse(textStock.Text),
                marca: textBrand.Text,
                garantia: int.Parse(textGuarantee.Text)
            );
            a.AddNewProduct(cpu);
        }

        public void SaveMotherboard()
        {
            Motherboard motherboard = new Motherboard(
                socket: textSocketMB.Text,
                memorySupport: textMemorySupport.Text,
                formFactor: textFormFactor.Text,
                nome: textName.Text,
                descricao: textDescription.Text,
                preco: double.Parse(textPrice.Text),
                cat: comboBox1.SelectedItem?.ToString() ?? string.Empty,
                stock: int.Parse(textStock.Text),
                marca: textBrand.Text,
                garantia: int.Parse(textGuarantee.Text)
            );

            a.AddNewProduct(motherboard);
        }

        public void SaveRAM()
        {
            RAM ram = new RAM(
                frequency: int.Parse(textFrequencyRAM.Text),
                capacity: int.Parse(textCapacity.Text),
                type: textType.Text,
                latency: int.Parse(textLatency.Text),
                nome: textName.Text,
                descricao: textDescription.Text,
                preco: double.Parse(textPrice.Text),
                cat: comboBox1.SelectedItem?.ToString() ?? string.Empty,
                stock: int.Parse(textStock.Text),
                marca: textBrand.Text,
                garantia: int.Parse(textGuarantee.Text)
            );

             a.AddNewProduct(ram);
        }      
        public void SaveProduct()
        {
            string SelectedItem = comboBox1.SelectedItem.ToString();

            switch (SelectedItem)
            {
                case "GPU":
                    SaveGPU();
                    break;

                case "CPU":
                    SaveCPU();
                    break;

                case "Motherboard":
                    SaveMotherboard();
                    break;

                case "RAM":
                    SaveRAM();
                    break;

                default:
                    MessageBox.Show("Selecione um tipo de produto.");
                    break;
            }
        }

#endregion

        #region Butoes de adicionar, atualizar e eliminar produtos
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SaveProduct();
                LoadStockData();
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar produto.", ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textId.Text);

            // Verificar o tipo de produto selecionado e instanciar o objeto correto
            Produto produto;

            // Verificar o tipo do produto a partir do ComboBox
            if (comboBox1.SelectedItem.ToString() == "GPU")
            {
                produto = new Gpu(
                    vram: int.Parse(textVRAM.Text),
                    baseClock: int.Parse(textBaseClock.Text),
                    boostClock: int.Parse(textBoostClock.Text),
                    nome: textName.Text,
                    descricao: textDescription.Text,
                    preco: double.Parse(textPrice.Text),
                    cat: comboBox1.SelectedItem?.ToString() ?? string.Empty,
                    stock: int.Parse(textStock.Text),
                    marca: textBrand.Text,
                    garantia: int.Parse(textGuarantee.Text)
                );
            }
            else if (comboBox1.SelectedItem.ToString() == "CPU")
            {
                produto = new Cpu(
                    cache: int.Parse(textCache.Text),
                    socket: textSocket.Text,
                    memorySupport: textMem.Text,
                    frequency: int.Parse(textFrequency.Text),
                    nome: textName.Text,
                    descricao: textDescription.Text,
                    preco: double.Parse(textPrice.Text),
                    cat: comboBox1.SelectedItem?.ToString() ?? string.Empty,
                    stock: int.Parse(textStock.Text),
                    marca: textBrand.Text,
                    garantia: int.Parse(textGuarantee.Text)
                );
            }
            else if (comboBox1.SelectedItem.ToString() == "Motherboard")
            {
                produto = new Motherboard(
                    socket: textSocketMB.Text,
                    memorySupport: textMemorySupport.Text,
                    formFactor: textFormFactor.Text,
                    nome: textName.Text,
                    descricao: textDescription.Text,
                    preco: double.Parse(textPrice.Text),
                    cat: comboBox1.SelectedItem?.ToString() ?? string.Empty,
                    stock: int.Parse(textStock.Text),
                    marca: textBrand.Text,
                    garantia: int.Parse(textGuarantee.Text)
                );
            }
            else if (comboBox1.SelectedItem.ToString() == "RAM")
            {
                produto = new RAM(
                    frequency: int.Parse(textFrequencyRAM.Text),
                    capacity: int.Parse(textCapacity.Text),
                    type: textType.Text,
                    latency: int.Parse(textLatency.Text),
                    nome: textName.Text,
                    descricao: textDescription.Text,
                    preco: double.Parse(textPrice.Text),
                    cat: comboBox1.SelectedItem?.ToString() ?? string.Empty,
                    stock: int.Parse(textStock.Text),
                    marca: textBrand.Text,
                    garantia: int.Parse(textGuarantee.Text)
                );
            }
            else
            {
                MessageBox.Show("Tipo de produto não selecionado ou inválido.");
                return;
            }

            bool sucesso = a.UpdateProduct(produto, id);

            if (sucesso)
            {
                MessageBox.Show("Produto atualizado com sucesso!");
                LoadStockData();
            }
            else
            {
                MessageBox.Show("Erro ao atualizar produto.");
            }
        }

      private void button3_Click(object sender, EventArgs e)
       {
            try
            {
                int id = int.Parse(textId.Text); // Pegar o Id do produto da caixa de texto
                bool sucesso = a.DeleteProduct(id);

                if (sucesso)
                {
                    MessageBox.Show("Produto eliminado com sucesso!");
                    LoadStockData(); // Recarregar dados para refletir a exclusão
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        #endregion

        #region Metodo de Esconder campos
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
            MemoryLabel.Visible = false;  
            FrequencyLabel.Visible = false;

            textSocketMB.Visible = false;
            textMemorySupport.Visible = false;  
            textFormFactor.Visible = false;
            SocketLabelMB.Visible = false;
            MemorySupportLabelMB.Visible = false; 
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

        #endregion

        #region Metodo de carregar detalhes de produtos

        private void LoadStockData()
        {
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



        private void LoadGpuDetails(int productId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT VRAM, BaseClock, OverClock FROM Gpu WHERE ProductId = @ProductId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductId", productId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textVRAM.Text = reader["VRAM"].ToString();
                    textBaseClock.Text = reader["BaseClock"].ToString();
                    textBoostClock.Text = reader["OverClock"].ToString();
                }
            }
        }

        private void LoadCpuDetails(int productId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Cache, Socket, MemorySupport, Frequency FROM Cpu WHERE ProductId = @ProductId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductId", productId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textCache.Text = reader["Cache"].ToString();
                    textSocket.Text = reader["Socket"].ToString();
                    textMem.Text = reader["MemorySupport"].ToString();
                    textFrequency.Text = reader["Frequency"].ToString();
                }
            }
        }

        private void LoadMotherboardDetails(int productId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Socket, MemorySupport, FormFactor FROM Motherboard WHERE ProductId = @ProductId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductId", productId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textSocketMB.Text = reader["Socket"].ToString();
                    textMemorySupport.Text = reader["MemorySupport"].ToString();
                    textFormFactor.Text = reader["FormFactor"].ToString();
                }
            }
        }

        private void LoadRamDetails(int productId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Frequency, Capacity, Type, Latency FROM Ram WHERE ProductId = @ProductId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductId", productId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textFrequencyRAM.Text = reader["Frequency"].ToString();
                    textCapacity.Text = reader["Capacity"].ToString();
                    textType.Text = reader["Type"].ToString();
                    textLatency.Text = reader["Latency"].ToString();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ignora cabeçalhos
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Dados comuns
                textId.Text = selectedRow.Cells["id"].Value.ToString();
                textName.Text = selectedRow.Cells["name"].Value.ToString();
                textDescription.Text = selectedRow.Cells["description"].Value.ToString();
                textPrice.Text = selectedRow.Cells["price"].Value.ToString();
                textStock.Text = selectedRow.Cells["stock"].Value.ToString();
                textBrand.Text = selectedRow.Cells["brand"].Value.ToString();
                textGuarantee.Text = selectedRow.Cells["guarantee"].Value.ToString();
                comboBox1.SelectedItem = selectedRow.Cells["type"].Value.ToString();

                // Identifica o tipo de produto
                string productType = selectedRow.Cells["type"].Value.ToString();
                int productId = int.Parse(textId.Text);

                // Busca dados adicionais com base no tipo
                if (productType.ToLower() == "gpu")
                {
                    LoadGpuDetails(productId);
                }
                else if (productType.ToLower() == "cpu")
                {
                    LoadCpuDetails(productId);
                }
                else if (productType.ToLower() == "motherboard")
                {
                    LoadMotherboardDetails(productId);
                }
                else if (productType.ToLower() == "ram")
                {
                    LoadRamDetails(productId);
                }
            }
        }

        #endregion

    }
}
