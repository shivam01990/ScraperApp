using DLL;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScraper
{
    public class finviz_CalendarProvider
    {
        #region--Get finviz_calendar--
        public static List<finviz_Calendar> GetData(int job_id, ws_JobRuns jobRun)
        {
            List<finviz_Calendar> rType = new List<finviz_Calendar>();
            HtmlWeb web = new HtmlWeb();
            string finvizUrl = Helper.finvizCalendarURL();
            Console.WriteLine("Loading URL: " + finvizUrl);
            jobRun.web_calls_total += 1;          
            HtmlDocument doc = web.Load(finvizUrl);
            jobRun.web_calls_success += 1;          
            Console.WriteLine("Document Loaded: " + finvizUrl);
            string banner_date = "";
            try
            {
                var timeUtc = DateTime.UtcNow;
                TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                DateTime easternTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, easternZone);
                banner_date = easternTime.ToString("ddd MMM dd yyyy hh:mm tt");
               
            }
            catch { }
            var tblrows = doc.DocumentNode.SelectNodes("//table[@class='calendar']//tr[@class='calendar-header']");
            if (tblrows != null)
            {

                for (int k = 1; k < tblrows.Count; k++)
                {
                    HtmlNode tr = tblrows[k];
                    if (tr.ChildNodes.Count() == 19)
                    {
                        try
                        {
                            finviz_Calendar temp = new finviz_Calendar();
                            temp.calendar_date_text = tr.ChildNodes[1].InnerText.Replace("&nbsp;", " ").Trim();
                            temp.job_run_id = job_id;
                            temp.calendar_yyyy = DateTime.Now.Year.ToString();
                            temp.calendar_day = temp.calendar_date_text.Length >= 3 ? temp.calendar_date_text.Substring(0, 3).Trim() : "";
                            temp.calendar_mm = temp.calendar_date_text.Length >= 3 ? temp.calendar_date_text.Substring(4, 3).Trim() : "";
                            temp.calendar_dd = temp.calendar_date_text.Length >= 3 ? temp.calendar_date_text.Substring(7).Trim() : "";
                            temp.banner_date = banner_date;
                            temp.time_zone = "EST";
                            DateTime tempdate = new DateTime(DateTime.Now.Year, DateTime.ParseExact(temp.calendar_mm, "MMM", CultureInfo.CurrentCulture).Month, int.Parse(temp.calendar_dd));
                            temp.calendar_date = tempdate.ToString("yyyy.MM.dd-hh:mm");
                            if (tempdate.ToString("ddd").ToUpper() == "SAT" || tempdate.ToString("ddd").ToUpper() == "SUN")
                            {
                                temp.market_closed = true;
                                temp.official_market_closure = true;
                            }
                            else
                            {
                                temp.market_closed = false;
                                temp.official_market_closure = false;
                            }
                            rType.Add(temp);
                        }
                        catch { }
                    }
                }
            }
            return rType;
        }
        #endregion
    }
}