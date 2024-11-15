using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Motherboard = DLL_Classes.Motherboard;

namespace DLL_Classes
{
    public class Motherboard : Produto
    {
        private string Socket { get; set; }
        private int MemorySupport { get; set; }
        private string FormFactor { get; set; }

        public Motherboard(string socket, string chipset, int memorySupport, string formFactor, string nome, string descricao, double preco, string cat, int stock, string marca, int garantia)
            : base(nome, descricao, preco, cat, stock, marca, garantia)
        {
            this.Socket = socket;
            this.MemorySupport = memorySupport;
            this.FormFactor = formFactor;
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
        public string GetFormFactor
        {
            get { return FormFactor; }
            set { FormFactor = value; }
        }
    }
}
