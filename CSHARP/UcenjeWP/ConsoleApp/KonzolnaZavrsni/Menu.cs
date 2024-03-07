using ConsoleApp.KonzolnaZavrsni.Controller;
using ConsoleApp.KonzolnaZavrsni.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.KonzolnaZavrsni
{
    internal class Menu
    {
        public ProjectController ProjectController { get; }
        private PartController PartController;
        public Menu() 
        {
            Helpers.Dev = true;
            ProjectController = new ProjectController();
            PartController = new PartController(this);
            UpdateProjectsTestData();
            ShowMenu();
        }

        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("\r\n███╗   ███╗ █████╗ ██╗███╗   ██╗    ███╗   ███╗███████╗███╗ " +
                "  ██╗██╗   ██╗\r\n████╗ ████║██╔══██╗██║████╗  ██║    ████╗ ████║██╔════╝████╗ " +
                " ██║██║   ██║\r\n██╔████╔██║███████║██║██╔██╗ ██║    ██╔████╔██║█████╗  ██╔██╗ " +
                "██║██║   ██║\r\n██║╚██╔╝██║██╔══██║██║██║╚██╗██║    ██║╚██╔╝██║██╔══╝  ██║╚██╗██║██║ " +
                "  ██║\r\n██║ ╚═╝ ██║██║  ██║██║██║ ╚████║    ██║ ╚═╝ ██║███████╗██║ ╚████║╚██████╔╝\r\n╚═╝" +
                "     ╚═╝╚═╝  ╚═╝╚═╝╚═╝  ╚═══╝    ╚═╝     ╚═╝╚══════╝╚═╝  ╚═══╝ ╚═════╝ \r\n                                                                          \r\n");
            //Console.WriteLine("MAIN MENU");
            Console.WriteLine("\t1. Projects");
            Console.WriteLine("\t2. Parts");
            Console.WriteLine("\t3. Files");
            Console.WriteLine("\t4. Print jobs");
            Console.WriteLine("\t5. Materials");
            Console.WriteLine("\t6. Printers");
            Console.WriteLine("\t7. EXIT");

            switch(Helpers.NumberRange("Select menu item: ", "Selection must be 1 - 8", 1, 8))
            {
                case 1:
                    Console.Clear();
                    ProjectController.ShowMenu();
                    ShowMenu();
                    break;
                case 2:
                    Console.Clear();
                    PartController.ShowMenu();
                    ShowMenu();
                    break;

            }
        }

        public void UpdateProjectsTestData()
        {
            foreach(Project project in ProjectController.Projects)
            {
                string projectName = project.ProjectName;
                List<Part> parts = new List<Part>();
                foreach(Part part in PartController.Parts)
                {
                    if(part.Project==null) continue;
                    if (part.Project.ProjectName == projectName)
                    {
                        parts.Add(part);
                    }
                }
                project.PartsInProject = parts;
            }
        }
    }
}
