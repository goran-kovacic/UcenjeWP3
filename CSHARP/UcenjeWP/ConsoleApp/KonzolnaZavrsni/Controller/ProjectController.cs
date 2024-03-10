using ConsoleApp.KonzolnaZavrsni.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.KonzolnaZavrsni.Controller
{
    internal class ProjectController
    {
        public List<Project> Projects { get; }
        private Menu Menu;
        public ProjectController()
        {
            Projects = new List<Project>();
            if (Helpers.Dev)
            {
                TestData();
            }
        }
        public void ShowMenu()
        {
            Console.WriteLine("\r\n  ____            _           _         __  __                 " +
                " \r\n |  _ \\ _ __ ___ (_) ___  ___| |_ ___  |  \\/  | ___ _ __  _   _ \r\n | |_) " +
                "| '__/ _ \\| |/ _ \\/ __| __/ __| | |\\/| |/ _ \\ '_ \\| | | |\r\n |  __/| | | (_) " +
                "| |  __/ (__| |_\\__ \\ | |  | |  __/ | | | |_| |\r\n |_|   |_|  \\___// |\\___|\\___" +
                "|\\__|___/ |_|  |_|\\___|_| |_|\\__,_|\r\n               |__/                        " +
                "                     \r\n");
            Console.WriteLine("\t1. Show existing projects");
            Console.WriteLine("\t2. Create new project");
            Console.WriteLine("\t3. Edit existing project");
            Console.WriteLine("\t4. Delete project");
            Console.WriteLine("\t5. Return to Main Menu");

            switch (Helpers.NumberRange("Select menu item: ", "Selection must be 1 - 5", 1, 5))
            {
                case 1:
                    Console.Clear();
                    ShowProjects();
                    ShowMenu();
                    break;
                case 2:
                    CreateNewProject();
                    Console.Clear();
                    ShowProjects();
                    ShowMenu(); 
                    break;
                case 3:
                    EditProject();
                    Console.Clear();
                    ShowProjects();
                    ShowMenu();
                    break;
                case 4:
                    DeleteProject();
                    Console.Clear();
                    ShowProjects();
                    ShowMenu();
                    break;
                case 5:
                    Console.WriteLine("end");
                    break;
            }
        }

        private void DeleteProject()
        {
            ShowProjects();
            int index = Helpers.NumberRange("Select project (Enter to cancel): ", "invalid input", 1, Projects.Count(), "");
            if (index == 0)
            {
                return;
            }
            if (Helpers.InputBool("Are you sure you want to delete? ('Yes' to delete, any other input to continue): "))
            {
                Projects.RemoveAt(index - 1);
            }
        }

        private void EditProject()
        {
            ShowProjects();
            int index = Helpers.NumberRange("Select project: ", "Invalid input", 1, Projects.Count());
            var p = Projects[index-1];

            int newId = Helpers.EditInt("Input project id (" + p.Id + ") (Enter to skip): ", "Invalid input", "");
            while (Projects.Exists(pr => pr.Id == newId && pr != p))
            {
                Console.WriteLine("Existing ID!");
                newId = Helpers.EditInt("Input project id (" + p.Id + ") (Enter to skip): ", "Invalid input", "");
            }
            p.Id = newId == 0 ? p.Id : newId;
            Console.WriteLine();

            string newName = Helpers.EditString("Project name(" + p.ProjectName + "): ", "Invalid input");
            p.ProjectName = newName == "" ? p.ProjectName : newName;

            DateTime? newCrDate = Helpers.InputDate("Enter creation date: ", "Invalid input!");
            p.CreationDate = newCrDate == null ? p.CreationDate : newCrDate;

            DateTime? newCoDate = Helpers.InputDate("Enter completion date: ", "Invalid input!");
            p.CompletionDate = newCoDate == null ? p.CompletionDate : newCoDate;

            //string completed = Helpers.InputBoolAsString("Completed? Yes or any other input to continue (" +
            //    (p.Completed ? "Yes" : "No") + "): ","Invalid input", "");

            string desc = Helpers.EditString("Edit description: ", "");

        }

        private void CreateNewProject()
        {
            var p = new Project();

            int id = Helpers.InputInt("Enter id: ", "Must be positive integer");
            while(Projects.Exists(pr => pr.Id == id)) 
            {
                Console.WriteLine("Existing id!");
                id = Helpers.InputInt("Enter id: ", "Must be positive integer");
            }
            p.Id = id;
            p.ProjectName = Helpers.InputString("Project name: ", "Invalid input");
            p.CreationDate = Helpers.InputDate("Enter creation date: ", "Invalid input!");
            p.CompletionDate = Helpers.InputDate("Enter completion date: ", "Invalid input!");
            //p.Completed = Helpers.InputBool("Project completed yes/no: ");
            p.ProjectDescription = Helpers.InputString("Project description: ", "Invalid input");            
            Projects.Add(p);
        }

        public void ShowProjects()
        {
            Console.WriteLine("------------------");
            Console.WriteLine("---- Projects ----");
            Console.WriteLine("------------------");
            int counter = 1;
            Projects.ForEach(pr =>  Console.WriteLine("{0}. {1}", counter++, pr));
            Console.WriteLine("------------------");
        }

        private void TestData()
        {
            Projects.Add(new Project
            {
                ProjectName = "Test",
                CreationDate = DateTime.Now,
                Id = 1,                
            });
            Projects.Add(new Project
            {
                ProjectName = "Test2",
                CreationDate = DateTime.Parse("2023-11-20 12:30:45"),
                CompletionDate = DateTime.Now,
                Id = 2,
            });
            Projects.Add(new Project
            {
                ProjectName = "Test3",                
                CreationDate = DateTime.Parse("2023-11-20 12:30:45"),
                CompletionDate = null,
                Id = 3,
            });
        }
    }
}
