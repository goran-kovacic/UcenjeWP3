using ConsoleApp.KonzolnaZavrsni.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.KonzolnaZavrsni.Controller
{
    internal class PrintFilesController
    {
        public List<PrintFile> PrintFiles { get; }
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
            PrintFiles = new List<PrintFile>();
        }

        private void TestData()
        {
            throw new NotImplementedException();
        }

        
    }
}
