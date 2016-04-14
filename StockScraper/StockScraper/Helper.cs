using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScraper
{
    public class Helper
    {
        #region--Generate Logs--
        public static void AddtoLog(string Message)
        {
            try
            {
                string LogPath = AppDomain.CurrentDomain.BaseDirectory;
                string filename = "\\Log.txt";
                string filepath = LogPath + filename;
                if (!File.Exists(filepath))
                {
                    StreamWriter writer = File.CreateText(filepath);
                    writer.Close();
                }
                using (StreamWriter writer = new StreamWriter(filepath, true))
                {
                    writer.WriteLine(Message);
                }
            }
            catch
            { }
        }
        #endregion

        #region--Get Eodata Urls--
        public static string GetReutersAnalyticsUrls(string Ticket)                                              
        {
            string rType = @"http://www.reuters.com/finance/stocks/analyst?symbol=" + Ticket;
            return rType;
        }
        #endregion

       
    }
}
