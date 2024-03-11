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
        public PrintJobController PrintJobController { get; }

        public Menu() 
        {
            Helpers.Dev = true;
            ProjectController = new ProjectController();
            PartController = new PartController(this);
            PrintFilesController = new PrintFilesController(this);
            PrinterController = new PrinterController(this);
            MaterialController = new MaterialController();
            PrintJobController = new PrintJobController(this);
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
            Console.WriteLine("\t7. List all items");
            Console.WriteLine("\t8. STATISTICS");
            Console.WriteLine("\t9. EXIT");

            switch(Helpers.NumberRange("Select menu item: ", "Selection must be 1 - 9 ", 1, 9))
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
                    PrintJobController.ShowMenu();
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
                    Console.Clear();
                    ProjectController.ShowProjects();
                    PartController.ShowParts();
                    PrintFilesController.ShowFiles();
                    PrintJobController.ShowPrintJobs();
                    PrinterController.ShowPrinters();
                    MaterialController.ShowMaterials();
                    Console.ReadKey();
                    ShowMenu();
                    break;
                case 8:
                    ShowStats();
                    Console.Clear();
                    ShowMenu();
                    break;
                case 9:
                    Console.WriteLine("end");
                    break;
            }
        }

        private void ShowStats()
        {
            Console.Clear();
            Console.WriteLine("\r\n  ____  _        _   _     _   _          \r\n / _" +
                "__|| |_ __ _| |_(_)___| |_(_) ___ ___ \r\n \\___ \\| __/ _` | __| / _" +
                "_| __| |/ __/ __|\r\n  ___) | || (_| | |_| \\__ \\ |_| | (__\\__ \\\r\n |_" +
                "___/ \\__\\__,_|\\__|_|___/\\__|_|\\___|___/\r\n                       " +
                "                   \r\n");
            Console.WriteLine();
            TotalParts();
            TotalPartsInProjects();
            AveragePartPerProject();
            Dates();
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");            
            Console.ReadKey();
        }

        private void Dates()
        {
            var p = ProjectController.Projects;

            Project earliestProject = p.OrderBy(pr => pr.CreationDate).First();
            DateTime earliestDate = (DateTime)earliestProject.CreationDate;
            string nameOfProject = earliestProject.ProjectName;

            Project latestProject = p.OrderBy(pr => pr.CreationDate).Last();
            DateTime latestDate = (DateTime)latestProject.CreationDate;
            string nameOfLatestProject = latestProject.ProjectName;

            TimeSpan difference = latestDate - earliestDate;

            Console.WriteLine($"\tEarliest project: {earliestDate} ({nameOfProject})");
            Console.WriteLine($"\tLatest project: {latestDate} ({nameOfLatestProject})");
            Console.WriteLine($"\tDifference between earliest and latest project: {difference.TotalDays:0.##} days");
        }

        private void AveragePartPerProject()
        {
            Console.Write("\tAverage number of parts in a project: ");
            var project = ProjectController.Projects;
            int count = 0;
            foreach (var pr in project)
            {
                if (pr.PartsInProject == null || pr.PartsInProject.Count() == 0)
                {
                    count += 0;
                }
                else
                {
                    count += pr.PartsInProject.Count();
                }
            }
            Console.WriteLine("{0:0.##}", (double)count / project.Count());
        }

        private void TotalParts()
        {            
            Console.WriteLine("\tTotal parts: " + PartController.Parts.Count());
        }

        private void TotalPartsInProjects()
        {
            Console.Write("\tTotal parts assigned to a project: ");
            int total = 0;
            ProjectController.Projects.ForEach(project => total += (project.PartsInProject == null ? 0 : project.PartsInProject.Count()));
            Console.WriteLine(total);
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
