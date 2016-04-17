using DLL;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScraper
{
    public class ft_Financials_MgmtEffectivenessProvider
    {
        public static ft_Financials_MgmtEffectiveness GetData(HtmlDocument doc, int job_id, int stock_id)
        {
            ft_Financials_MgmtEffectiveness rType = new ft_Financials_MgmtEffectiveness();
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
                try
                {
                    //obj.Data_Display = DateTime.ParseExact(datestring, "MMM dd yyyy hh:mm", CultureInfo.InvariantCulture);
                    rType.EffectiveDate = datestring;
                    //Helper.AddtoLogFile("Data_Display:" + obj.Data_Display.ToString());
                }
                catch { }
            }

            try
            {
                string exchanging = doc.DocumentNode.SelectNodes("//div[@class='freestyle']//ul[@class='wsodModuleContent']//li")[0].InnerText;
                exchanging = exchanging.ToLower().Contains("exchange:") ? exchanging.Replace("Exchange:", "") : "";
                rType.Exchange = exchanging;
                //Helper.AddtoLogFile("Exchange:" + obj.Exchange);
            }
            catch { }

            try
            {
                string sector = doc.DocumentNode.SelectNodes("//div[@class='freestyle']//ul[@class='wsodModuleContent']//li")[1].InnerText;
                sector = sector.ToLower().Contains("sector:") ? sector.Replace("Sector:", "") : "";
                rType.Sector = sector;
                //Helper.AddtoLogFile("Sector:" + obj.Sector);
            }
            catch { }

            try
            {
                string industry = doc.DocumentNode.SelectNodes("//div[@class='freestyle']//ul[@class='wsodModuleContent']//li")[2].InnerText;
                industry = industry.ToLower().Contains("industry:") ? industry.Replace("Industry:", "") : "";
                rType.Industry = industry;
                //Helper.AddtoLogFile("Industry:" + obj.Industry);
            }
            catch { }

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
                                    rType.Buy = tr.ChildNodes[1].InnerText;
                                }
                                if (tr.ChildNodes[0].InnerText.Trim().ToLower() == "outperform")
                                {
                                    rType.OutPerforms = tr.ChildNodes[1].InnerText;
                                }
                                if (tr.ChildNodes[0].InnerText.Trim().ToLower() == "hold")
                                {
                                    rType.Hold = tr.ChildNodes[1].InnerText;
                                }
                                if (tr.ChildNodes[0].InnerText.Trim().ToLower() == "underperform")
                                {
                                    rType.UnderPerform = tr.ChildNodes[1].InnerText;
                                }
                                if (tr.ChildNodes[0].InnerText.Trim().ToLower() == "sell")
                                {
                                    rType.Sell = tr.ChildNodes[1].InnerText;
                                }
                                if (tr.ChildNodes[0].InnerText.Trim().ToLower() == "no opinion")
                                {
                                    rType.NoOpinion = tr.ChildNodes[1].InnerText;
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

            try
            {
                rType.Share_Price_ForeCast = doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'wsodModule') and contains(@class, 'contains') and contains(@class, 'wsodAboutTheCompany') and contains(@class, 'sharePriceForecast')]//div[@class='wsodModuleContent']//p").InnerText.Replace("View Full Financials", "");
            }
            catch { }

            try
            {
                var tblrows = doc.DocumentNode.SelectNodes("//div[contains(@class, 'wsodModule') and contains(@class, 'contains') and contains(@class, 'wsodAboutTheCompany') and contains(@class, 'sharePriceForecast')]//div[@class='wsodModuleContent']//table[@class='fright']//tr");
                if (tblrows != null)
                {
                    for (int k = 0; k < tblrows.Count; k++)
                    {
                        HtmlNode tr = tblrows[k];
                        if (tr.ChildNodes.Count() == 3)
                        {
                            try
                            {
                                if (tr.ChildNodes[0].InnerText.Trim().ToLower() == "high")
                                {
                                    rType.High_Percentage = tr.ChildNodes[1].InnerText;
                                    rType.High_Value = tr.ChildNodes[2].InnerText;
                                }
                                if (tr.ChildNodes[0].InnerText.Trim().ToLower() == "med")
                                {
                                    rType.Med_Percentage = tr.ChildNodes[1].InnerText;
                                    rType.Med_Value = tr.ChildNodes[2].InnerText;
                                }
                                if (tr.ChildNodes[0].InnerText.Trim().ToLower() == "low")
                                {
                                    rType.Low_Percentage = tr.ChildNodes[1].InnerText;
                                    rType.Low_Value = tr.ChildNodes[2].InnerText;
                                }

                            }
                            catch
                            {
                            }
                        }

                    }
                }
            }
            catch { }

            return rType;
        }
    }
}
