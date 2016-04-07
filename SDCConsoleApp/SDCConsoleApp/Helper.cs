using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCConsoleApp
{
    class Helper
    {
        #region--Generate Logs--      
        public static void AddtoLogFile(string Message)
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

        #region--Get Urls--
        public static List<string> GetUrls()                                               //Return List of Five Master Page URLs
        {
            List<string> lst = new List<string>();
            for (char c = 'A'; c <= 'Z'; c++)
            {
                lst.Add(@"http://eoddata.com/stocklist/NASDAQ/" + c + ".htm");
            }
            return lst;
        }
        #endregion
    }
}
