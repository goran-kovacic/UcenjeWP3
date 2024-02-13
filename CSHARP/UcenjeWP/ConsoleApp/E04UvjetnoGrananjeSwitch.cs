using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class E04UvjetnoGrananjeSwitch
    {
        public static void Izvedi()
        {
            Console.Write("Unesi ime grada: ");
            string grad = Console.ReadLine();

            switch (grad)
            {
                case "Osijek":
                case "Vukovar":
                    Console.WriteLine("Slavonija");
                    break;
                case "Split":
                case "Zadar":
                    Console.WriteLine("Dalmacija");
                    break;
            }
        }
    }
}
