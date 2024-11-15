using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TrabalhoPOO
{
    public class Gpu : Produto
    {
        private int VRAM { get; set; }
        private int BaseClock { get; set; }
        private int BoostClock { get; set; }

        public Gpu(int vram, int baseClock, int boostClock, string nome, string descricao, double preco, string cat, int stock, string marca, int garantia)
            : base(nome, descricao, preco, cat, stock, marca, garantia)
        {
            this.VRAM = vram;
            this.BaseClock = baseClock;
            this.BoostClock = boostClock;
        }
        public int GetVRAM
        {
            get { return VRAM; }
            set { VRAM = value; }
        }
        public int GetBaseClock
        {
            get { return BaseClock; }
            set { BaseClock = value; }
        }
        public int GetBoostClock
        {
            get { return BoostClock; }
            set { BoostClock = value; }
        }
    }
}
