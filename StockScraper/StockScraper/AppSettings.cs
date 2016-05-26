using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScraper
{
    public class AppSettings
    {
        public static int finvizjobid
        {
            get { return int.Parse((ConfigurationManager.AppSettings["finvizjobid"] != null ? ConfigurationManager.AppSettings["finvizjobid"].ToString() : "-1")); }
        }
        public static int companystockjobid
        {
            get { return int.Parse((ConfigurationManager.AppSettings["companystockjobid"] != null ? ConfigurationManager.AppSettings["companystockjobid"].ToString() : "-1")); }
        }
        public static int forecastjobid
        {
            get { return int.Parse((ConfigurationManager.AppSettings["forecastjobid"] != null ? ConfigurationManager.AppSettings["forecastjobid"].ToString() : "-1")); }
        }
        public static int financestatementjobid
        {
            get { return int.Parse((ConfigurationManager.AppSettings["financestatementjobid"] != null ? ConfigurationManager.AppSettings["financestatementjobid"].ToString() : "-1")); }
        }
    }
}
