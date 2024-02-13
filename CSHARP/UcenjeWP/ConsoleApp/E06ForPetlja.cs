using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp
{
    internal class E06ForPetlja
    {
        public static void Izvedi()
        {
            //int[] niz = { 1, 2, 3, 44};

            
            //for (int i = 0; i < niz.Length; i++)
            //{
            //    Console.WriteLine(niz[i]);
            //}

            //for (int i = 1; i <= 10; i++)
            //{
            //    for (int j = 1; j <= 10; j++)
            //    {
                    
            //        Console.Write($"{i*j,4}");
            //    }
            //    Console.WriteLine();
            //}

            int i, s = 0; for (i = 1; i <= 100; i++) s += 1;
            
            Console.WriteLine(s);

        }




    }
}
