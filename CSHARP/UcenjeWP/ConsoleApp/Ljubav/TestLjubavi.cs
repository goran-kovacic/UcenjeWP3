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
            bool Dev = false;

            string Name1 = Dev ? "Marta" : LjubavHelpers.EnterName("Enter first name: ");
            string Name2 = Dev ? "Manuel" : LjubavHelpers.EnterName("Enter second name: ");
            string Name = Name1.ToLower().Trim() + Name2.ToLower().Trim();

            LjubavHelpers.printArrayList(LjubavHelpers.countLetters(Name)); //starting arraylist            
            Console.Write(Name1 + " i " + Name2 + " vole se " + 
                LjubavHelpers.ljubav(LjubavHelpers.countLetters(Name)) + "%!"); //recursion
            
        }

    }
}
