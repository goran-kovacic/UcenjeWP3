using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class E09ForEach
    {
        public static void Izvedi()
        {
            string grad = "Osijek";

            foreach(var c in grad)
            {
                Console.WriteLine(c);
            }
        }
    }
}
