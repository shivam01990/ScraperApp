using DLL;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScraper
{
    public class ft_forecasts_recommendationsProvider
    {
        public static List<ft_forecasts_recommendations> GetData(HtmlDocument doc, int job_id, int stock_id)
        {
            List<ft_forecasts_recommendations> lst_ft_forecasts_recommendations = new List<ft_forecasts_recommendations>(); 
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
                                ft_forecasts_recommendations temp_ft_forecasts_recommendations = new ft_forecasts_recommendations();
                                temp_ft_forecasts_recommendations.Recommendation_consensus = consensus_recommendation;
                                temp_ft_forecasts_recommendations.Recommendation_type = tr.ChildNodes[0].InnerText;
                                Int16 Recommendations = 0;
                                Int16.TryParse(tr.ChildNodes[1].InnerText, out Recommendations);
                                temp_ft_forecasts_recommendations.Recommendations = Recommendations;
                                lst_ft_forecasts_recommendations.Add(temp_ft_forecasts_recommendations);
                                //if (tr.ChildNodes[0].InnerText.Trim().ToLower() == "buy")
                                //{
                                //    rType.Buy = tr.ChildNodes[1].InnerText;
                                //}
                                //if (tr.ChildNodes[0].InnerText.Trim().ToLower() == "outperform")
                                //{
                                //    rType.OutPerforms = tr.ChildNodes[1].InnerText;
                                //}
                                //if (tr.ChildNodes[0].InnerText.Trim().ToLower() == "hold")
                                //{
                                //    rType.Hold = tr.ChildNodes[1].InnerText;
                                //}
                                //if (tr.ChildNodes[0].InnerText.Trim().ToLower() == "underperform")
                                //{
                                //    rType.UnderPerform = tr.ChildNodes[1].InnerText;
                                //}
                                //if (tr.ChildNodes[0].InnerText.Trim().ToLower() == "sell")
                                //{
                                //    rType.Sell = tr.ChildNodes[1].InnerText;
                                //}
                                //if (tr.ChildNodes[0].InnerText.Trim().ToLower() == "no opinion")
                                //{
                                //    rType.NoOpinion = tr.ChildNodes[1].InnerText;
                                //}
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



            return lst_ft_forecasts_recommendations;
        }
    }
}
