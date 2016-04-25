using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL;
using BLL;
namespace StockScraper
{
    public class Helper
    {
        #region--Generate Logs--
        public static void AddtoLog(string Message, int run_job_id, bool SaveToDB, LogStatus status)
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

                if(SaveToDB)
                {
                    string _status = "";
                    if (status == LogStatus.warning)
                    {
                        _status = "Warning";

                    }
                    else
                    {
                        _status = "Fail";
                    }

                    ws_Logs obj = new ws_Logs();
                    obj.log_msg = Message;
                    obj.log_status = _status;
                    obj.job_run_Id = run_job_id;
                    ws_LogsServices.Instance.SaveLogs(obj);
                }
            }
            catch
            { }
        }

        public static void AddtoLog(string Message)
        {
            AddtoLog(Message,0,false,LogStatus.warning);
        }
        #endregion

        public  enum LogStatus
        {
            warning,
            fail
        };

        public static string GetWarningMSG(int stock_id,string table,string url)
        {
            string rType = "No data found for table: " + table + " & Stock ID:" + stock_id+" Please check url:"+url;
            return rType;
        }

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
        public static string GetMarketsUrls(string format_issue_symbol)
        {
            string rType = @"http://markets.ft.com/research/Markets/Tearsheets/Forecasts?s=" + format_issue_symbol;
            return rType;
        }
        public static string GetMarketsFinancialUrls(string format_issue_symbol)
        {
            string rType = @"http://markets.ft.com/research//Markets/Tearsheets/Financials?s=" + format_issue_symbol + "&subview=IncomeStatement&period=a";
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

        #region--finviz Calendar Url--
        public static string finvizCalendarURL()
        {
            return "http://finviz.com/calendar.ashx"; 
        }
        #endregion

        public static List<string> ExtractFromString(
            string text, string startString, string endString)
        {
            List<string> matched = new List<string>();
            int indexStart = 0, indexEnd = 0;
            bool exit = false;
            while (!exit)
            {
                indexStart = text.IndexOf(startString);
                indexEnd = text.IndexOf(endString);
                if (indexStart != -1 && indexEnd != -1)
                {
                    matched.Add(text.Substring(indexStart + startString.Length,
                        indexEnd - indexStart - startString.Length));
                    text = text.Substring(indexEnd + endString.Length);
                }
                else
                    exit = true;
            }
            return matched;
        }



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
