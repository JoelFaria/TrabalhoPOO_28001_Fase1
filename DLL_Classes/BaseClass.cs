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

        public Produto(string nome, int id, string descricao, double preco, string cat, int stock, string marca, int garantia)
        {
            this.Nome = nome;
            this.Id = id;
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
        public int IdProduto
        {
            get { return Id; }
            set { Id = value; }
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

        public virtual void PrintDetails()
        {
            Console.WriteLine($"Nome: {this.Nome}, Id: {this.Id}, Descrição: {this.Descricao}, Preço: {this.Preco}, Categoria: {this.Cat}, Stock: {this.Stock}, Marca:{this.Marca}, Garantia:{this.garantiaMeses}");
        }
    }

    public class Usuario 
    {
       /// public string Id { get; set; }
        public string Nome { get; set; }
       // public string Email { get; set; }
        public string Senha { get; set; }

        public Usuario(/*string id,*/ string nome,/* string email*/ string senha)
        {
           // this.Id = id;
            this.Nome = nome;
           // this.Email = email;
            this.Senha = senha;
        }

       //public string idUsuario
       // {
       //     get { return Id; }
       //     set { Id = value; }
       // }
        public string nomeUsuario
        {
            get { return Nome; }
            set { Nome = value; }
        }
        //public string emailUsuario
        //{
        //    get { return Email; }
        //    set { Email = value; }
        //}
        public string senhaUsuario
        {
            get { return Senha; }
            set { Senha = value; }
        }

    }

}

