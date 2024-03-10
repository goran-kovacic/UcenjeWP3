using ConsoleApp.KonzolnaZavrsni.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.KonzolnaZavrsni.Controller
{
    internal class PrintJobController
    {
        public List<PrintJob> printJobs { get; }
        private Menu Menu;

        public PrintJobController(Menu Menu) : this()
        {
            this.Menu = Menu;
            if (Helpers.Dev)
            {
                TestData();
            }
        }

        public PrintJobController()
        {
            printJobs = new List<PrintJob>();
        }

        internal void ShowMenu()
        {
            Console.WriteLine("\r\n  ____       _       _         _       _      " +
                "     __  __                  \r\n |  _ \\ _ __(_)_ __ | |_     " +
                " | | ___ | |__  ___  |  \\/  | ___ _ __  _   _ \r\n | |_) | '__" +
                "| | '_ \\| __|  _  | |/ _ \\| '_ \\/ __| | |\\/| |/ _ \\ '_ \\| " +
                "| | |\r\n |  __/| |  | | | | | |_  | |_| | (_) | |_) \\__ \\ | | " +
                " | |  __/ | | | |_| |\r\n |_|   |_|  |_|_| |_|\\__|  \\___/ \\___/|_" +
                ".__/|___/ |_|  |_|\\___|_| |_|\\__,_|\r\n                     " +
                "                                                      \r\n");
            Console.WriteLine("\t1. Show existing prints");
            Console.WriteLine("\t2. Create new print");
            Console.WriteLine("\t3. Edit existing print");
            Console.WriteLine("\t4. Delete print");
            Console.WriteLine("\t5. Return to Main Menu");

            switch (Helpers.NumberRange("Select menu item: ", "Selection must be 1 - 5", 1, 5))
            {
                case 1:
                    Console.Clear();
                    ShowPrintJobs();
                    ShowMenu();
                    break;
                case 2:
                    CreateNewPrintJob();
                    //Menu.UpdatePrintJobTestData();
                    Console.Clear();
                    ShowMenu();
                    break;
                    //case 3:
                    //    EditPart();
                    //Menu.UpdatePrintJobTestData();
                    //    Console.Clear();
                    //    ShowMenu();
                    //    break;
                    //case 4:
                    //    DeletePart();
                    //Menu.UpdatePrintJobTestData();
                    //    Console.Clear();
                    //    ShowMenu();
                    //    break;
                    //case 5:
                    //    Console.WriteLine("end");
                    //    break;
            }
        }

        private void CreateNewPrintJob()
        {
            
        }

        private void ShowPrintJobs()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("------ Prints -----");
            Console.WriteLine("-------------------");
            int counter = 1;
            printJobs.ForEach(pr => Console.WriteLine("{0}. {1}", counter++, pr));
            Console.WriteLine("------------------");
        }

        private void TestData()
        {
            printJobs.Add(new PrintJob
            {
                Id = 1,
                Material = Menu.MaterialController.Materials[0],
                Part = Menu.PartController.Parts[0],
                Printer = Menu.PrinterController.Printers[0],
                PrintTime = 2,
                Volume = 100
            });
        }
    }
}
