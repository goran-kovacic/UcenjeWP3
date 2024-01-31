using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class E02VarijableTipoviPodatakaOperatori
    {

        public static void Izvedi()
        {

            int k = 2, l = 2;
            Console.WriteLine(k!=l);
            Console.WriteLine("{0} {1} {2} {3}", k>l, k>=l, k<l, k<=l);

            int x = 2, y = 1;
            x = x + ++y;
            y = --x;
            Console.WriteLine(x+y);

        }

    }
}
