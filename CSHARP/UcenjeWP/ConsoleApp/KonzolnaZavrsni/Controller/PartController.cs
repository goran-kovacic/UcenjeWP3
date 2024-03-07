using ConsoleApp.KonzolnaZavrsni.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.KonzolnaZavrsni.Controller
{
    internal class PartController
    {
        public List<Part> Parts { get;}
        private Menu Menu;

        public PartController(Menu Menu) : this()
        {
            this.Menu = Menu;
            if (Helpers.Dev)
            {
                TestData();
            }
        }
        public PartController()
        {
            Parts = new List<Part>();
        }
        internal void ShowMenu()
        {
            Console.WriteLine("\r\n  ____            _         __  __           " +
                "       \r\n |  _ \\ __ _ _ __| |_ ___  |  \\/  | ___ _ __  _   " +
                "_ \r\n | |_) / _` | '__| __/ __| | |\\/| |/ _ \\ '_ \\| | | |\r\n | " +
                " __/ (_| | |  | |_\\__ \\ | |  | |  __/ | | | |_| |\r\n |_|   \\__,_|_" +
                "|   \\__|___/ |_|  |_|\\___|_| |_|\\__,_|\r\n                        " +
                "                            \r\n");
            Console.WriteLine("\t1. Show existing parts");
            Console.WriteLine("\t2. Create new part");
            Console.WriteLine("\t3. Edit existing part");
            Console.WriteLine("\t4. Delete part");
            //Console.WriteLine("\t5. STATISTIKA");
            Console.WriteLine("\t5. Return to Main Menu");

            switch (Helpers.NumberRange("Select menu item: ", "Selection must be 1 - 5", 1, 5))
            {
                case 1:
                    Console.Clear();
                    ShowParts();
                    ShowMenu();
                    break;
                case 2:
                    CreateNewPart();
                    Menu.UpdateProjectsTestData();
                    Console.Clear();                    
                    ShowMenu();
                    break;
                case 3:
                    EditPart();
                    Menu.UpdateProjectsTestData();
                    Console.Clear();                    
                    ShowMenu();
                    break;
                case 4:
                    DeletePart();
                    Menu.UpdateProjectsTestData();
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
            ShowParts();
            int index = Helpers.NumberRange("Select part: ", "invalidinput", 1, Parts.Count()) - 1;
            Parts.RemoveAt(index);
        }

        private void EditPart()
        {
            ShowParts();
            int index = Helpers.NumberRange("Select part: ", "invalidinput", 1, Parts.Count()) -1;
            var p = Parts[index];

            int newId = Helpers.EditInt("Input part id (" + p.Id + "): ", "Invalid input", "");
            while(Parts.Exists(part => part.Id == newId && part != p))
            {
                Console.WriteLine("Existing ID");
                newId = Helpers.EditInt("Input part id (" + p.Id + "): ", "Invalid input", "");
            }
            p.Id = newId == 0 ? p.Id : newId;

            string newName = Helpers.EditString("Enter part name (" + p.PartName + "): ", "invalid input");
            p.PartName = newName =="" ? p.PartName : newName;

            if (p.Project != null)
            {
                int projectIndex = p.Project.Id;
                p.Project = ChangeProject(projectIndex);
            }
            if (Helpers.InputBool("Do you wish to assign this part to a project? \"Yes\" or any other input for no: "))
            {
                p.Project = SetProject();
            }
            
        }

        private Project ChangeProject(int projectIndex)
        {
            Menu.ProjectController.ShowProjects();
            int index = Helpers.NumberRange("Select project: ", "invalid input", 1, Menu.ProjectController.Projects.Count(), "") -1;
            if(index == 0)
            {
                return Menu.ProjectController.Projects[projectIndex];
            }
            return Menu.ProjectController.Projects[index];
        }

        private void CreateNewPart()
        {
            var p = new Part();

            int Id = Helpers.InputInt("Enter id: ", "Must be positive integer");
            while(Parts.Exists(p => p.Id == Id))
            {
                Console.WriteLine("Existing id!");
                Id = Helpers.InputInt("Enter id: ", "Must be positive integer");
            }
            p.PartName = Helpers.InputString("Project name: ", "Invalid input");
            p.Project = SetProject();
            Parts.Add(p);
        }

        private Project SetProject()
        {
            Menu.ProjectController.ShowProjects();
            int index = Helpers.NumberRange("Select project: ", "Invalid input", 1, Menu.ProjectController.Projects.Count()) - 1;
            return Menu.ProjectController.Projects[index];
        }

        private void ShowParts()
        {
            Console.WriteLine("------------------");
            Console.WriteLine("------ Parts -----");
            Console.WriteLine("------------------");
            int counter = 1;
            Parts.ForEach(pr => Console.WriteLine("{0}. {1}", counter++, pr));
            Console.WriteLine("------------------");
        }

        private void TestData()
        {
            Parts.Add(new Part()
            {
                Id = 1,
                PartName = "TestPart1",
                Project = Menu.ProjectController.Projects[0]
            });
            Parts.Add(new Part()
            {
                Id = 2,
                PartName = "TestPart2",
                //Project = Menu.ProjectController.Projects[0]
            });
        }

        
    }
}
