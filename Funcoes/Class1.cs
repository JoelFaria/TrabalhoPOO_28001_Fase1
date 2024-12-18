using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using TrabalhoPOO;

namespace Funcoes
{
    public class Funcoes1
    {
        private const string connectionString = "Data Source=JOELFARIA\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;TrustServerCertificate=True";

        public int AddProductWithId(Produto produto)
        {
            string query = "INSERT INTO StockTable (name, description, price, stock, brand, guarantee, type) OUTPUT INSERTED.Id VALUES (@name, @description, @price, @stock, @brand, @guarantee, @type)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", produto.NomeProduto);
                    cmd.Parameters.AddWithValue("@description", produto.DescricaoProduto);
                    cmd.Parameters.AddWithValue("@price", produto.PrecoProduto);
                    cmd.Parameters.AddWithValue("@stock", produto.StockProduto);
                    cmd.Parameters.AddWithValue("@brand", produto.MarcaProduto);
                    cmd.Parameters.AddWithValue("@guarantee", produto.GarantiaMesesProdutos);
                    cmd.Parameters.AddWithValue("@type", produto.CategoriaProduto);

                    // Retorna o ID do produto gerado
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public bool UpdateProduct(Produto produto, int Id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Atualizar tabela StockTable
                    string queryStock = "UPDATE StockTable SET Name = @Name, Description = @Description, Price = @Price, " +
                                        "Type = @Type, Stock = @Stock, Brand = @Brand, Guarantee = @Guarantee WHERE Id = @Id";

                    using (SqlCommand cmdStock = new SqlCommand(queryStock, conn))
                    {
                        cmdStock.Parameters.AddWithValue("@Name", produto.NomeProduto);
                        cmdStock.Parameters.AddWithValue("@Description", produto.DescricaoProduto);
                        cmdStock.Parameters.AddWithValue("@Price", produto.PrecoProduto);
                        cmdStock.Parameters.AddWithValue("@Type", produto.CategoriaProduto);
                        cmdStock.Parameters.AddWithValue("@Stock", produto.StockProduto);
                        cmdStock.Parameters.AddWithValue("@Brand", produto.MarcaProduto);
                        cmdStock.Parameters.AddWithValue("@Guarantee", produto.GarantiaMesesProdutos);
                        cmdStock.Parameters.AddWithValue("@Id", Id); // Adicionado corretamente

                        cmdStock.ExecuteNonQuery();
                    }

                    // Atualizar tabela específica com base no tipo do produto
                    switch (produto)
                    {
                        case Gpu gpu:
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
                            throw new ArgumentException("Tipo de produto desconhecido.");
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao atualizar o produto.", ex);
                return false;
            }
        }


        public bool DeleteProduct(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string querry = "DELETE FROM StockTable WHERE Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(querry, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();

                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool AddGpu(Gpu gpu, int ProductId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Gpu (ProductId, VRAM, BaseClock, OverClock) " +
                          "VALUES (@ProductId, @VRAM, @BaseClock, @OverClock)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductId", ProductId);
                        cmd.Parameters.AddWithValue("@VRAM", gpu.GetVRAM);
                        cmd.Parameters.AddWithValue("@BaseClock", gpu.GetBaseClock);
                        cmd.Parameters.AddWithValue("@OverClock", gpu.GetBoostClock);

                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddMotherboard(Motherboard motherboard, int ProductId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Motherboard (ProductId, Socket, MemorySupport, FormFactor) " +
                          "VALUES (@ProductId, @Socket, @MemorySupport, @FormFactor)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductId", ProductId);
                        cmd.Parameters.AddWithValue("@Socket", motherboard.SocketMotherboard);
                        cmd.Parameters.AddWithValue("@MemorySupport", motherboard.MemorySupportMotherboard);
                        cmd.Parameters.AddWithValue("@FormFactor", motherboard.FormFactorMotherboard);

                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddRam(RAM ram, int ProductId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Ram (ProductId, Capacity, Type, Frequency, Latency) " +
                          "VALUES (@ProductId, @Capacity, @Type, @Frequency, @Latency)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductId", ProductId);
                        cmd.Parameters.AddWithValue("@Capacity", ram.GetCapacity);
                        cmd.Parameters.AddWithValue("@Type", ram.GetType);
                        cmd.Parameters.AddWithValue("@Frequency", ram.GetFrequency);
                        cmd.Parameters.AddWithValue("@Latency", ram.GetLatency);

                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddCPU(Cpu cpu, int ProductId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Cpu (ProductId, Cache, Socket, MemorySupport, Frequency) " +
                                   "VALUES (@ProductId, @Cache, @Socket, @MemorySupport, @Frequency)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductId", ProductId); // Usando o ProductId
                        cmd.Parameters.AddWithValue("@Cache", cpu.GetCache);
                        cmd.Parameters.AddWithValue("@Socket", cpu.GetSocket);
                        cmd.Parameters.AddWithValue("@MemorySupport", cpu.GetMemorySupport);
                        cmd.Parameters.AddWithValue("@Frequency", cpu.GetFrequency);

                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void AddNewProduct(Produto produto)
        {
            // Adicionar o produto principal à tabela Produto
            int ProductId = AddProductWithId(produto);

            // Adicionar as informações específicas de cada tipo de produto
            if (produto is Gpu gpu)
            {
                bool a = AddGpu(gpu, ProductId);
                if(a == false)
                {
                    throw new ArgumentException("Erro ao adicionar a GPU.");
                }
            }
            else if (produto is Cpu cpu)
            {
               bool b = AddCPU(cpu, ProductId);
                if (b == false)
                {
                    throw new ArgumentException("Erro ao adicionar Cpu");
                }

            }
            else if (produto is RAM ram)
            {
               bool c = AddRam(ram, ProductId);
                if (c == false)
                {
                    throw new ArgumentException("Erro ao adicionar Ram");
                }

            }
            else if (produto is Motherboard motherboard)
            {
                bool d = AddMotherboard(motherboard, ProductId);
                if (d == false)
                {
                    throw new ArgumentException("Erro ao adicionar Motherboard");
                }
            }
            else
            {
                // Caso o tipo de produto não seja reconhecido
                throw new ArgumentException("Tipo de produto desconhecido.");
            }
        }


    }
}
