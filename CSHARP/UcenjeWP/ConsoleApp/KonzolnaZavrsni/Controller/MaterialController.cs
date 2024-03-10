using ConsoleApp.KonzolnaZavrsni.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.KonzolnaZavrsni.Controller
{
    internal class MaterialController
    {
        public List<Material> Materials { get; }
        
        public MaterialController()
        {
            Materials = new List<Material>();
            if (Helpers.Dev)
            {
                TestData();
            }
        }

        internal void ShowMenu()
        {
            Console.WriteLine("\r\n  __  __       _            _       _       __  __   " +
                "               \r\n |  \\/  | __ _| |_ ___ _ __(_) __ _| |___  |  \\/  " +
                "| ___ _ __  _   _ \r\n | |\\/| |/ _` | __/ _ \\ '__| |/ _` | / __| |" +
                " |\\/| |/ _ \\ '_ \\| | | |\r\n | |  | | (_| | ||  __/ |  | | (_| | \\__ \\ | " +
                "|  | |  __/ | | | |_| |\r\n |_|  |_|\\__,_|\\__\\___|_|  |_|\\__,_|_|___/" +
                " |_|  |_|\\___|_| |_|\\__,_|\r\n                                       " +
                "                             \r\n");
            Console.WriteLine("\t1. Show existing materials");
            Console.WriteLine("\t2. Create new material");
            Console.WriteLine("\t3. Edit existing material");
            Console.WriteLine("\t4. Delete material");
            Console.WriteLine("\t5. Return to Main Menu");
            switch (Helpers.NumberRange("Select menu item: ", "Selection must be 1 - 5", 1, 5))
            {
                case 1:
                    Console.Clear();
                    ShowMaterials();
                    ShowMenu();
                    break;
                case 2:
                    CreateNewMaterial();
                    Console.Clear();
                    ShowMaterials();
                    ShowMenu();
                    break;
                case 3:
                    EditMaterial();
                    Console.Clear();
                    ShowMaterials();
                    ShowMenu();
                    break;
                case 4:
                    DeletePrinter();
                    Console.Clear();
                    ShowMaterials();
                    ShowMenu();
                    break;
                case 5:
                    Console.WriteLine("end");
                    break;
            }

        }

        private void DeletePrinter()
        {
            ShowMaterials();
            int index = Helpers.NumberRange("Select material (Enter to cancel): ", "invalid input", 1, Materials.Count(), "");
            if (index == 0)
            {
                return;
            }
            if (Helpers.InputBool("Are you sure you want to delete? ('Yes' to delete, any other input to continue): "))
            {
                Materials.RemoveAt(index - 1);
            }
        }

        private void EditMaterial()
        {
            ShowMaterials();
            int index = Helpers.NumberRange("Select material: ", "Invalid input", 1, Materials.Count());
            var p = Materials[index - 1];

            int newId = Helpers.EditInt("Input material id (" + p.Id + ") (Enter to skip): ", "Invalid input", "");
            while (Materials.Exists(pr => pr.Id == newId && pr != p))
            {
                Console.WriteLine("Existing ID!");
                newId = Helpers.EditInt("Input project id (" + p.Id + ") (Enter to skip): ", "Invalid input", "");
            }
            p.Id = newId == 0 ? p.Id : newId;
            Console.WriteLine();

            string newName = Helpers.EditString("Name(" + p.MaterialName + "): ", "Invalid input");
            p.MaterialName = newName == "" ? p.MaterialName : newName;

            string newManufacturer = Helpers.EditString("Manufacturer name(" + p.Manufacturer + "): ", "Invalid input");
            p.Manufacturer = newManufacturer == "" ? p.Manufacturer : newManufacturer;

            decimal newExposure = Helpers.EditDecimal("Calibrated exposure (" + p.CalibratedExposure + "): ", "invalid input");
            p.CalibratedExposure = newExposure==0 ? p.CalibratedExposure : newExposure;

            decimal newDelay = Helpers.EditDecimal("Light-off delay (" + p.LightOffDelay + "): ", "invalid input");
            p.LightOffDelay = newDelay == 0 ? p.LightOffDelay : newDelay;

            decimal newCost = Helpers.EditDecimal("Cost per 1kg (" + p.CostPerUnit + "): ", "invalid input");
            p.CostPerUnit = newCost == 0 ? p.CostPerUnit : newCost;

            int newLift = Helpers.EditInt("Lift distance (" + p.LiftDistance + "): ", "invalid input", "");
            p.LiftDistance = newLift == 0 ? p.LiftDistance : newLift;

        }

        private void CreateNewMaterial()
        {
            var m = new Material();

            int id = Helpers.InputInt("Enter id: ", "Must be positive integer");
            while (Materials.Exists(m => m.Id == id))
            {
                Console.WriteLine("Existing id!");
                id = Helpers.InputInt("Enter id: ", "Must be positive integer");
            }
            m.Id = id;

            m.MaterialName = Helpers.InputString("Name: ", "Invalid input");
            m.Manufacturer = Helpers.InputString("Manufacturer name: ", "Invalid input");
            m.CalibratedExposure = Helpers.InputDecimal("Calibrated exposure: ", "invalid input");
            m.LiftDistance = Helpers.InputInt("Lift distance: ", "invalid input");
            m.LightOffDelay = Helpers.InputDecimal("Light-off delay: ", "invalid input");
            m.CostPerUnit = Helpers.InputDecimal("Cost per 1kg: ", "invalid input");
            Materials.Add(m);
        }

        private void ShowMaterials()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("---- Materials ----");
            Console.WriteLine("-------------------");
            int counter = 1;
            Materials.ForEach(pr => Console.WriteLine("{0}. {1}", counter++, pr));
            Console.WriteLine("------------------");
        }
        private void TestData()
        {
            Materials.Add(new Material
            {
                Id = 1,
                CalibratedExposure = 4,
                LiftDistance = 6,
                LightOffDelay = 0.5m,
                MaterialName = "Test",
                Manufacturer = "Elegoo",
                CostPerUnit = 50
            });
        }
    }
}
