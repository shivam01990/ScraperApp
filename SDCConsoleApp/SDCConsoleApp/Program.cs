using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Helper.AddtoLogFile("=============Import Start " + DateTime.Now + "============");
            Helper.AddtoLogFile("==================WikipediaImport Started=============");
            WikipediaImport.StartImport();
            Helper.AddtoLogFile("==================WikipediaImport End=============");
            Helper.AddtoLogFile("==================EoddataImport Started=============");           
            EoddataImport.StartImport();
            Helper.AddtoLogFile("==================EoddataImport End=============");           
            Helper.AddtoLogFile("=============Import End " + DateTime.Now + "============");
        }
    }
}
