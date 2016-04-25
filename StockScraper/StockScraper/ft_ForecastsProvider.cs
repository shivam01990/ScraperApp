using DLL;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScraper
{
    public class ft_ForecastsProvider
    {
        public static ft_Forecasts GetData(HtmlDocument doc, int job_id, int stock_id)
        {
            ft_Forecasts rType = new ft_Forecasts();
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

            //Share_Price_ForeCast
            string Share_Price_ForeCast = "";
            try
            {
                Share_Price_ForeCast = doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'wsodModule') and contains(@class, 'contains') and contains(@class, 'wsodAboutTheCompany') and contains(@class, 'sharePriceForecast')]//div[@class='wsodModuleContent']//p").InnerText.Replace("View Full Financials", "");
                rType.forecast_description = Share_Price_ForeCast;
            }
            catch { }

            //currentprice
            try
            {
                decimal currentprice = 0;
                string strcurrentprice = "";
                if (Share_Price_ForeCast != "")
                {
                    try
                    {

                        strcurrentprice = Share_Price_ForeCast.Substring(Share_Price_ForeCast.IndexOf("last price of")).Replace("last price of", "");
                    }
                    catch { }
                }
                decimal.TryParse(strcurrentprice, out currentprice);
                rType.current_price = currentprice;
            }
            catch
            { }

            //Time perioud
            Int16 time_perioud = 0;
            string time_perioud_unit = "";
            try
            {              
                
                string time = Helper.ExtractFromString(Share_Price_ForeCast, "analysts offering", "price targets")[0].Trim();

               
                if (time.Length > 0)
                {
                    Int16.TryParse(time.Split(' ')[0], out time_perioud);
                    time_perioud_unit = time.Split(' ')[1];
                }
            }
            catch { }
            rType.time_period = time_perioud;
            rType.time_period_unit = time_perioud_unit;

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
                                //ft_forecasts_prices temp = new ft_forecasts_prices();
                                //decimal currentprice = 0;
                                //decimal.TryParse(tr.ChildNodes[2].InnerText, out currentprice);
                                //temp.share_price_forecast = Share_Price_ForeCast;
                                //temp.target_level = tr.ChildNodes[0].InnerText;
                                //temp.target_price = currentprice;
                                //lst_ft_forecasts_prices.Add(temp);
                                //temp.current_price =

                                if (tr.ChildNodes[0].InnerText.Trim().ToLower() == "high")
                                {
                                    //rType.High_Percentage = tr.ChildNodes[1].InnerText;
                                    decimal high_target_price = 0;
                                    decimal.TryParse(tr.ChildNodes[2].InnerText, out high_target_price);
                                    rType.high_target_price = high_target_price;
                                }
                                if (tr.ChildNodes[0].InnerText.Trim().ToLower() == "med")
                                {
                                    //rType.Med_Percentage = tr.ChildNodes[1].InnerText;
                                    decimal medium_target_price = 0;
                                    decimal.TryParse(tr.ChildNodes[2].InnerText, out medium_target_price);
                                    rType.medium_target_price = medium_target_price;
                                }
                                if (tr.ChildNodes[0].InnerText.Trim().ToLower() == "low")
                                {
                                    //rType.Low_Percentage = tr.ChildNodes[1].InnerText;
                                    decimal low_target_price = 0;
                                    decimal.TryParse(tr.ChildNodes[2].InnerText, out low_target_price);
                                    rType.low_target_price = low_target_price;
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
