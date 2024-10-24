////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: SubClasses.cs
//FileType: Visual C# Source file
//Author : Joel Faria
//Description : SubClasses 
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;

namespace TrabalhoPOO
{
    public class Gpu : Produto
    {
        private int VRAM { get; set; }
        private int BaseClock { get; set; }
        private int BoostClock { get; set; }

        public Gpu(int vram, int baseClock, int boostClock, string nome, int id, string descricao, double preco, string cat, int stock, string marca, int garantia)
            : base(nome, id, descricao, preco, cat, stock, marca, garantia)
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

        public override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine($"VRAM: {this.VRAM}, BaseClock: {this.BaseClock}, BoostClock: {this.BoostClock}");
        }

    }
    public class cpu : Produto
    {
        private int Cache { get; set; }
        private string Socket { get; set; }
        private int MemorySupport { get; set; }
        private int Frequency { get; set; }

        public cpu(int cache, string socket, int memorySupport, int frequency, string nome, int id, string descricao, double preco, string cat, int stock, string marca, int garantia)
            : base(nome, id, descricao, preco, cat, stock, marca, garantia)
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
        public override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine($"Cache: {this.Cache}, Socket: {this.Socket}, MemorySuport: {this.MemorySupport}, Frequency: {this.Frequency}");
        }
    }
    public class Motherboard : Produto
    {
        private string Socket { get; set; }
        private int MemorySupport { get; set; }
        private string FormFactor { get; set; }

        public Motherboard(string socket, string chipset, int memorySupport, string formFactor, string nome, int id, string descricao, double preco, string cat, int stock, string marca, int garantia)
            : base(nome, id, descricao, preco, cat, stock, marca, garantia)
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
        public override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine($"Socket: {this.Socket}, MemorySuport: {this.MemorySupport}, FormFactor: {this.FormFactor}");
        }
    }
    public class RAM : Produto
    {
        private int Capacity { get; set; }
        private string Type { get; set; }
        private int Frequency { get; set; }
        private int Latency { get; set; }

        public RAM(int capacity, string type, int frequency, int latency, string nome, int id, string descricao, double preco, string cat, int stock, string marca, int garantia)
            : base(nome, id, descricao, preco, cat, stock, marca, garantia)
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
        public override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine($"Capacity: {this.Capacity}, Type: {this.Type}, Frequency: {this.Frequency}, Latency: {this.Latency}");
        }
    }
}