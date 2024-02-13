using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Z05
    {
        public static void Izvedi()
        {
            //int min = int.MaxValue;
            //int broj = 0;
            //while (true)
            //{

            //    Console.Write("unesi cijeli broj: ");
            //    broj = int.Parse(Console.ReadLine());
            //    if(broj == -1)
            //    {
            //        break;
            //    }
            //    if(broj < min)
            //    {
            //        min = broj;
            //    }
            //}
            //Console.WriteLine(min);

            Console.WriteLine("unesi broj: ");
            int br = int.Parse(Console.ReadLine());
            bool prim = true;
            for(int i = 2; i < br; i++)
            {
                if (br % i == 0)
                {
                    prim = false;
                    break;
                }
            }
            Console.WriteLine(br + " " + (prim ? "je " : "nije ") + "prime broj");
        }
    }
}
