using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class E05Nizovi
    {
        public static void Izvedi()
        {
            int[] Temperature = new int[6];
            Temperature[0] = 1;
            Temperature[Temperature.Length - 1] = 2;
            Console.WriteLine(Temperature);
            Console.WriteLine(string.Join(",",Temperature));

            int[] brojevi = { 2, 3, 4, 5, 6, 7, 8 };
            Console.WriteLine(string.Join(", ", brojevi));

            int[,] tablica =
            {
                {1,2,3 },
                {1,3,3 },
                {3,2,1 }

            };
            Console.WriteLine(tablica[1,2]);

        }

    }
}
