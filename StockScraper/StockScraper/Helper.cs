using HtmlAgilityPack;
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

        #region--Get Reuters Urls--
        public static string GetReutersAnalyticsUrls(string Ticket)
        {
            string rType = @"http://www.reuters.com/finance/stocks/analyst?symbol=" + Ticket;
            return rType;
        }

        public static string GetReutersfinancialHighlightsUrls(string Ticket)
        {
            string rType = @"http://www.reuters.com/finance/stocks/financialHighlights?symbol=" + Ticket;
            return rType;
        }
        #endregion

        #region--Market Provider--
        public static string GetMarketsUrls(string Ticker)
        {
            string rType = @"http://markets.ft.com/research/Markets/Tearsheets/Forecasts?s=" + Ticker + ":NYQ";
            return rType;
        }
        public static string GetMarketsFinancialUrls(string Ticker)
        {
            string rType = @"http://markets.ft.com/research//Markets/Tearsheets/Financials?s=" + Ticker + ":NYQ&subview=IncomeStatement&period=a";
            return rType;
        }
        #endregion

        #region--finviz Url--
        public static string finvizUrl(string Ticker)
        {
            string rType = @"http://finviz.com/quote.ashx?t=" + Ticker + "&ty=c&p=d&b=1";
            return rType;
        }
        #endregion

        public static string GetEffetiveTime(HtmlDocument doc)
        {

            string EffectiveTime = "";
            try
            {
                EffectiveTime = doc.DocumentNode.SelectSingleNode("//span[@class='nasdaqChangeTime']").InnerText;
            }
            catch
            { }

            if (!(EffectiveTime.ToLower().Contains("am") || EffectiveTime.Contains("pm")))
            {
                try
                {
                    DateTime _effectivetime = DateTime.Parse(EffectiveTime);
                    EffectiveTime = _effectivetime.ToString("yyyyMMdd");
                }
                catch { }
            }
            else
            {
                EffectiveTime = (DateTime.Now.ToString("yyyyMMdd") + " " + EffectiveTime).Trim();
            }
            return EffectiveTime;
        }
    }
}
