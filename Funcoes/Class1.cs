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
                    string querry = "UPDATE StockTable SET Name = @Name, Description = @Description, Price = @Price, Type = @Type, Stock = @Stock, Brand = @Brand, Guarantee = @Guarantee WHERE Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(querry, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", produto.NomeProduto);
                        cmd.Parameters.AddWithValue("@Description", produto.DescricaoProduto);
                        cmd.Parameters.AddWithValue("@Price", produto.PrecoProduto);
                        cmd.Parameters.AddWithValue("@Type", produto.CategoriaProduto);
                        cmd.Parameters.AddWithValue("@Stock", produto.StockProduto);
                        cmd.Parameters.AddWithValue("@Brand", produto.MarcaProduto);
                        cmd.Parameters.AddWithValue("@Guarantee", produto.GarantiaMesesProdutos);
                        cmd.Parameters.AddWithValue("@Id", Id);
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
                    string query = "INSERT INTO Gpu (ProdutoId, VRAM, BaseClock, BoostClock) " +
                          "VALUES (@ProdutoId, @VRAM, @BaseClock, @BoostClock)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProdutoId", ProductId);
                        cmd.Parameters.AddWithValue("@VRAM", gpu.GetVRAM);
                        cmd.Parameters.AddWithValue("@BaseClock", gpu.GetBaseClock);
                        cmd.Parameters.AddWithValue("@BoostClock", gpu.GetBoostClock);

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
                    string query = "INSERT INTO Motherboard (ProdutoId, Socket, MemorySupport, FormFactor) " +
                          "VALUES (@ProdutoId, @Socket, @MemorySupport, @FormFactor)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProdutoId", ProductId);
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
                    string query = "INSERT INTO Ram (ProdutoId, Capacity, Type, Frequency, Latency) " +
                          "VALUES (@ProdutoId, @Capacity, @Type, @Frequency, @Latency)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProdutoId", ProductId);
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

        public bool AddCPU(Cpu cpu, int produtoId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Cpu (ProdutoId, Cache, Socket, MemorySupport, Frequency) " +
                                   "VALUES (@ProdutoId, @Cache, @Socket, @MemorySupport, @Frequency)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProdutoId", produtoId); // Usando o ProdutoId
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
            int produtoId = AddProductWithId(produto);

            // Adicionar as informações específicas de cada tipo de produto
            if (produto is Gpu gpu)
            {
                AddGpu(gpu, produtoId);
            }
            else if (produto is Cpu cpu)
            {
                AddCPU(cpu, produtoId);
            }
            else if (produto is RAM ram)
            {
                AddRam(ram, produtoId);
            }
            else if (produto is Motherboard motherboard)
            {
                AddMotherboard(motherboard, produtoId);
            }
            else
            {
                // Caso o tipo de produto não seja reconhecido
                throw new ArgumentException("Tipo de produto desconhecido.");
            }
        }


    }
}
