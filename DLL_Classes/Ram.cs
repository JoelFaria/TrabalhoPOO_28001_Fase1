using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPOO
{
    public class RAM : Produto
    {
        private int Capacity { get; set; }
        private string Type { get; set; }
        private int Frequency { get; set; }
        private int Latency { get; set; }

        public RAM(int capacity, string type, int frequency, int latency, string nome, string descricao, double preco, string cat, int stock, string marca, int garantia)
            : base(nome, descricao, preco, cat, stock, marca, garantia)
        {
            this.Capacity = capacity;
            this.Type = type;
            this.Frequency = frequency;
            this.Latency = latency;
        }
        public int GetCapacity
        {
            get { return Capacity; }
            set { Capacity = value; }
        }
        public string GetType
        {
            get { return Type; }
            set { Type = value; }
        }
        public int GetFrequency
        {
            get { return Frequency; }
            set { Frequency = value; }
        }
        public int GetLatency
        {
            get { return Latency; }
            set { Latency = value; }
        }
    }
}
