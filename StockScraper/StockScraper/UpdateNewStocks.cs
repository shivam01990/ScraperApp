using BLL;
using DLL;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScraper
{
    public class UpdateNewStocks
    {
        public static int StartUpdate(string Ticker,ws_JobRuns objjobrun, ws_JobScheduler objJobScheduler)
        {
            ws_Stocks obj = new ws_Stocks();
               
            int stock_id = 0;
            try
            {
                objjobrun.web_calls_total = objjobrun.web_calls_total + 1;
                HtmlWeb web = new HtmlWeb();
                string finvizUrl = Helper.finvizUrl(Ticker);
                HtmlDocument doc = web.Load(finvizUrl);
                objjobrun.web_calls_total = objjobrun.web_calls_success + 1;               
                var tdrows1 = doc.DocumentNode.SelectNodes("//table[@class='fullview-title']//tr//td");
                string Exchange_abbr = "";
                if (tdrows1 != null)
                {
                    if (tdrows1.Count == 3)
                    {
                        string row1 = tdrows1[0].InnerText;
                        try
                        {
                            Exchange_abbr = Helper.ExtractFromString(row1, "[", "]")[0];

                        }
                        catch { }

                    }
                }

                if (Exchange_abbr.ToUpper() == "NYSE" || Exchange_abbr.ToUpper() == "AMEX" || Exchange_abbr.ToUpper() == "NASDAQ")
                {
                    obj.Exchange_Abbr = Exchange_abbr.ToUpper();


                    obj.Ticker = Ticker;
                    HtmlWeb marketweb = new HtmlWeb();
                    HtmlDocument marketdoc = marketweb.Load("http://markets.ft.com/research/Markets/Tearsheets/Summary?s=" + obj.Ticker);
                    //Helper.AddtoLogFile("fetching data from http://markets.ft.com/research/Markets/Tearsheets/Summary?s=:" + obj.Ticker);
                    try
                    {
                        if (string.IsNullOrWhiteSpace(obj.Exchange))
                        {
                            string exchanging = marketdoc.DocumentNode.SelectNodes("//div[@class='freestyle']//ul[@class='wsodModuleContent']//li")[0].InnerText;
                            exchanging = exchanging.ToLower().Contains("exchange:") ? exchanging.Replace("Exchange:", "") : "";
                            obj.Exchange = exchanging;
                            //Helper.AddtoLogFile("Exchange:" + obj.Exchange);
                        }
                    }
                    catch { }

                    try
                    {
                        if (string.IsNullOrWhiteSpace(obj.Sector))
                        {
                            string sector = marketdoc.DocumentNode.SelectNodes("//div[@class='freestyle']//ul[@class='wsodModuleContent']//li")[1].InnerText;
                            sector = sector.ToLower().Contains("sector:") ? sector.Replace("Sector:", "") : "";
                            obj.Sector = sector;
                            //Helper.AddtoLogFile("Sector:" + obj.Sector);
                        }
                    }
                    catch { }

                    try
                    {
                        if (string.IsNullOrWhiteSpace(obj.Industry))
                        {
                            string industry = marketdoc.DocumentNode.SelectNodes("//div[@class='freestyle']//ul[@class='wsodModuleContent']//li")[2].InnerText;
                            industry = industry.ToLower().Contains("industry:") ? industry.Replace("Industry:", "") : "";
                            obj.Industry = industry;
                            // Helper.AddtoLogFile("Industry:" + obj.Industry);
                        }
                    }
                    catch
                    {

                    }

                    try
                    {
                        string company_name = marketdoc.DocumentNode.SelectNodes("//div[@class='freestyle']//span[@class='formatIssueName']")[0].InnerText;

                        obj.Company_Name = company_name;
                        //Helper.AddtoLogFile("Format_Issue_Symbol:" + obj.Format_Issue_Symbol);
                    }
                    catch
                    {

                    }

                    try
                    {
                        string Format_Issue_Symbol = marketdoc.DocumentNode.SelectNodes("//div[@class='freestyle']//span[@class='formatIssueSymbol']")[0].InnerText;

                        obj.Format_Issue_Symbol = Format_Issue_Symbol;
                        //Helper.AddtoLogFile("Format_Issue_Symbol:" + obj.Format_Issue_Symbol);
                    }
                    catch
                    {

                    }

                    //Helper.AddtoLogFile("http://www.reuters.com/finance/stocks/analyst?symbol=" + obj.Ticker);
                    HtmlDocument reutersdoc = marketweb.Load("http://www.reuters.com/finance/stocks/analyst?symbol=" + obj.Ticker);
                    try
                    {
                        string title = reutersdoc.DocumentNode.SelectNodes("//div[@id='sectionTitle']")[0].InnerText;
                        title = title.Substring(title.LastIndexOf('('));
                        title = title.Substring(title.LastIndexOf('.')).Replace("\t", "").Replace("\n", "").Replace("&nbsp", "").Replace("&nbsp;", "").Trim('.').Trim(')');
                        obj.Exchange_Letter = title;
                        //Helper.AddtoLogFile("Exchange_Letter:" + obj.Exchange_Letter);
                    }
                    catch { }
                    try
                    {
                        obj.CreatedOn = DateTime.Now;
                        obj.StatusState_Id = 1;
                        obj.Company_Name = obj.Company_Name ?? "";
                        stock_id = ws_StocksServices.Instance.SaveStock(obj);
                    }
                    catch (Exception ex)
                    {
                        //Helper.AddtoLogFile("Error:" + ex.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("Ticker:" + Ticker + " is not belongs to  nyse, amex, or nasdaq");
                }
            }
            catch (Exception ex)
            {
                objjobrun.web_calls_failures = objjobrun.web_calls_failures + 1;
                //Helper.AddtoLogFile("Error:" + ex.ToString());
            }
            return stock_id;
        }
    }
}
