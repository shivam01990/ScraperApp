using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            ReutersProvider.StartImport();
        }
    }
}
