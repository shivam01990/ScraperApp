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
    class UpdateOldStock
    {
        public static ws_Stocks StartUpdate(ws_Stocks obj)
        {
            int stock_id = 0;
            try
            {
                            
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
                        // Helper.AddtoLogFile("Exchange:" + obj.Exchange);
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
                    if (string.IsNullOrWhiteSpace(obj.Company_Name))
                    {
                        string company_name = marketdoc.DocumentNode.SelectNodes("//div[@class='freestyle']//span[@class='formatIssueName']")[0].InnerText;

                        obj.Company_Name = company_name;
                        //Helper.AddtoLogFile("Format_Issue_Symbol:" + obj.Format_Issue_Symbol);
                    }
                }
                catch
                {

                }

                try
                {
                    if (string.IsNullOrWhiteSpace(obj.Format_Issue_Symbol))
                    {
                        string Format_Issue_Symbol = marketdoc.DocumentNode.SelectNodes("//div[@class='freestyle']//span[@class='formatIssueSymbol']")[0].InnerText;

                        obj.Format_Issue_Symbol = Format_Issue_Symbol;
                        //Helper.AddtoLogFile("Format_Issue_Symbol:" + obj.Format_Issue_Symbol);
                    }
                }
                catch
                {

                }

                //Helper.AddtoLogFile("http://www.reuters.com/finance/stocks/analyst?symbol=" + obj.Ticker);
                HtmlDocument reutersdoc = marketweb.Load("http://www.reuters.com/finance/stocks/analyst?symbol=" + obj.Ticker);
                try
                {
                    if (string.IsNullOrWhiteSpace(obj.Exchange_Letter))
                    {
                        string title = reutersdoc.DocumentNode.SelectNodes("//div[@id='sectionTitle']")[0].InnerText;
                        title = title.Substring(title.LastIndexOf('('));
                        title = title.Substring(title.LastIndexOf('.')).Replace("\t", "").Replace("\n", "").Replace("&nbsp", "").Replace("&nbsp;", "").Trim('.').Trim(')');
                        obj.Exchange_Letter = title;
                        //Helper.AddtoLogFile("Exchange_Letter:" + obj.Exchange_Letter);
                    }
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
            catch (Exception ex)
            {
                //Helper.AddtoLogFile("Error:" + ex.ToString());
            }
            return obj;
        }
    }
}
