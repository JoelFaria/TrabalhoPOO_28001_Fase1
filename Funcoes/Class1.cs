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
    public class Funcoes
    {
        private string connectionString = "Data Source=JOELFARIA\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;TrustServerCertificate=True";

        public bool AddProduct(Produto produto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string querry = "INSERT INTO StockTable (Name, Description, Price, Type, Stock, Brand, Guarantee) VALUES (@Name, @Description, @Price, @Type, @Stock, @Brand, @Guarantee)";

                    using (SqlCommand cmd = new SqlCommand(querry, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", produto.NomeProduto);
                        cmd.Parameters.AddWithValue("@Description", produto.DescricaoProduto);
                        cmd.Parameters.AddWithValue("@Price", produto.PrecoProduto);
                        cmd.Parameters.AddWithValue("@Type", produto.CategoriaProduto);
                        cmd.Parameters.AddWithValue("@Stock", produto.StockProduto);
                        cmd.Parameters.AddWithValue("@Brand", produto.MarcaProduto);
                        cmd.Parameters.AddWithValue("@Guarantee", produto.GarantiaMesesProdutos);
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
    }

}
