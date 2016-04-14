using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDCDAL;
using HtmlAgilityPack;
using SDCBLL;
namespace SDCConsoleApp
{
    public class MarketsImporter
    {
        public static MarketMover StartImport(MarketMover obj)
        {
            HtmlWeb marketweb = new HtmlWeb();
            HtmlDocument marketdoc = marketweb.Load("http://markets.ft.com/research/Markets/Tearsheets/Summary?s=" + obj.Ticker);
            Helper.AddtoLogFile("fetching data from http://markets.ft.com/research/Markets/Tearsheets/Summary?s=:" + obj.Ticker);
            string datestring = "";
            try
            {
                datestring = marketdoc.DocumentNode.SelectNodes("//div[@id='wsod']//div[@class='contains componentFooter']//span")[0].InnerText ?? "";
            }
            catch
            {
            }
            if (datestring != "")
            {
                datestring = datestring.Replace("Data delayed at least 15 minutes, as of", "").Trim(); //"Data delayed at least 15 minutes, as of Apr 08 2016 16:40 BST. ";                           
                datestring = datestring.Trim('.');
                datestring = datestring.Length > 17 ? datestring.Substring(0, 17) : datestring;
                try
                {
                    //obj.Data_Display = DateTime.ParseExact(datestring, "MMM dd yyyy hh:mm", CultureInfo.InvariantCulture);
                    obj.Data_Display = DateTime.Parse(datestring);
                    Helper.AddtoLogFile("Data_Display:" + obj.Data_Display.ToString());
                }
                catch { }
            }
            try
            {
                string exchanging = marketdoc.DocumentNode.SelectNodes("//div[@class='freestyle']//ul[@class='wsodModuleContent']//li")[0].InnerText;
                exchanging = exchanging.ToLower().Contains("exchange:") ? exchanging.Replace("Exchange:", "") : "";
                obj.Exchange = exchanging;
                Helper.AddtoLogFile("Exchange:" + obj.Exchange);
            }
            catch { }

            try
            {
                string sector = marketdoc.DocumentNode.SelectNodes("//div[@class='freestyle']//ul[@class='wsodModuleContent']//li")[1].InnerText;
                sector = sector.ToLower().Contains("sector:") ? sector.Replace("Sector:", "") : "";
                obj.Sector = sector;
                Helper.AddtoLogFile("Sector:" + obj.Sector);
            }
            catch { }

            try
            {
                string industry = marketdoc.DocumentNode.SelectNodes("//div[@class='freestyle']//ul[@class='wsodModuleContent']//li")[2].InnerText;
                industry = industry.ToLower().Contains("industry:") ? industry.Replace("Industry:", "") : "";
                obj.Industry = industry;
                Helper.AddtoLogFile("Industry:" + obj.Industry);
            }
            catch { }           
            return obj;
        }
    }
}
