using ConsoleApp.KonzolnaZavrsni.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.KonzolnaZavrsni.Controller
{
    internal class PrinterController
    {
        public List<Printer> Printers { get; }
        private Menu Menu;

        public PrinterController(Menu Menu) : this()
        {
            this.Menu = Menu;
            if (Helpers.Dev)
            {
                TestData();
            }
        }
        public PrinterController()
        {
            Printers = new List<Printer>();
        }

        internal void ShowMenu()
        {
            Console.WriteLine("\r\n  ____       _       _                  __  __             " +
                "     \r\n |  _ \\ _ __(_)_ __ | |_ ___ _ __ ___  |  \\/  | ___ _ __  _ " +
                "  _ \r\n | |_) | '__| | '_ \\| __/ _ \\ '__/ __| | |\\/| |/ _ \\ '_ \\| | " +
                "| |\r\n |  __/| |  | | | | | ||  __/ |  \\__ \\ | |  | |  __/ | | | |_| |\r\n |_" +
                "|   |_|  |_|_| |_|\\__\\___|_|  |___/ |_|  |_|\\___|_| |_|\\__,_|\r\n    " +
                "                                                            \r\n");
            Console.WriteLine("\t1. Show existing printers");
            Console.WriteLine("\t2. Create new printer");
            Console.WriteLine("\t3. Edit existing printer");
            Console.WriteLine("\t4. Delete printer");
            Console.WriteLine("\t5. Return to Main Menu");

            switch (Helpers.NumberRange("Select menu item: ", "Selection must be 1 - 5", 1, 5))
            {
                case 1:
                    Console.Clear();
                    ShowPrinters();
                    ShowMenu();
                    break;
                case 2:
                    CreateNewPrinter();
                    Console.Clear();
                    ShowPrinters();
                    ShowMenu();
                    break;
                case 3:
                    EditPrinter();
                    Console.Clear();
                    ShowPrinters();
                    ShowMenu();
                    break;
                case 4:
                    DeletePrinter();
                    Console.Clear();
                    ShowPrinters();
                    ShowMenu();
                    break;
                case 5:
                    Console.WriteLine("end");
                    break;
            }
        }

        private void DeletePrinter()
        {
            ShowPrinters();
            int index = Helpers.NumberRange("Select printer (Enter to cancel): ", "invalid input", 1, Printers.Count(), "");
            if(index == 0)
            {
                return;
            }
            if(Helpers.InputBool("Are you sure you want to delete? ('Yes' to delete, any other input to continue: "))
            {
                Printers.RemoveAt(index - 1);
            }
            
        }

        private void EditPrinter()
        {
            ShowPrinters();
            int index = Helpers.NumberRange("Select printer: ", "Invalid input", 1, Printers.Count());
            var p = Printers[index - 1];

            int newId = Helpers.EditInt("Input printer id (" + p.Id + ") (Enter to skip): ", "Invalid input", "");
            while (Printers.Exists(pr => pr.Id == newId && pr != p))
            {
                Console.WriteLine("Existing ID!");
                newId = Helpers.EditInt("Input printer id (" + p.Id + ") (Enter to skip): ", "Invalid input", "");
            }
            p.Id = newId == 0 ? p.Id : newId;
            Console.WriteLine();

            string newName = Helpers.EditString("Printer name(" + p.PrinterName + "): ", "Invalid input");
            p.PrinterName = newName == "" ? p.PrinterName : newName;

            string newManufacturer = Helpers.EditString("Project name(" + p.Manufacturer + "): ", "Invalid input");
            p.Manufacturer = newManufacturer == "" ? p.Manufacturer : newManufacturer;
        }

        private void CreateNewPrinter()
        {
            var p = new Printer();

            int id = Helpers.InputInt("Enter id: ", "Must be positive integer");
            while (Printers.Exists(pr => pr.Id == id))
            {
                Console.WriteLine("Existing id!");
                id = Helpers.InputInt("Enter id: ", "Must be positive integer");
            }
            p.Id = id;
            p.PrinterName = Helpers.InputString("Printer name: ", "Invalid input");
            p.Manufacturer = Helpers.InputString("Manufacturer: ", "Invalid input");
            Printers.Add(p);
        }

        public void ShowPrinters()
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("------ Printers -----");
            Console.WriteLine("---------------------");
            int counter = 1;
            Printers.ForEach(pf => Console.WriteLine("{0}. {1}", counter++, pf));
            Console.WriteLine("------------------");
        }

        private void TestData()
        {
            Printers.Add(new Printer()
            {
                Id = 1,
                PrinterName = "Test_Printer",
                Manufacturer = "Elegoo"
            });
        }
    }
}
