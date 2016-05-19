using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScheduler
{
   public class AppSettings
    {
       public static string EXEPath
       {
           get { return (ConfigurationManager.AppSettings["EXEPath"] != null ? ConfigurationManager.AppSettings["EXEPath"].ToString() : ""); }
       }

    }
}
