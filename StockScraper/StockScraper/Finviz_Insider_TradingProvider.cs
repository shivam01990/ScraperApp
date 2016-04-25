using DLL;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScraper
{
    public class finviz_Insider_TradingProvider
    {
        public static List<finviz_Insider_Trading> GetData(HtmlDocument doc, int job_id, int stock_id,string URL)
        {
            List<finviz_Insider_Trading> rType = new List<finviz_Insider_Trading>();

            string EffectiveDate = DateTime.Now.ToString("yyyy.MM.dd");
            var tblrows1 = doc.DocumentNode.SelectNodes("//table[@class='body-table']//tr");
            if (tblrows1 != null)
            {
                for (int k = 1; k < tblrows1.Count; k++)
                {
                    HtmlNode tr1 = tblrows1[k];
                    if (tr1.ChildNodes.Count() == 9)
                    {
                        try
                        {

                            finviz_Insider_Trading temp = new finviz_Insider_Trading();
                            temp.insider_Trading = tr1.ChildNodes[0].InnerText;
                            temp.relationship = tr1.ChildNodes[1].InnerText;
                            temp.Date = tr1.ChildNodes[2].InnerText;
                            temp.it_transaction = tr1.ChildNodes[3].InnerText;
                            temp.cost = tr1.ChildNodes[4].InnerText;
                            temp.shares = tr1.ChildNodes[5].InnerText;
                            temp.value = tr1.ChildNodes[6].InnerText;
                            temp.shares_Total = tr1.ChildNodes[7].InnerText;
                            temp.SEC_Form_4 = tr1.ChildNodes[8].InnerText;
                            temp.stock_Id = stock_id;
                            temp.Job_run_Id = job_id;
                            temp.EffectiveDate = EffectiveDate;
                            rType.Add(temp);
                        }
                        catch
                        {
                        }
                    }

                }
            }
            else
            {
                string warningmsg = Helper.GetWarningMSG(stock_id, "finviz_Insider_Trading", URL);
                Helper.AddtoLog(warningmsg, job_id, true, Helper.LogStatus.warning);
            }
            return rType;
        }

    }
}
