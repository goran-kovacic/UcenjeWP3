using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Ljubav
{
    internal class LjubavHelpers
    {

        internal static string EnterName(string message)
        {
            string name;
            while (true)
            {
                try
                {
                    Console.WriteLine(message);
                    return name = Console.ReadLine().Trim().ToLower();                    
                }
                catch(Exception) 
                {
                        
                }
            }                        
        }





    }
}
