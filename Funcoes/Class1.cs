using System;
using Microsoft.Data.SqlClient;
using TrabalhoPOO;

namespace Funcoes
{

    public class Funcoes1
    {
        private const string connectionString = "Data Source=JOELFARIA\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;TrustServerCertificate=True";

        #region Função de Atualização

        /// <summary>
        /// Função para atualizar um produto no banco de dados 
        /// </summary>
        /// <param name="produto"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool UpdateProduct(Produto produto, int Id)
        {
            try
            {
                // Estabelece a conexão com o banco de dados
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Atualiza a tabela StockTable com os dados do produto
                    string queryStock = "UPDATE StockTable SET Name = @Name, Description = @Description, Price = @Price, " +
                                        "Type = @Type, Stock = @Stock, Brand = @Brand, Guarantee = @Guarantee WHERE Id = @Id";

                    using (SqlCommand cmdStock = new SqlCommand(queryStock, conn))
                    {
                        // Adiciona os parâmetros à consulta
                        cmdStock.Parameters.AddWithValue("@Name", produto.NomeProduto);
                        cmdStock.Parameters.AddWithValue("@Description", produto.DescricaoProduto);
                        cmdStock.Parameters.AddWithValue("@Price", produto.PrecoProduto);
                        cmdStock.Parameters.AddWithValue("@Type", produto.CategoriaProduto);
                        cmdStock.Parameters.AddWithValue("@Stock", produto.StockProduto);
                        cmdStock.Parameters.AddWithValue("@Brand", produto.MarcaProduto);
                        cmdStock.Parameters.AddWithValue("@Guarantee", produto.GarantiaMesesProdutos);
                        cmdStock.Parameters.AddWithValue("@Id", Id);

                        // Executa a consulta para atualizar a tabela StockTable
                        cmdStock.ExecuteNonQuery();
                    }

                    // Atualiza a tabela específica com base no tipo do produto
                    switch (produto)
                    {
                        case Gpu gpu:
                            // Atualiza a tabela Gpu com os dados específicos da GPU
                            string queryGpu = "UPDATE Gpu SET VRAM = @VRAM, BaseClock = @BaseClock, OverClock = @OverClock WHERE ProductId = @ProductId";
                            using (SqlCommand cmdGpu = new SqlCommand(queryGpu, conn))
                            {
                                cmdGpu.Parameters.AddWithValue("@ProductId", Id);
                                cmdGpu.Parameters.AddWithValue("@VRAM", gpu.GetVRAM);
                                cmdGpu.Parameters.AddWithValue("@BaseClock", gpu.GetBaseClock);
                                cmdGpu.Parameters.AddWithValue("@OverClock", gpu.GetBoostClock);
                                cmdGpu.ExecuteNonQuery();
                            }
                            break;

                        case Cpu cpu:
                            // Atualiza a tabela Cpu com os dados específicos da CPU
                            string queryCpu = "UPDATE Cpu SET Cache = @Cache, Socket = @Socket, MemorySupport = @MemorySupport, Frequency = @Frequency WHERE ProductId = @ProductId";
                            using (SqlCommand cmdCpu = new SqlCommand(queryCpu, conn))
                            {
                                cmdCpu.Parameters.AddWithValue("@ProductId", Id);
                                cmdCpu.Parameters.AddWithValue("@Cache", cpu.GetCache);
                                cmdCpu.Parameters.AddWithValue("@Socket", cpu.GetSocket);
                                cmdCpu.Parameters.AddWithValue("@MemorySupport", cpu.GetMemorySupport);
                                cmdCpu.Parameters.AddWithValue("@Frequency", cpu.GetFrequency);
                                cmdCpu.ExecuteNonQuery();
                            }
                            break;

                        case Motherboard motherboard:
                            // Atualiza a tabela Motherboard com os dados específicos da placa-mãe
                            string queryMotherboard = "UPDATE Motherboard SET Socket = @Socket, MemorySupport = @MemorySupport, FormFactor = @FormFactor WHERE ProductId = @ProductId";
                            using (SqlCommand cmdMotherboard = new SqlCommand(queryMotherboard, conn))
                            {
                                cmdMotherboard.Parameters.AddWithValue("@ProductId", Id);
                                cmdMotherboard.Parameters.AddWithValue("@Socket", motherboard.SocketMotherboard);
                                cmdMotherboard.Parameters.AddWithValue("@MemorySupport", motherboard.MemorySupportMotherboard);
                                cmdMotherboard.Parameters.AddWithValue("@FormFactor", motherboard.FormFactorMotherboard);
                                cmdMotherboard.ExecuteNonQuery();
                            }
                            break;

                        case RAM ram:
                            // Atualiza a tabela Ram com os dados específicos da RAM
                            string queryRam = "UPDATE Ram SET Capacity = @Capacity, Type = @Type, Frequency = @Frequency, Latency = @Latency WHERE ProductId = @ProductId";
                            using (SqlCommand cmdRam = new SqlCommand(queryRam, conn))
                            {
                                cmdRam.Parameters.AddWithValue("@ProductId", Id);
                                cmdRam.Parameters.AddWithValue("@Capacity", ram.GetCapacity);
                                cmdRam.Parameters.AddWithValue("@Type", ram.GetType);
                                cmdRam.Parameters.AddWithValue("@Frequency", ram.GetFrequency);
                                cmdRam.Parameters.AddWithValue("@Latency", ram.GetLatency);
                                cmdRam.ExecuteNonQuery();
                            }
                            break;

                        default:
                            // Lança uma exceção se o tipo de produto for desconhecido
                            throw new ArgumentException("Tipo de produto desconhecido.");
                    }

                    return true; // Retorna true se a atualização for bem-sucedida
                }
            }
            catch (Exception ex)
            {
                // Lança uma exceção se ocorrer um erro durante a atualização
                throw new Exception("Erro ao atualizar o produto.", ex);
            }
        }

        #endregion

        #region Funções de Eliminação

        /// <summary>
        /// Função para eliminar um produto do banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public bool DeleteProduct(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Eliminar registros de tabelas específicas
                    string deleteGpu = "DELETE FROM Gpu WHERE ProductId = @ProductId";
                    string deleteCpu = "DELETE FROM Cpu WHERE ProductId = @ProductId";
                    string deleteMotherboard = "DELETE FROM Motherboard WHERE ProductId = @ProductId";
                    string deleteRam = "DELETE FROM Ram WHERE ProductId = @ProductId";

                    using (SqlCommand cmdGpu = new SqlCommand(deleteGpu, conn))
                    {
                        cmdGpu.Parameters.AddWithValue("@ProductId", id);
                        cmdGpu.ExecuteNonQuery();
                    }

                    using (SqlCommand cmdCpu = new SqlCommand(deleteCpu, conn))
                    {
                        cmdCpu.Parameters.AddWithValue("@ProductId", id);
                        cmdCpu.ExecuteNonQuery();
                    }

                    using (SqlCommand cmdMotherboard = new SqlCommand(deleteMotherboard, conn))
                    {
                        cmdMotherboard.Parameters.AddWithValue("@ProductId", id);
                        cmdMotherboard.ExecuteNonQuery();
                    }

                    using (SqlCommand cmdRam = new SqlCommand(deleteRam, conn))
                    {
                        cmdRam.Parameters.AddWithValue("@ProductId", id);
                        cmdRam.ExecuteNonQuery();
                    }

                    // Eliminar o registro principal na tabela StockTable
                    string deleteStock = "DELETE FROM StockTable WHERE Id = @Id";
                    using (SqlCommand cmdStock = new SqlCommand(deleteStock, conn))
                    {
                        cmdStock.Parameters.AddWithValue("@Id", id);
                        int rowsAffected = cmdStock.ExecuteNonQuery();

                        // Verificar se algum registro foi removido
                        if (rowsAffected == 0)
                        {
                            throw new ArgumentException("Nenhum produto encontrado com o Id especificado.");
                        }
                    }
                }

                return true; // Produto eliminado com sucesso
            }
            catch (Exception ex)
            {
                // Registar ou lançar a exceção
                throw new ArgumentException("Erro ao eliminar o produto.", ex);
            }
        }
        #endregion

        #region Funções de Add Produto específico

        /// <summary>
        /// Função para adicionar uma GPU ao banco de dados 
        /// </summary>
        /// <param name="gpu"></param>
        /// <param name="ProductId"></param>
        /// <returns></returns>
       
        public bool AddGpu(Gpu gpu, int ProductId)
        {
            try
            {
                // Estabelece a conexão com o banco de dados
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Consulta SQL para inserir uma nova GPU
                    string query = "INSERT INTO Gpu (ProductId, VRAM, BaseClock, OverClock) " +
                                   "VALUES (@ProductId, @VRAM, @BaseClock, @OverClock)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Adiciona os parâmetros à consulta
                        cmd.Parameters.AddWithValue("@ProductId", ProductId);
                        cmd.Parameters.AddWithValue("@VRAM", gpu.GetVRAM);
                        cmd.Parameters.AddWithValue("@BaseClock", gpu.GetBaseClock);
                        cmd.Parameters.AddWithValue("@OverClock", gpu.GetBoostClock);

                        // Executa a consulta para inserir a GPU
                        cmd.ExecuteNonQuery();
                    }
                }
                return true; // Retorna true se a inserção for bem-sucedida
            }
            catch
            {
                return false; // Retorna false se ocorrer um erro
            }
        }

        /// <summary>
        /// Função para adicionar uma placa-mãe ao banco de dados 
        /// </summary>
        /// <param name="motherboard"></param>
        /// <param name="ProductId"></param>
        /// <returns></returns>

        public bool AddMotherboard(Motherboard motherboard, int ProductId)
        {
            try
            {
                // Estabelece a conexão com o banco de dados
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Consulta SQL para inserir uma nova placa-mãe
                    string query = "INSERT INTO Motherboard (ProductId, Socket, MemorySupport, FormFactor) " +
                                   "VALUES (@ProductId, @Socket, @MemorySupport, @FormFactor)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Adiciona os parâmetros à consulta
                        cmd.Parameters.AddWithValue("@ProductId", ProductId);
                        cmd.Parameters.AddWithValue("@Socket", motherboard.SocketMotherboard);
                        cmd.Parameters.AddWithValue("@MemorySupport", motherboard.MemorySupportMotherboard);
                        cmd.Parameters.AddWithValue("@FormFactor", motherboard.FormFactorMotherboard);

                        // Executa a consulta para inserir a placa-mãe
                        cmd.ExecuteNonQuery();
                    }
                }
                return true; // Retorna true se a inserção for bem-sucedida
            }
            catch
            {
                return false; // Retorna false se ocorrer um erro
            }
        }

        /// <summary>
        /// Função para adicionar uma RAM ao banco de dados 
        /// </summary>
        /// <param name="ram"></param>
        /// <param name="ProductId"></param>
        /// <returns></returns>

        public bool AddRam(RAM ram, int ProductId)
        {
            try
            {
                // Estabelece a conexão com o banco de dados
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Consulta SQL para inserir uma nova RAM
                    string query = "INSERT INTO Ram (ProductId, Capacity, Type, Frequency, Latency) " +
                                   "VALUES (@ProductId, @Capacity, @Type, @Frequency, @Latency)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Adiciona os parâmetros à consulta
                        cmd.Parameters.AddWithValue("@ProductId", ProductId);
                        cmd.Parameters.AddWithValue("@Capacity", ram.GetCapacity);
                        cmd.Parameters.AddWithValue("@Type", ram.GetType);
                        cmd.Parameters.AddWithValue("@Frequency", ram.GetFrequency);
                        cmd.Parameters.AddWithValue("@Latency", ram.GetLatency);

                        // Executa a consulta para inserir a RAM
                        cmd.ExecuteNonQuery();
                    }
                }
                return true; // Retorna true se a inserção for bem-sucedida
            }
            catch
            {
                return false; // Retorna false se ocorrer um erro
            }
        }

        /// <summary>
        /// Função para adicionar uma CPU ao banco de dados
        /// </summary>
        /// <param name="cpu"></param>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public bool AddCPU(Cpu cpu, int ProductId)
        {
            try
            {
                // Estabelece a conexão com o banco de dados
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Consulta SQL para inserir uma nova CPU
                    string query = "INSERT INTO Cpu (ProductId, Cache, Socket, MemorySupport, Frequency) " +
                                   "VALUES (@ProductId, @Cache, @Socket, @MemorySupport, @Frequency)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Adiciona os parâmetros à consulta
                        cmd.Parameters.AddWithValue("@ProductId", ProductId);
                        cmd.Parameters.AddWithValue("@Cache", cpu.GetCache);
                        cmd.Parameters.AddWithValue("@Socket", cpu.GetSocket);
                        cmd.Parameters.AddWithValue("@MemorySupport", cpu.GetMemorySupport);
                        cmd.Parameters.AddWithValue("@Frequency", cpu.GetFrequency);

                        // Executa a consulta para inserir a CPU
                        cmd.ExecuteNonQuery();
                    }
                }
                return true; // Retorna true se a inserção for bem-sucedida
            }
            catch
            {
                return false; // Retorna false se ocorrer um erro
            }
        }

        #endregion

        #region Adicionar Produto

        /// <summary>
        /// // Função para adicionar um produto à tabela StockTable e retornar o ID gerado
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>

        public int AddProductWithId(Produto produto)
        {
            // Consulta SQL para inserir um novo produto e retornar o ID gerado
            string query = "INSERT INTO StockTable (name, description, price, stock, brand, guarantee, type) " +
                "OUTPUT INSERTED.Id VALUES (@name, @description, @price, @stock, @brand, @guarantee, @type)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Adiciona os parâmetros à consulta
                    cmd.Parameters.AddWithValue("@name", produto.NomeProduto);
                    cmd.Parameters.AddWithValue("@description", produto.DescricaoProduto);
                    cmd.Parameters.AddWithValue("@price", produto.PrecoProduto);
                    cmd.Parameters.AddWithValue("@stock", produto.StockProduto);
                    cmd.Parameters.AddWithValue("@brand", produto.MarcaProduto);
                    cmd.Parameters.AddWithValue("@guarantee", produto.GarantiaMesesProdutos);
                    cmd.Parameters.AddWithValue("@type", produto.CategoriaProduto);

                    // Executa a consulta e retorna o ID do produto gerado
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Função para adicionar um novo produto ao banco de dados
        /// </summary>
        /// <param name="produto"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AddNewProduct(Produto produto)
        {
            // Adiciona o produto principal à tabela StockTable e obtém o ID gerado
            int ProductId = AddProductWithId(produto);

            // Adiciona as informações específicas de cada tipo de produto
            if (produto is Gpu gpu)
            {
                // Adiciona uma GPU ao banco de dados
                bool a = AddGpu(gpu, ProductId);
                if (a == false)
                {
                    throw new ArgumentException("Erro ao adicionar a GPU.");
                }
            }
            else if (produto is Cpu cpu)
            {
                // Adiciona uma CPU ao banco de dados
                bool b = AddCPU(cpu, ProductId);
                if (b == false)
                {
                    throw new ArgumentException("Erro ao adicionar CPU.");
                }
            }
            else if (produto is RAM ram)
            {
                // Adiciona uma RAM ao banco de dados
                bool c = AddRam(ram, ProductId);
                if (c == false)
                {
                    throw new ArgumentException("Erro ao adicionar RAM.");
                }
            }
            else if (produto is Motherboard motherboard)
            {
                // Adiciona uma placa-mãe ao banco de dados
                bool d = AddMotherboard(motherboard, ProductId);
                if (d == false)
                {
                    throw new ArgumentException("Erro ao adicionar placa-mãe.");
                }
            }
            else
            {
                // Lança uma exceção se o tipo de produto não for reconhecido
                throw new ArgumentException("Tipo de produto desconhecido.");
            }
        }
        #endregion

    }
}