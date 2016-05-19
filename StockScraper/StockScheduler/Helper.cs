using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScheduler
{
  public class Helper
   {
      public static string GetExePath()
      {
          string EXEPath = AppDomain.CurrentDomain.BaseDirectory;
          EXEPath += AppSettings.EXEPath;
          return EXEPath;
      }
   }
}
