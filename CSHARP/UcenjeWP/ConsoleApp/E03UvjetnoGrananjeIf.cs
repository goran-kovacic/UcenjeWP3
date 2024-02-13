using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class E03UvjetnoGrananjeIf
    {

        public static void Izvedi()
        {
            int i = 8;
            bool uvjet = i == 7;

            if (uvjet)
            {
                Console.WriteLine("1. Ušao sam u if granu");
            }


            // ako se if odnosi na jednu liniju i ne trebaju {}
            if (uvjet)
                Console.WriteLine("2. Bez {}");
            Console.WriteLine("3. Ovo će se uvijek ispisati");


            // primjer kako se inače piše if
            if (i > 0)
            {
                Console.WriteLine("4. i je veće od 0");
            }

            var j = 5;

            i = 6;
            // dodatni operatori: and (&)
            if (i == 7 & j == 5)
            {
                Console.WriteLine("5. zadovoljena su oba uvjeta");
            }

            // razlika između & i &&
            // & uvijek se provjeravaju oba uvjeta
            // && ukoliko prvi uvjet nije zadovoljen, drugi se ne provjerava
            if (i == 7 && j == 5)
            {
                Console.WriteLine("6. Oba uvjeta su zadovoljena");
            }
            else // neobavezni dio if naredbe
            {
                Console.WriteLine("7. Jedan od uvjeta nije bio zadovoljen");
            }

            // logičko ili ALTGR+W |
            // | uvijek se provjeravaju oba uvjeta
            // || ukoliko je prvi uvjet zadovoljen, drugi se ne provjerava
            if (i == 7 || j == 5)
            {
                Console.WriteLine("8. Jedan ili oba uvjeta su zadovoljena");
            }
            else
            {
                Console.WriteLine("9. Niti jedan uvjet nije zadovoljen");
            }

            // logično not !

            // jedan kompliciran izraz
            if ((i > 0 && i < 10) || !(i < 5))
            {
                Console.WriteLine("10. Zadovoljen kompliciran uvjet");
            }

            i = 5;
            if (i == 1)
            {
                Console.WriteLine("11. i je 1");
            }
            else if (i == 2)
            {
                Console.WriteLine("12. i je 2");
            }
            // else if može biti koliko želimo
            else
            {
                Console.WriteLine("13. i nije 1 ili 2");
            }


            // inline if
            // kada if poziva istu naredbu s različitim parametrim
            if (i == 3)
            {
                Console.WriteLine("14. i je 3");
            }
            else
            {
                Console.WriteLine("15. i nije 3");
            }

            Console.WriteLine(i == 3 ? "14. i je 3" : "15. i nije 3");


            // ugnježđivanje
            if (i == 4)
            {
                if (j < 9)
                {
                    Console.WriteLine("16. ugnježđeni if");
                }
            }
        }
        


    }
}
