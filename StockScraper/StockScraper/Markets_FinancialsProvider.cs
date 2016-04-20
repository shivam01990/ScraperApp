using DLL;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockScraper
{
    public class Markets_FinancialsProvider
    {
        public static void GetData(HtmlDocument doc, int job_id, int stock_id)
        {
            List<ft_fin_revenue_and_gross_profit> lst_revenue_and_gross_profit = new List<ft_fin_revenue_and_gross_profit>();
            List<ft_fin_operating_expenses> lst_operating_expenses = new List<ft_fin_operating_expenses>();
            List<ft_fin_incometaxes_minorityinterest_extras> lst_incometaxes_minorityinterest_extras = new List<ft_fin_incometaxes_minorityinterest_extras>();
            List<ft_fin_proforma_income> lst_ft_fin_proforma_income = new List<ft_fin_proforma_income>();
            List<ft_fin_common_stock_dividends> lst_ft_fin_common_stock_dividends = new List<ft_fin_common_stock_dividends>();
            List<ft_fin_supplemetal_income> lst_ft_fin_supplemetal_income = new List<ft_fin_supplemetal_income>();
            List<ft_fin_normalized_income> lst_ft_fin_normalized_income = new List<ft_fin_normalized_income>();
            HtmlNodeCollection rowcollection = doc.DocumentNode.SelectNodes("//div[contains(@class, 'wsodModule') and contains(@class, 'contains') and contains(@class, 'financialStatement')  and contains(@class, 'wsodModuleLastInGridColumn')]");

            if (rowcollection.Count > 0)
            {
                Int16 TypeID = 1;
                var tblrows = rowcollection[0].SelectNodes("div[@class='statementView']//table//tr");
                if (tblrows != null)
                {
                    for (int k = 1; k < tblrows.Count; k++)
                    {
                        HtmlNode tr = tblrows[k];

                        if (tr.ChildNodes.Count() == 4)
                        {
                            try
                            {
                                if (TypeID == 1)
                                {
                                    ft_fin_revenue_and_gross_profit temp_ft_fin_revenue_and_gross_profit = new ft_fin_revenue_and_gross_profit();
                                    temp_ft_fin_revenue_and_gross_profit.Title = tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ");
                                    temp_ft_fin_revenue_and_gross_profit.First_Year = tr.ChildNodes[1].InnerText;
                                    temp_ft_fin_revenue_and_gross_profit.Second_Year = tr.ChildNodes[2].InnerText;
                                    temp_ft_fin_revenue_and_gross_profit.Third_Year = tr.ChildNodes[3].InnerText;
                                    temp_ft_fin_revenue_and_gross_profit.job_run_id = job_id;
                                    temp_ft_fin_revenue_and_gross_profit.stock_id = stock_id;
                                    lst_revenue_and_gross_profit.Add(temp_ft_fin_revenue_and_gross_profit);
                                }

                                if (TypeID == 2)
                                {
                                    ft_fin_operating_expenses temp_ft_fin_operating_expenses = new ft_fin_operating_expenses();
                                    temp_ft_fin_operating_expenses.Title = tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ");
                                    temp_ft_fin_operating_expenses.First_Year = tr.ChildNodes[1].InnerText;
                                    temp_ft_fin_operating_expenses.Second_Year = tr.ChildNodes[2].InnerText;
                                    temp_ft_fin_operating_expenses.Third_Year = tr.ChildNodes[3].InnerText;
                                    temp_ft_fin_operating_expenses.job_run_id = job_id;
                                    temp_ft_fin_operating_expenses.stock_id = stock_id;
                                    lst_operating_expenses.Add(temp_ft_fin_operating_expenses);
                                }

                                if (TypeID == 3)
                                {
                                    ft_fin_incometaxes_minorityinterest_extras temp_ft_fin_incometaxes_minorityinterest_extras = new ft_fin_incometaxes_minorityinterest_extras();
                                    temp_ft_fin_incometaxes_minorityinterest_extras.Title = tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ");
                                    temp_ft_fin_incometaxes_minorityinterest_extras.First_Year = tr.ChildNodes[1].InnerText;
                                    temp_ft_fin_incometaxes_minorityinterest_extras.Second_Year = tr.ChildNodes[2].InnerText;
                                    temp_ft_fin_incometaxes_minorityinterest_extras.Third_Year = tr.ChildNodes[3].InnerText;
                                    temp_ft_fin_incometaxes_minorityinterest_extras.job_run_id = job_id;
                                    temp_ft_fin_incometaxes_minorityinterest_extras.stock_id = stock_id;
                                    lst_incometaxes_minorityinterest_extras.Add(temp_ft_fin_incometaxes_minorityinterest_extras);
                                }

                                if (TypeID == 4)
                                {

                                    ft_fin_common_stock_dividends temp_ft_fin_common_stock_dividends = new ft_fin_common_stock_dividends();
                                    temp_ft_fin_common_stock_dividends.Title = tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ");
                                    temp_ft_fin_common_stock_dividends.First_Year = tr.ChildNodes[1].InnerText;
                                    temp_ft_fin_common_stock_dividends.Second_Year = tr.ChildNodes[2].InnerText;
                                    temp_ft_fin_common_stock_dividends.Third_Year = tr.ChildNodes[3].InnerText;
                                    temp_ft_fin_common_stock_dividends.job_run_id = job_id;
                                    temp_ft_fin_common_stock_dividends.stock_id = stock_id;
                                    lst_ft_fin_common_stock_dividends.Add(temp_ft_fin_common_stock_dividends);
                                }

                                if (TypeID == 5)
                                {
                                    ft_fin_proforma_income temp_ft_fin_proforma_income = new ft_fin_proforma_income();
                                    temp_ft_fin_proforma_income.Title = tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ");
                                    temp_ft_fin_proforma_income.First_Year = tr.ChildNodes[1].InnerText;
                                    temp_ft_fin_proforma_income.Second_Year = tr.ChildNodes[2].InnerText;
                                    temp_ft_fin_proforma_income.Third_Year = tr.ChildNodes[3].InnerText;
                                    temp_ft_fin_proforma_income.job_run_id = job_id;
                                    temp_ft_fin_proforma_income.stock_id = stock_id;
                                    lst_ft_fin_proforma_income.Add(temp_ft_fin_proforma_income);
                                }

                                if (TypeID == 6)
                                {

                                    ft_fin_supplemetal_income temp_ft_fin_supplemetal_income = new ft_fin_supplemetal_income();
                                    temp_ft_fin_supplemetal_income.Title = tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ");
                                    temp_ft_fin_supplemetal_income.First_Year = tr.ChildNodes[1].InnerText;
                                    temp_ft_fin_supplemetal_income.Second_Year = tr.ChildNodes[2].InnerText;
                                    temp_ft_fin_supplemetal_income.Third_Year = tr.ChildNodes[3].InnerText;
                                    temp_ft_fin_supplemetal_income.job_run_id = job_id;
                                    temp_ft_fin_supplemetal_income.stock_id = stock_id;
                                    lst_ft_fin_supplemetal_income.Add(temp_ft_fin_supplemetal_income);
                                }

                                if (TypeID == 7)
                                {

                                    ft_fin_normalized_income temp_ft_fin_normalized_income = new ft_fin_normalized_income();
                                    temp_ft_fin_normalized_income.Title = tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ");
                                    temp_ft_fin_normalized_income.First_Year = tr.ChildNodes[1].InnerText;
                                    temp_ft_fin_normalized_income.Second_Year = tr.ChildNodes[2].InnerText;
                                    temp_ft_fin_normalized_income.Third_Year = tr.ChildNodes[3].InnerText;
                                    temp_ft_fin_normalized_income.job_run_id = job_id;
                                    temp_ft_fin_normalized_income.stock_id = stock_id;
                                    lst_ft_fin_normalized_income.Add(temp_ft_fin_normalized_income);
                                }
                            }
                            catch
                            {
                            }
                        }
                        else
                        {
                            if (tr.ChildNodes[0].InnerText.ToUpper() == "REVENUE AND GROSS PROFIT")
                            {
                                TypeID = 1;
                            }
                            if (tr.ChildNodes[0].InnerText.ToUpper() == "OPERATING EXPENSES")
                            {
                                TypeID = 2;
                            }
                            if (tr.ChildNodes[0].InnerText.ToUpper() == "INCOME TAXES, MINORITY INTEREST AND EXTRA ITEMS")
                            {
                                TypeID = 3;
                            }
                            if (tr.ChildNodes[0].InnerText.ToUpper() == "COMMON STOCK DIVIDENDS")
                            {
                                TypeID = 4;
                            }
                            if (tr.ChildNodes[0].InnerText.ToUpper() == "PRO FORMA INCOME")
                            {
                                TypeID = 5;
                            }
                            if (tr.ChildNodes[0].InnerText.ToUpper() == "SUPPLEMENTAL INCOME")
                            {
                                TypeID = 6;
                            }
                            if (tr.ChildNodes[0].InnerText.ToUpper() == "NORMALIZED INCOME")
                            {
                                TypeID = 7;
                            }
                        }

                    }
                }
            }
        }

    }
}
