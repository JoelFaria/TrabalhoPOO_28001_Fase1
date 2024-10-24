﻿////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: SubClasses.cs
//FileType: Visual C# Source file
//Author : Joel Faria
//Description : SubClasses 
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;

namespace TrabalhoPOO
{
    public class Gpu
    {
        private int VRAM { get; set; }
        private int BaseClock { get; set; }
        private int BoostClock { get; set; }
        private string MemoryType { get; set; }

        public Gpu(int vram, int baseClock, int boostClock, string memoryType)
        {
            this.VRAM = vram;
            this.BaseClock = baseClock;
            this.BoostClock = boostClock;
            this.MemoryType = memoryType;
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
        public string GetMemoryType
        {
            get { return MemoryType; }
            set { MemoryType = value; }
        }
    }
    public class cpu
    {
        private int Cache { get; set; }
        private string socket { get; set; }
        private int MemorySupport { get; set; }
        private int Frequency { get; set; }

        public cpu(int cache, string socket, int memorySupport, int frequency)
        {
            this.Cache = cache;
            this.socket = socket;
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
            get { return socket; }
            set { socket = value; }
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
    public class Motherboard
    {
        private string socket { get; set; }
        private string chipset { get; set; }
        private int MemorySupport { get; set; }
        private string FormFactor { get; set; }

        public Motherboard(string socket, string chipset, int memorySupport, string formFactor)
        {
            this.socket = socket;
            this.chipset = chipset;
            this.MemorySupport = memorySupport;
            this.FormFactor = formFactor;
        }
        public string GetSocket
        {
            get { return socket; }
            set { socket = value; }
        }
        public string GetChipset
        {
            get { return chipset; }
            set { chipset = value; }
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
