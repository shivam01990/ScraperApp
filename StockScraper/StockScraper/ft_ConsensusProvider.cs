using DLL;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScraper
{
    public class ft_ConsensusProvider
    {
        public static ft_Consensus GetData(HtmlDocument doc, int job_id, int stock_id)
        {
            ft_Consensus rType = new ft_Consensus();
            rType.job_run_id = job_id;
            rType.stock_id = stock_id;
            string datestring = "";
            try
            {
                datestring = doc.DocumentNode.SelectNodes("//div[@id='wsod']//div[@class='contains componentFooter']//span")[0].InnerText ?? "";
            }
            catch
            {
            }
            if (datestring != "")
            {
                datestring = datestring.Replace("Data delayed at least 15 minutes, as of", "").Trim(); //"Data delayed at least 15 minutes, as of Apr 08 2016 16:40 BST. ";                           
                datestring = datestring.Trim('.');
                datestring = datestring.Length > 17 ? datestring.Substring(0, 17) : datestring;

                DateTime Data_Display = DateTime.Parse(datestring);
                rType.effective_date = Data_Display.ToString("yyyy.MM.dd-hh:mm");
            }

            //try
            //{
            //    string exchanging = doc.DocumentNode.SelectNodes("//div[@class='freestyle']//ul[@class='wsodModuleContent']//li")[0].InnerText;
            //    exchanging = exchanging.ToLower().Contains("exchange:") ? exchanging.Replace("Exchange:", "") : "";
            //    rType.Exchange = exchanging;
            //    //Helper.AddtoLogFile("Exchange:" + obj.Exchange);
            //}
            //catch { }

            //try
            //{
            //    string sector = doc.DocumentNode.SelectNodes("//div[@class='freestyle']//ul[@class='wsodModuleContent']//li")[1].InnerText;
            //    sector = sector.ToLower().Contains("sector:") ? sector.Replace("Sector:", "") : "";
            //    rType.Sector = sector;
            //    //Helper.AddtoLogFile("Sector:" + obj.Sector);
            //}
            //catch { }

            //try
            //{
            //    string industry = doc.DocumentNode.SelectNodes("//div[@class='freestyle']//ul[@class='wsodModuleContent']//li")[2].InnerText;
            //    industry = industry.ToLower().Contains("industry:") ? industry.Replace("Industry:", "") : "";
            //    rType.Industry = industry;
            //    //Helper.AddtoLogFile("Industry:" + obj.Industry);
            //}
            //catch { }

            //Consensus recommendation
            string consensus_recommendation = "";
            try
            {  //smartText contains wsodModuleLastInGridColumn
                consensus_recommendation = doc.DocumentNode.SelectNodes("//div[contains(@class, 'smartText') and contains(@class, 'contains') and contains(@class, 'wsodModuleLastInGridColumn')]//p")[0].InnerText;
                rType.consensus = consensus_recommendation;
            }
            catch
            { }

            //Latest Recommendation table
            try
            {
                var tblrows = doc.DocumentNode.SelectNodes("//div[contains(@class, 'wsodRecommendationRating') and contains(@class, 'wsodModuleLastInGridColumn')]//table//tr");
                if (tblrows != null)
                {
                    for (int k = 0; k < tblrows.Count; k++)
                    {
                        HtmlNode tr = tblrows[k];
                        if (tr.ChildNodes.Count() == 2)
                        {
                            try
                            {

                                if (tr.ChildNodes[0].InnerText.Trim().ToLower() == "buy")
                                {
                                    Int16 buy_analyst_count = 0;
                                    Int16.TryParse(tr.ChildNodes[1].InnerText,out buy_analyst_count);
                                    rType.buy_analyst_count = buy_analyst_count;
                                }
                                if (tr.ChildNodes[0].InnerText.Trim().ToLower() == "outperform")
                                {
                                    Int16 outperform_analyst_count = 0;
                                    Int16.TryParse(tr.ChildNodes[1].InnerText, out outperform_analyst_count);
                                    rType.outperform_analyst_count = outperform_analyst_count;
                                }
                                if (tr.ChildNodes[0].InnerText.Trim().ToLower() == "hold")
                                {
                                    Int16 hold_analyst_count = 0;
                                    Int16.TryParse(tr.ChildNodes[1].InnerText, out hold_analyst_count);
                                    rType.hold_analyst_count = hold_analyst_count;
                                }
                                if (tr.ChildNodes[0].InnerText.Trim().ToLower() == "underperform")
                                {
                                    Int16 underperform_analyst_count = 0;
                                    Int16.TryParse(tr.ChildNodes[1].InnerText, out underperform_analyst_count);
                                    rType.underperform_analyst_count = underperform_analyst_count;
                                }
                                if (tr.ChildNodes[0].InnerText.Trim().ToLower() == "sell")
                                {
                                    Int16 sell_analyst_count = 0;
                                    Int16.TryParse(tr.ChildNodes[1].InnerText, out sell_analyst_count);
                                    rType.sell_analyst_count = sell_analyst_count;
                                }
                                if (tr.ChildNodes[0].InnerText.Trim().ToLower() == "no opinion")
                                {
                                    Int16 no_opinion_analyst_count = 0;
                                    Int16.TryParse(tr.ChildNodes[1].InnerText, out no_opinion_analyst_count);
                                    rType.no_opinion_analyst_count = no_opinion_analyst_count;
                                }
                            }
                            catch
                            {
                            }
                        }

                    }
                }
            }
            catch
            {

            }
            //Share price forecast



            return rType;
        }
    }
}
