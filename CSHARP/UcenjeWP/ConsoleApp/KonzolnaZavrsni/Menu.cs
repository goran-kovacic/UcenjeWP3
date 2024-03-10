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
        public PartController PartController { get; }
        
        public PrintFilesController PrintFilesController { get; }
        public PrinterController PrinterController { get; }
        public MaterialController MaterialController { get; }

        public Menu() 
        {
            Helpers.Dev = true;
            ProjectController = new ProjectController();
            PartController = new PartController(this);
            PrintFilesController = new PrintFilesController(this);
            PrinterController = new PrinterController(this);
            MaterialController = new MaterialController();
            UpdateProjectsTestData();
            UpdatePartsTestData();
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
            Console.WriteLine("\t5. Printers");
            Console.WriteLine("\t6. Materials");
            Console.WriteLine("\t7. EXIT");

            switch(Helpers.NumberRange("Select menu item: ", "Selection must be 1 - 7", 1, 7))
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
                case 3:
                    Console.Clear();
                    PrintFilesController.ShowMenu();
                    ShowMenu();
                    break;
                case 4:
                    Console.Clear();
                    //PrintJobController.ShowMenu();
                    ShowMenu();
                    break;
                case 5:
                    Console.Clear();
                    PrinterController.ShowMenu();
                    ShowMenu();
                    break;
                case 6:
                    Console.Clear();
                    MaterialController.ShowMenu();
                    ShowMenu();
                    break;
                case 7:
                    Console.WriteLine("end");
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

        internal void UpdatePartsTestData()
        {
            foreach(Part part in PartController.Parts)
            {
                string partName = part.PartName;
                List<PrintFile> printFiles = new List<PrintFile>();
                foreach(PrintFile file in PrintFilesController.Files)
                {
                    if(file.Part.PartName == partName)
                    {
                        printFiles.Add(file);
                    }
                }
                part.FilesInPart = printFiles;
            }
        }
    }
}
