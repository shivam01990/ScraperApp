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
            Helper.AddtoLogFile("=============Import End " + DateTime.Now + "============");
        }
    }
}
