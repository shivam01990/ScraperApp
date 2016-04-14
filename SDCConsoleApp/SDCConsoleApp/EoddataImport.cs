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
                foreach (string Url in Helper.GetEodataUrls())                                                          //Getting all Master URL Lists
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

                                obj = MarketsImporter.StartImport(obj);

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
