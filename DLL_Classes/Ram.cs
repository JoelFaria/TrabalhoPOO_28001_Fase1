////////////////////////////////////////////////////////////////////////////////////////////////////////
// FileName: BaseClass.cs
// FileType: Visual C# Source File
// Author: Joel Faria
// Description: Classe para representar uma memória RAM no sistema. Derivada da classe Produto.
////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;

namespace TrabalhoPOO
{
    /// <summary>
    /// Classe que representa uma memória RAM, derivada da classe Produto.
    /// Contém propriedades específicas como Capacidade, Tipo, Frequência e Latência.
    /// </summary>
    public class RAM : Produto
    {
        private int Capacity { get; set; }
        private string Type { get; set; }
        private int Frequency { get; set; }
        private int Latency { get; set; }

        #region Construtores
        /// <summary>
        /// Construtor para inicializar uma nova memória RAM.
        /// </summary>
        /// <param name="capacity">Capacidade da RAM em GB.</param>
        /// <param name="type">Tipo de memória RAM (ex.: DDR4, DDR5).</param>
        /// <param name="frequency">Frequência da RAM em MHz.</param>
        /// <param name="latency">Latência da RAM em CL.</param>
        /// <param name="nome">Nome do produto.</param>
        /// <param name="descricao">Descrição do produto.</param>
        /// <param name="preco">Preço do produto.</param>
        /// <param name="cat">Categoria do produto.</param>
        /// <param name="stock">Quantidade em stock.</param>
        /// <param name="marca">Marca do produto.</param>
        /// <param name="garantia">Garantia do produto em meses.</param>
        public RAM(int capacity, string type, int frequency, int latency, string nome, string descricao, double preco, string cat, int stock, string marca, int garantia)
            : base(nome, descricao, preco, cat, stock, marca, garantia)
        {
            Capacity = capacity;
            Type = type;
            Frequency = frequency;
            Latency = latency;
        }

        #endregion

        #region Propriedades Públicas
        /// <summary>
        /// Capacidade da RAM em GB (com validação no set).
        /// </summary>
        public int GetCapacity
        {
            get { return Capacity; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("A capacidade deve ser maior que zero.");
                }
                Capacity = value;
            }
        }

        /// <summary>
        /// Tipo de RAM (ex.: DDR4, DDR5) (com validação no set).
        /// </summary>
        public string GetType
        {
            get { return Type; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("O tipo de RAM não pode ser vazio.");
                }
                Type = value;
            }
        }

        /// <summary>
        /// Frequência da RAM em MHz (com validação no set).
        /// </summary>
        public int GetFrequency
        {
            get { return Frequency; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("A frequência deve ser maior que zero.");
                }
                Frequency = value;
            }
        }

        /// <summary>
        /// Latência da RAM em CL (com validação no set).
        /// </summary>
        public int GetLatency
        {
            get { return Latency; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("A latência não pode ser negativa.");
                }
                Latency = value;
            }
        }
        #endregion
    }
}
