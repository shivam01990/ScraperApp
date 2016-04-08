using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDCDAL;
using HtmlAgilityPack;
using System.Globalization;
using SDCBLL;

namespace SDCConsoleApp
{
    public class EoddataImport
    {
        public static void StartImport()
        {
            try
            {
                List<MarketMover> _lstdata = new List<MarketMover>();
                foreach (string Url in Helper.GetUrls())                                                          //Getting all Master URL Lists
                {
                    HtmlWeb web = new HtmlWeb();
                    HtmlDocument doc = web.Load(Url);
                    Helper.AddtoLogFile("Start Running Loop For URL:" + Url);
                    try
                    {
                        HtmlNodeCollection rowcollection = doc.DocumentNode.SelectNodes("//div[@id='ctl00_cph1_divSymbols']//table[@class='quotes']//tr");
                        if (rowcollection != null)
                        {
                            for (int k = 1; k < rowcollection.Count; k++)
                            {
                                Helper.AddtoLogFile("Reading row number" + k);
                                MarketMover obj = new MarketMover();
                                HtmlNode tr = rowcollection[k];
                                obj.Ticker = tr.ChildNodes[0].InnerText;
                                Helper.AddtoLogFile("Ticker:" + obj.Ticker);
                                obj.Name = tr.ChildNodes[1].InnerText;
                                Helper.AddtoLogFile("Name:" + obj.Name);

                                HtmlWeb marketweb = new HtmlWeb();
                                HtmlDocument marketdoc = web.Load("http://markets.ft.com/research/Markets/Tearsheets/Summary?s=" + obj.Ticker);
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
                                try
                                {
                                    MarketMoverServices.Instance.SaveMarketMover(obj);
                                }
                                catch (Exception ex) { Helper.AddtoLogFile("Exceltion:" + ex.ToString()); }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Helper.AddtoLogFile("Exceltion:" + ex.ToString());
                    }



                }
            }

            catch (Exception ex)
            {
                Helper.AddtoLogFile("Exceltion:" + ex.ToString());
            }
        }
    }
}
