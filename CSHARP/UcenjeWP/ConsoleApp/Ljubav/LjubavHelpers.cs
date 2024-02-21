using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        internal static ArrayList countLetters(string Name)
        {
            var StartingArrayList = new ArrayList();
            int counter;
            foreach (char c in Name)
            {
                counter = 0;
                foreach (char c2 in Name)
                {
                    if (c2 == c)
                    {
                        counter++;
                    }
                }
                StartingArrayList.Add(counter);
            }
            return getSingleDigits(StartingArrayList);
        }

        internal static int ljubav(ArrayList arlist)
        {
            if (arlist.Count == 3 && (int)arlist[0] == 1 && (int)arlist[1] == 0 && (int)arlist[2] == 0)
                return 100;
            if(arlist.ToArray().Length < 3)
            {
                string s = "";
                foreach(int i in arlist.ToArray())
                {
                    s += i;
                }
                if (Int32.Parse(s) < 100)
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
            printArrayList(getSingleDigits(result));
            return ljubav(getSingleDigits(result));
        }

        internal static ArrayList getSingleDigits(ArrayList list)
        {
            ArrayList newList = new ArrayList();
            foreach(int item in list)
            {
                if(item >= 10)
                {
                    newList.Add(item / 10);
                    newList.Add(item % 10);
                }else if (item < 10)
                {
                    newList.Add(item);
                }
            }

            return newList;
        }

        internal static void printArrayList(ArrayList list)
        {
            foreach (int item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
