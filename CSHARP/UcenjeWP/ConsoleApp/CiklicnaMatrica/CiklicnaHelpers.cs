using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.CiklicnaMatrica
{
    internal class CiklicnaHelpers
    {

        internal static int InputPositiveInteger(string message)
        {
            bool isValidInput=false;
            int value=0;
            while (!isValidInput)
            {
                try
                {
                    Console.WriteLine(message);
                    value = int.Parse(Console.ReadLine());                    
                    if (value < 1)
                    {
                        Console.WriteLine("Enter a positive integer!");
                        continue;
                    }                    
                    isValidInput = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input");
                }                
            }
            return value;
        }

        internal static int InputInteger(string message)
        {            
            while (true)
            {
                Console.WriteLine(message);
                try
                {
                    return int.Parse(Console.ReadLine());
                }
                catch(Exception)
                {
                    Console.WriteLine("Enter an integer!");
                }
            }            
        }
    }
}
