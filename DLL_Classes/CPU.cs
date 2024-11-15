using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cpu = DLL_Classes.Cpu;

namespace DLL_Classes
{
    public class Cpu : Produto
    {
        private int Cache { get; set; }
        private string Socket { get; set; }
        private int MemorySupport { get; set; }
        private int Frequency { get; set; }

        public Cpu(int cache, string socket, int memorySupport, int frequency, string nome, string descricao, double preco, string cat, int stock, string marca, int garantia)
            : base(nome, descricao, preco, cat, stock, marca, garantia)
        {
            this.Cache = cache;
            this.Socket = socket;
            this.MemorySupport = memorySupport;
            this.Frequency = frequency;
        }
        public int GetCache
        {
            get { return Cache; }
            set { Cache = value; }
        }
        public string GetSocket
        {
            get { return Socket; }
            set { Socket = value; }
        }
        public int GetMemorySupport
        {
            get { return MemorySupport; }
            set { MemorySupport = value; }
        }
        public int GetFrequency
        {
            get { return Frequency; }
            set { Frequency = value; }
        }
    }
}
