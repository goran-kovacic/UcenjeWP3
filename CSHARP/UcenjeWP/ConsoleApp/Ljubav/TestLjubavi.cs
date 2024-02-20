using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Ljubav
{
    internal class TestLjubavi
    {

        public static void Run()
        {

            bool Dev = true;

            string Name1 = Dev ? "Marta" : LjubavHelpers.EnterName("Enter first name: ");
            string Name2 = Dev ? "Manuel" : LjubavHelpers.EnterName("Enter second name: ");
            string Name = Name1.ToLower().Trim() + Name2.ToLower().Trim();
            
            var StartingArrayList = new ArrayList();

            int counter;
            char letter;

            Console.WriteLine(Name[1]);

            foreach (char c in Name)
            {
                letter = c;
                counter = 0;
                foreach (char c2 in Name)
                {
                    if (c2 == letter)
                    {
                        counter++;
                    }
                }
                StartingArrayList.Add(counter);                
            }
            foreach(var item in StartingArrayList)
            {
                Console.Write(item + " ");
            }



        }

    }
}
