////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: BaseClass.cs
//FileType: Visual C# Source file
//Author : Joel Faria
//Description : ClassePai 
////////////////////////////////////////////////////////////////////////////////////////////////////////
using TrabalhoPOO;

namespace TrabalhoPOO
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
            this.Nome = nome;
            this.Descricao = descricao;
            this.Preco = preco;
            this.Cat = cat;
            this.Stock = stock;
            this.Marca = marca;
            this.garantiaMeses = garantia;
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
                if(value < 0)
                {
                    throw new System.ArgumentException("Preço não pode ser negativo ou 0");
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

    public class User 
    {
           public string Id { get; set; }
           public string Nome { get; set; }
           public string Email { get; set; }
           public string Password { get; set; }

        public User(string nome, string email, string password)
        {
           this.Nome = nome;
           this.Email = email;
           this.Password = password;
        }

        public string nomeUser
        {
            get { return Nome; }
            set { Nome = value; }
        }
        public string emailUser
        { 
           get { return Email; }
            set { Email = value; }
        }
        public string PasswordUser
        {
            get { return Password; }
            set { Password = value; }
        }

    }

}

