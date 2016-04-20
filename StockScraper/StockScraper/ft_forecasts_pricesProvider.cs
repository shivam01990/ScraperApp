using DLL;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScraper
{
    public class ft_forecasts_pricesProvider
    {
        public static List<ft_forecasts_prices> GetData(HtmlDocument doc, int job_id, int stock_id)
        {
            List<ft_forecasts_prices> lst_ft_forecasts_prices = new List<ft_forecasts_prices>();
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

            string Share_Price_ForeCast = "";
            try
            {
                Share_Price_ForeCast = doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'wsodModule') and contains(@class, 'contains') and contains(@class, 'wsodAboutTheCompany') and contains(@class, 'sharePriceForecast')]//div[@class='wsodModuleContent']//p").InnerText.Replace("View Full Financials", "");
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
                                ft_forecasts_prices temp = new ft_forecasts_prices();
                                decimal currentprice = 0;
                                decimal.TryParse(tr.ChildNodes[2].InnerText, out currentprice);
                                temp.share_price_forecast = Share_Price_ForeCast;
                                temp.target_level = tr.ChildNodes[0].InnerText;
                                temp.target_price = currentprice;
                                lst_ft_forecasts_prices.Add(temp);
                                //temp.current_price =

                                //if (tr.ChildNodes[0].InnerText.Trim().ToLower() == "high")
                                //{
                                //    rType.High_Percentage = tr.ChildNodes[1].InnerText;
                                //    rType.High_Value = tr.ChildNodes[2].InnerText;
                                //}
                                //if (tr.ChildNodes[0].InnerText.Trim().ToLower() == "med")
                                //{
                                //    rType.Med_Percentage = tr.ChildNodes[1].InnerText;
                                //    rType.Med_Value = tr.ChildNodes[2].InnerText;
                                //}
                                //if (tr.ChildNodes[0].InnerText.Trim().ToLower() == "low")
                                //{
                                //    rType.Low_Percentage = tr.ChildNodes[1].InnerText;
                                //    rType.Low_Value = tr.ChildNodes[2].InnerText;
                                //}

                            }
                            catch
                            {
                            }
                        }

                    }
                }
            }
            catch { }
            return lst_ft_forecasts_prices;
        }

    }
}
