using System;
using System.Collections;
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

        internal static int ljubav(ArrayList arlist)
        {
            if(arlist.ToArray().Length < 3)
            {
                string s = "555";
                foreach(int i in arlist.ToArray())
                {
                    s += i;
                }
                if (Int32.Parse(s) > 3)
                {
                    return Int32.Parse(s);
                }
            }

            ArrayList result = new ArrayList();

            for (int i = 0, j = arlist.Count - 1; i <= j; i++, j--)
            {
                int sum = 0;
                sum = i != j ? (int)arlist[i] + (int)arlist[j] : (int)arlist[i];

                result.Add(sum);
            }

            foreach (var item in result)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            return ljubav(result);
        }

        internal static int getSingleDigits()
        {
            return 0;
        }

    }
}
