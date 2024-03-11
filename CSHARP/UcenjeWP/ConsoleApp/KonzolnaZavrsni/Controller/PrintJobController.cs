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
                case 3:
                    EditPart();
                    //Menu.UpdatePrintJobTestData();
                    Console.Clear();
                    ShowMenu();
                    break;
                case 4:
                    DeletePart();
                    //Menu.UpdatePrintJobTestData();
                    Console.Clear();
                    ShowMenu();
                    break;
                case 5:
                    Console.WriteLine("end");
                    break;
            }
        }

        private void DeletePart()
        {
            ShowPrintJobs();
            int index = Helpers.NumberRange("Select print: ", "invalidinput", 1, printJobs.Count(), "");
            if (index == 0)
            {
                return;
            }
            if (Helpers.InputBool("Are you sure you want to delete? ('Yes' to delete, any other input to continue): "))
            {
                printJobs.RemoveAt(index - 1);
            }
        }

        private void EditPart()
        {
            ShowPrintJobs();
            int index = Helpers.NumberRange("Select print: ", "invalidinput", 1, printJobs.Count());
            var p = printJobs[index-1];

            int newId = Helpers.EditInt("Input id (" + p.Id + "): ", "Invalid input", "");
            while (printJobs.Exists(part => part.Id == newId && part != p))
            {
                Console.WriteLine("Existing ID");
                newId = Helpers.EditInt("Input id (" + p.Id + "): ", "Invalid input", "");
            }
            p.Id = newId == 0 ? p.Id : newId;

            decimal newVolume = Helpers.EditDecimal("Volume: ", "invalid input");
            p.Volume = newVolume == 0 ? p.Volume : newVolume;

            int newTime = Helpers.EditInt("Print time: ", "invalid input", "");
            p.PrintTime = newTime == 0? p.PrintTime : newTime;

            int partIndex = p.Part.Id - 1;
            if (Helpers.InputBool("Do you wish to change the part for this print? \"Yes\" or any other input for no: "))
            {
                p.Part = ChangePart(partIndex);
            }

            int materialIndex = p.Material.Id - 1;
            if (Helpers.InputBool("Do you wish to change the material for this print? \"Yes\" or any other input for no: "))
            {
                p.Material = ChangeMaterial(materialIndex);
            }

            int printerIndex = p.Printer.Id - 1;
            if (Helpers.InputBool("Do you wish to change the printer for this print? \"Yes\" or any other input for no: "))
            {
                p.Printer = ChangePrinter(printerIndex);
            }
        }

        private Printer ChangePrinter(int printerIndex)
        {
            Menu.PrinterController.ShowPrinters();
            int index = Helpers.NumberRange("Select printer: ", "invalid input", 1, Menu.PrinterController.Printers.Count(), "");
            return index == 0 ? Menu.PrinterController.Printers[printerIndex] : Menu.PrinterController.Printers[index - 1];
        }

        private Material ChangeMaterial(int materialIndex)
        {
            Menu.MaterialController.ShowMaterials();
            int index = Helpers.NumberRange("Select material: ", "invalid input", 1, Menu.MaterialController.Materials.Count(), "");
            return index == 0 ? Menu.MaterialController.Materials[materialIndex] : Menu.MaterialController.Materials[index - 1];
        }

        private Part ChangePart(int partIndex)
        {
            Menu.PartController.ShowParts();
            int index = Helpers.NumberRange("Select part: ", "invalid input", 1, Menu.PartController.Parts.Count(), "");
            return index == 0 ? Menu.PartController.Parts[partIndex] : Menu.PartController.Parts[index - 1];
        }

        private void CreateNewPrintJob()
        {
            var p = new PrintJob();

            int Id = Helpers.InputInt("Enter id: ", "Must be positive integer");
            while (printJobs.Exists(p => p.Id == Id))
            {
                Console.WriteLine("Existing id!");
                Id = Helpers.InputInt("Enter id: ", "Must be positive integer");
            }
            p.Id = Id;

            p.Volume = Helpers.InputDecimal("Volume: ", "invalid input");
            p.PrintTime = Helpers.InputInt("Print time: ", "invalid input");
            p.Part = SetPart();
            p.Material = SetMaterial();
            p.Printer = SetPrinter();
            printJobs.Add(p);
        }

        private Part SetPart()
        {
            Menu.PartController.ShowParts();
            int index = Helpers.NumberRange("Select part: ", "Invalid input", 1, Menu.PartController.Parts.Count());
            return Menu.PartController.Parts[index-1];
        }

        private Printer SetPrinter()
        {
            Menu.PrinterController.ShowPrinters();
            int index = Helpers.NumberRange("Select printers: ", "Invalid input", 1, Menu.PrinterController.Printers.Count());
            return Menu.PrinterController.Printers[index-1];
        }

        private Material SetMaterial()
        {
            Menu.MaterialController.ShowMaterials();
            int index = Helpers.NumberRange("Select material: ", "Invalid input", 1, Menu.MaterialController.Materials.Count());
            return Menu.MaterialController.Materials[index-1];
        }

        public void ShowPrintJobs()
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
