////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: BaseClass.cs
//FileType: Visual C# Source file
//Author : Joel Faria
//Description : ClassePai 
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Classes
{
    public class Produto
    {
        private string Nome { get; set; }
        private int Id { get; set; }
        private string Descricao { get; set; }
        private double Preco { get; set; }
        private string Cat { get; set; }
        private int Stock { get; set; }
        private string Marca { get; set; }
        private int garantiaMeses { get; set; }

        #region Construtores

        public Produto(string nome, string descricao, double preco, string cat, int stock, string marca, int garantia)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Cat = cat;
            Stock = stock;
            Marca = marca;
            garantiaMeses = garantia;
        }
        #endregion

        #region Propriedades
        public string NomeProduto
        {
            get { return Nome; }
            set { Nome = value; }
        }
        public string DescricaoProduto
        {
            get { return Descricao; }
            set { Descricao = value; }
        }
        public double PrecoProduto
        {
            get { return Preco; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Preço não pode ser negativo ou 0");
                }
                Preco = value;
            }
        }
        public string CategoriaProduto
        {
            get { return Cat; }
            set { Cat = value; }
        }
        public int StockProduto
        {
            get { return Stock; }
            set { Stock = value; }
        }
        public string MarcaProduto
        {
            get { return Marca; }
            set { Marca = value; }
        }
        public int GarantiaMesesProdutos
        {
            get { return garantiaMeses; }
            set { garantiaMeses = value; }
        }

        #endregion

    }

}

