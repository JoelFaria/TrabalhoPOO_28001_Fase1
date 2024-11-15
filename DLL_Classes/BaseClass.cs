////////////////////////////////////////////////////////////////////////////////////////////////////////
// FileName: BaseClass.cs
// FileType: Visual C# Source File
// Author: Joel Faria
// Description: Classe base para representar um produto no sistema. Contém propriedades comuns a todos os produtos.
////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;

namespace TrabalhoPOO
{
    /// <summary>
    /// Classe base que representa um produto genérico no sistema.
    /// Inclui propriedades como Nome, Id, Descrição, Preço, Categoria, Stock, Marca e Garantia.
    /// </summary>
    public class Produto
    {
        // Propriedades privadas
        private string Nome { get; set; } // Nome do produto
        private int Id { get; set; } // Identificador único do produto
        private string Descricao { get; set; } // Descrição detalhada do produto
        private double Preco { get; set; } // Preço do produto
        private string Cat { get; set; } // Categoria do produto
        private int Stock { get; set; } // Quantidade em stock
        private string Marca { get; set; } // Marca do produto
        private int GarantiaMeses { get; set; } // Garantia em meses

        #region Construtores
        /// <summary>
        /// Construtor para inicializar as propriedades de um produto.
        /// </summary>
        /// <param name="nome">Nome do produto.</param>
        /// <param name="descricao">Descrição detalhada.</param>
        /// <param name="preco">Preço do produto.</param>
        /// <param name="cat">Categoria do produto.</param>
        /// <param name="stock">Quantidade em stock.</param>
        /// <param name="marca">Marca do produto.</param>
        /// <param name="garantia">Garantia do produto em meses.</param>
        public Produto(string nome, string descricao, double preco, string cat, int stock, string marca, int garantia)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Cat = cat;
            Stock = stock;
            Marca = marca;
            GarantiaMeses = garantia;
        }
        #endregion

        #region Propriedades Públicas
        /// <summary>
        /// Nome do produto (com validação no set).
        /// </summary>
        public string NomeProduto
        {
            get { return Nome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("O nome do produto não pode ser vazio.");
                }
                Nome = value;
            }
        }

        /// <summary>
        /// Descrição do produto.
        /// </summary>
        public string DescricaoProduto
        {
            get { return Descricao; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A descrição não pode ser vazia.");
                }
                Descricao = value;
            }
        }

        /// <summary>
        /// Preço do produto (com validação para não aceitar valores negativos ou zero).
        /// </summary>
        public double PrecoProduto
        {
            get { return Preco; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("O preço deve ser maior que zero.");
                }
                Preco = value;
            }
        }

        /// <summary>
        /// Categoria do produto.
        /// </summary>
        public string CategoriaProduto
        {
            get { return Cat; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A categoria não pode ser vazia.");
                }
                Cat = value;
            }
        }

        /// <summary>
        /// Quantidade de produtos em stock (com validação para aceitar apenas valores não negativos).
        /// </summary>
        public int StockProduto
        {
            get { return Stock; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("O stock não pode ser negativo.");
                }
                Stock = value;
            }
        }

        /// <summary>
        /// Marca do produto.
        /// </summary>
        public string MarcaProduto
        {
            get { return Marca; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A marca não pode ser vazia.");
                }
                Marca = value;
            }
        }

        /// <summary>
        /// Garantia do produto em meses.
        /// </summary>
        public int GarantiaMesesProdutos
        {
            get { return GarantiaMeses; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("A garantia não pode ser negativa.");
                }
                GarantiaMeses = value;
            }
        }
        #endregion
    }
}
