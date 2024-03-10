using ConsoleApp.KonzolnaZavrsni.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.KonzolnaZavrsni.Controller
{
    internal class PrintFilesController
    {
        public List<PrintFile> Files { get; }
        private Menu Menu;

        public PrintFilesController(Menu Menu):this()
        {
            this.Menu = Menu;
            if (Helpers.Dev)
            {
                TestData();
            }
        }
        public PrintFilesController()
        {
            Files = new List<PrintFile>();
        }

        internal void ShowMenu()
        {
            Console.WriteLine("\r\n  ____       _       _     _____ _ _            " +
                " __  __                  \r\n |  _ \\ _ __(_)_ __ | |_  |  ___(_) " +
                "| ___  ___  |  \\/  | ___ _ __  _   _ \r\n | |_) | '__| | '_ \\| __" +
                "| | |_  | | |/ _ \\/ __| | |\\/| |/ _ \\ '_ \\| | | |\r\n |  __/| | " +
                " | | | | | |_  |  _| | | |  __/\\__ \\ | |  | |  __/ | | | |_| |\r\n |" +
                "_|   |_|  |_|_| |_|\\__| |_|   |_|_|\\___||___/ |_|  |_|\\___|_" +
                "| |_|\\__,_|\r\n                                                                         \r\n");
            Console.WriteLine("\t1. Show existing files");
            Console.WriteLine("\t2. Create new file");
            Console.WriteLine("\t3. Edit existing file");
            Console.WriteLine("\t4. Delete file");
            Console.WriteLine("\t5. Return to Main Menu");

            switch (Helpers.NumberRange("Select menu item: ", "Selection must be 1 - 5", 1, 5))
            {
                case 1:
                    Console.Clear();
                    ShowFiles();
                    ShowMenu();
                    break;
                case 2:
                    CreateNewFile();
                    Menu.UpdatePartsTestData();
                    Console.Clear();
                    ShowMenu();
                    break;
                case 3:
                    EditFile();
                    Menu.UpdatePartsTestData();
                    ShowMenu();
                    break;
                case 4:
                    DeleteFile();
                    Menu.UpdatePartsTestData();
                    Console.Clear();
                    ShowMenu();
                    break;
                case 5:
                    Console.WriteLine("end");
                    break;

            }
        }

        private void DeleteFile()
        {
            ShowFiles();
            int index = Helpers.NumberRange("Select file: ", "invalid input", 1, Files.Count()) - 1;
            Files.RemoveAt(index);
        }

        private void EditFile()
        {
            ShowFiles();
            int index = Helpers.NumberRange("Select file: ", "invalidinput", 1, Files.Count()) - 1;
            var f = Files[index];

            int newId = Helpers.EditInt("Input file id (" + f.Id + "): ", "Invalid input", "");
            while(Files.Exists(file => file.Id == newId && file != f))
            {
                Console.WriteLine("Existing ID");
                newId = Helpers.EditInt("Input file id (" + f.Id + "): ", "Invalid input", "");
            }
            f.Id = newId == 0 ? f.Id : newId;

            string newFilePath = Helpers.EditString("Enter file path (" + f.FilePath + "): ", "invalid input");
            f.FilePath = newFilePath == "" ? f.FilePath : newFilePath;

            string newFileType = Helpers.EditString("Enter file path (" + f.FileType + "): ", "invalid input");
            f.FileType = newFileType == "" ? f.FileType : newFileType;

            int newVersion = Helpers.EditInt("Enter file version (" + f.FileVersion + "): ", "invalid input", "");
            f.FileVersion = newVersion == 0 ? f.FileVersion : newVersion;

            int partIndex = f.Part.Id - 1;
            if (Helpers.InputBool("Do you wish to change the part for this file? \"Yes\" or any other input for no: "))
            {
                f.Part = ChangePart(partIndex);
            }
        }

        private Part ChangePart(int partIndex)
        {
            Menu.PartController.ShowParts();
            int index = Helpers.NumberRange("Select part: ", "invalid input", 1, Menu.PartController.Parts.Count(), "");
            return index == 0 ? Menu.PartController.Parts[partIndex] : Menu.PartController.Parts[index - 1];
        }

        private void CreateNewFile()
        {
            var f = new PrintFile();

            int Id = Helpers.InputInt("Enter id: ", "Must be positive integer");
            while(Files.Exists(f => f.Id == Id))
            {
                Console.WriteLine("Existing id!");
                Id = Helpers.InputInt("Enter id: ", "Must be positive integer");
            }
            f.Id = Id;
            f.FilePath = Helpers.InputString("File path: ", "Invalid input");
            f.FileType = Helpers.InputString("File name: ", "Invalid input");
            f.FileVersion = Helpers.InputInt("File version: ", "Invalid input");
            f.Part = SetPart();
            Files.Add(f);
        }

        private Part SetPart()
        {
            Menu.PartController.ShowParts();
            int index = Helpers.NumberRange("Select part: ", "Invalid input", 1, Menu.PartController.Parts.Count());            
            return Menu.PartController.Parts[index - 1];
        }

        private void ShowFiles()
        {
            Console.WriteLine("------------------");
            Console.WriteLine("------ Files -----");
            Console.WriteLine("------------------");
            int counter = 1;
            Files.ForEach(pf => Console.WriteLine("{0}. {1}", counter++, pf));
            Console.WriteLine("------------------");
        }

        private void TestData()
        {
            Files.Add(new PrintFile()
            {
                Id = 1,
                FilePath = "\\test_1",
                FileType = "STL",
                FileVersion = 1,
                Part = Menu.PartController.Parts[0]                
            });
            Files.Add(new PrintFile()
            {
                Id = 2,
                FilePath = "\\test_2",
                FileType = "STL",
                FileVersion = 1,
                Part = Menu.PartController.Parts[1]
            });
            Files.Add(new PrintFile()
            {
                Id = 3,
                FilePath = "\\test_3",
                FileType = "STL",
                FileVersion = 1,
                Part = Menu.PartController.Parts[1]
            });
        }

        
    }
}
