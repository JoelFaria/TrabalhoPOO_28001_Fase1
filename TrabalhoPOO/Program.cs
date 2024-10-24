using System;

namespace TrabalhoPOO
{
    public class Program
    {
        public static void Main() 
        { 
            Produto produto = new Produto("n",3, "d", 4.5, "e", 4, "o", 4);
            produto.PrintDetails();
           
        }
    }
}