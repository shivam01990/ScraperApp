using HtmlAgilityPack;
using SDCBLL;
using SDCDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDCConsoleApp
{
    public class WikipediaImport
    {
        public static void StartImport()
        {
            try
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(Helper.GetWikipediaUrl());
                Helper.AddtoLogFile("=========================================================");
                Helper.AddtoLogFile("Start fetching data For URL:" + Helper.GetWikipediaUrl());

                {
                    string temphtml = doc.DocumentNode.SelectNodes("//div[@id='bodyContent']//table[contains(@class, 'wikitable') and contains(@class, 'sortable')]")[0].OuterHtml;
                    HtmlDocument temp = new HtmlDocument();
                    temp.LoadHtml(temphtml);
                    HtmlNodeCollection rowcollection = temp.DocumentNode.SelectNodes("//tr");
                    if (rowcollection != null)
                    {
                        for (int k = 1; k < rowcollection.Count; k++)
                        {
                            Helper.AddtoLogFile("Reading row number: " + k);
                            MarketMover obj = new MarketMover();
                            HtmlNode tr = rowcollection[k];
                            obj.Ticker = tr.ChildNodes[1].InnerText;
                            Helper.AddtoLogFile("Ticker:" + obj.Ticker);
                            obj.Name = tr.ChildNodes[3].InnerText;
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

                {
                    string temphtml = doc.DocumentNode.SelectNodes("//div[@id='bodyContent']//table[contains(@class, 'wikitable') and contains(@class, 'sortable')]")[1].OuterHtml;
                    HtmlDocument temp = new HtmlDocument();
                    temp.LoadHtml(temphtml);

                    var rowcollection = temp.DocumentNode.SelectNodes("//tr");
                    if (rowcollection != null)
                    {
                        for (int k = 2; k < rowcollection.Count; k++)
                        {
                            Helper.AddtoLogFile("Reading row number: " + k);
                            MarketMover obj = new MarketMover();
                            if (k < 124)
                            {                               
                                HtmlNode tr = rowcollection[k];
                                obj.Ticker = tr.ChildNodes[3].InnerText;
                                Helper.AddtoLogFile("Ticker:" + obj.Ticker);
                                obj.Name = tr.ChildNodes[5].InnerText;
                                Helper.AddtoLogFile("Name:" + obj.Name);
                            }
                            else
                            {
                                HtmlNode tr = rowcollection[k];
                                obj.Ticker = tr.ChildNodes[1].InnerText;
                                Helper.AddtoLogFile("Ticker:" + obj.Ticker);
                                obj.Name = tr.ChildNodes[3].InnerText;
                                Helper.AddtoLogFile("Name:" + obj.Name);
                            }
                             obj = MarketsImporter.StartImport(obj);
                             try
                             {
                                 MarketMoverServices.Instance.SaveMarketMover(obj);
                             }
                             catch (Exception ex) { Helper.AddtoLogFile("Exceltion:" + ex.ToString()); }
                        }
                    }
                }

                Helper.AddtoLogFile("=========================================================");
            }
            catch (Exception ex)
            {
                Helper.AddtoLogFile("Exception:" + ex.ToString());
            }
        }
    }
}
