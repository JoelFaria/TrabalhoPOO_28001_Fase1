////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName: Program.cs
//FileType: Visual C# Source file
//Author : Joel Faria
//Description : Main
////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;

namespace TrabalhoPOO
{
    public class Program
    {
        public static void Main() 
        { 


            Gpu gpu = new Gpu(4, 4, 4, "e", 6, "o", -4, "e", 4, "o", 4);
            gpu.PrintDetails();
           
        }
    }
}