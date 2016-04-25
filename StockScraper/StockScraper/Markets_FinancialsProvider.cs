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
        public static List<ft_Financials> GetData(HtmlDocument doc, int job_id, int stock_id,string EffectiveDate,string URL)
        {

            List<ft_Financials> lst = new List<ft_Financials>();
           


            HtmlNodeCollection rowcollection = doc.DocumentNode.SelectNodes("//div[contains(@class, 'wsodModule') and contains(@class, 'contains') and contains(@class, 'financialStatement')  and contains(@class, 'wsodModuleLastInGridColumn')]");
            if (rowcollection != null)
            {
                if (rowcollection.Count > 0)
                {
                    Int16 TypeID = 0;
                    var tblrows = rowcollection[0].SelectNodes("div[@class='statementView']//table//tr");
                    if (tblrows != null)
                    {
                        ft_Financials temp_year_one = new ft_Financials();
                        ft_Financials temp_year_two = new ft_Financials();
                        ft_Financials temp_year_three = new ft_Financials();
                        temp_year_one.effective_date = EffectiveDate;
                        temp_year_two.effective_date = EffectiveDate;
                        temp_year_three.effective_date = EffectiveDate;
                        temp_year_three.job_run_id = job_id;
                        temp_year_two.job_run_id = job_id;
                        temp_year_one.job_run_id = job_id;

                        temp_year_three.stock_id = stock_id;
                        temp_year_two.stock_id = stock_id;
                        temp_year_one.stock_id = stock_id;
                        for (int k = 0; k < tblrows.Count; k++)
                        {
                            HtmlNode tr = tblrows[k];

                            if (tr.ChildNodes.Count() == 4)
                            {
                                try
                                {
                                    if (TypeID == 0)
                                    {
                                        temp_year_one.year = tr.ChildNodes[1].InnerText;
                                        temp_year_two.year = tr.ChildNodes[2].InnerText;
                                        temp_year_three.year = tr.ChildNodes[3].InnerText;

                                       
                                    }
                                    if (TypeID == 1)
                                    {

                                        decimal param1 = 0;
                                        decimal param2 = 0;
                                        decimal param3 = 0;

                                        decimal.TryParse(tr.ChildNodes[1].InnerText, out param1);
                                        decimal.TryParse(tr.ChildNodes[2].InnerText, out param2);
                                        decimal.TryParse(tr.ChildNodes[3].InnerText, out param3);


                                        temp_year_one.ragp_total_revenue = param1;
                                        temp_year_two.ragp_total_revenue = param2;
                                        temp_year_three.ragp_total_revenue = param3;

                                    }

                                    if (TypeID == 2)
                                    {
                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "cost of revenue total")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText, out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText, out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText, out param3);

                                            temp_year_one.oe_cost_of_revenue_total = param1;
                                            temp_year_two.oe_cost_of_revenue_total = param2;
                                            temp_year_three.oe_cost_of_revenue_total = param3;
                                        }

                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "selling, general and admin. expenses, total")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText, out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText, out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText, out param3);

                                            temp_year_one.oe_selling_generalexpenses_total = param1;
                                            temp_year_two.oe_selling_generalexpenses_total = param2;
                                            temp_year_three.oe_selling_generalexpenses_total = param3;
                                        }

                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "depreciation/amortization")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText, out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText, out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText, out param3);

                                            temp_year_one.oe_depreciation_amort = param1;
                                            temp_year_two.oe_depreciation_amort = param2;
                                            temp_year_three.oe_depreciation_amort = param3;
                                        }

                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "unusual expense(income)")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText, out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText, out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText, out param3);

                                            temp_year_one.oe_unusual_expense_income = param1;
                                            temp_year_two.oe_unusual_expense_income = param2;
                                            temp_year_three.oe_unusual_expense_income = param3;
                                        }

                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "other operating expenses, total")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText, out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText, out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText, out param3);

                                            temp_year_one.oe_other_operating_expenses_total = param1;
                                            temp_year_two.oe_other_operating_expenses_total = param2;
                                            temp_year_three.oe_other_operating_expenses_total = param3;
                                        }
                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "total operating expense")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText, out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText, out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText, out param3);

                                            temp_year_one.oe_total_operating_expense = param1;
                                            temp_year_two.oe_total_operating_expense = param2;
                                            temp_year_three.oe_total_operating_expense = param3;
                                        }

                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "operating income")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText, out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText, out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText, out param3);

                                            temp_year_one.oe_operating_income = param1;
                                            temp_year_two.oe_operating_income = param2;
                                            temp_year_three.oe_operating_income = param3;
                                        }

                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "other, net")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText.Trim('(').Trim(')'), out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText.Trim('(').Trim(')'), out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText.Trim('(').Trim(')'), out param3);

                                            temp_year_one.oe_other_net = param1;
                                            temp_year_two.oe_other_net = param2;
                                            temp_year_three.oe_other_net = param3;
                                        }

                                    }

                                    if (TypeID == 3)
                                    {
                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "net income before taxes")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText, out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText, out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText, out param3);

                                            temp_year_one.itmiei_net_income_before_taxes = param1;
                                            temp_year_two.itmiei_net_income_before_taxes = param2;
                                            temp_year_three.itmiei_net_income_before_taxes = param3;
                                        }
                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "provision for income taxes")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText, out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText, out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText, out param3);

                                            temp_year_one.itmiei_provision_for_income_taxes = param1;
                                            temp_year_two.itmiei_provision_for_income_taxes = param2;
                                            temp_year_three.itmiei_provision_for_income_taxes = param3;
                                        }
                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "net income after taxes")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText, out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText, out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText, out param3);

                                            temp_year_one.itmiei_net_income_after_taxes = param1;
                                            temp_year_two.itmiei_net_income_after_taxes = param2;
                                            temp_year_three.itmiei_net_income_after_taxes = param3;
                                        }

                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "minority interest")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText, out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText, out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText, out param3);

                                            temp_year_one.itmiei_minority_interest = param1;
                                            temp_year_two.itmiei_minority_interest = param2;
                                            temp_year_three.itmiei_minority_interest = param3;
                                        }

                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "net income before extra. items")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText, out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText, out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText, out param3);

                                            temp_year_one.itmiei_net_income_before_extra_items = param1;
                                            temp_year_two.itmiei_net_income_before_extra_items = param2;
                                            temp_year_three.itmiei_net_income_before_extra_items = param3;
                                        }

                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "total extraordinary items")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText, out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText, out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText, out param3);

                                            temp_year_one.itmiei_total_extraordinary_items = param1;
                                            temp_year_two.itmiei_total_extraordinary_items = param2;
                                            temp_year_three.itmiei_total_extraordinary_items = param3;
                                        }

                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "net income")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText, out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText, out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText, out param3);

                                            temp_year_one.itmiei_net_income = param1;
                                            temp_year_two.itmiei_net_income = param2;
                                            temp_year_three.itmiei_net_income = param3;
                                        }


                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "inc.avail. to common excl. extra. items")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText, out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText, out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText, out param3);

                                            temp_year_one.itmiei_inc_to_common_excl_extra_items = param1;
                                            temp_year_two.itmiei_inc_to_common_excl_extra_items = param2;
                                            temp_year_three.itmiei_inc_to_common_excl_extra_items = param3;
                                        }

                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "inc.avail. to common incl. extra. items")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText, out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText, out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText, out param3);

                                            temp_year_one.itmiei_inc_to_common_incl_extra_items = param1;
                                            temp_year_two.itmiei_inc_to_common_incl_extra_items = param2;
                                            temp_year_three.itmiei_inc_to_common_incl_extra_items = param3;
                                        }
                                    }

                                    if (TypeID == 4)
                                    {
                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "basic/primary weighted average shares")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText, out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText, out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText, out param3);

                                            temp_year_one.epsr_basic_weighted_average_shares = param1;
                                            temp_year_two.epsr_basic_weighted_average_shares = param2;
                                            temp_year_three.epsr_basic_weighted_average_shares = param3;
                                        }

                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "basic/primary eps excl. extra items")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText, out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText, out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText, out param3);

                                            temp_year_one.epsr_basic_eps_excl_extra_items = param1;
                                            temp_year_two.epsr_basic_eps_excl_extra_items = param2;
                                            temp_year_three.epsr_basic_eps_excl_extra_items = param3;
                                        }



                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "basic/primary eps incl. extra items")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText.Trim('(').Trim(')'), out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText.Trim('(').Trim(')'), out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText.Trim('(').Trim(')'), out param3);

                                            temp_year_one.epsr_basic_eps_incl_extra_items = param1;
                                            temp_year_two.epsr_basic_eps_incl_extra_items = param2;
                                            temp_year_three.epsr_basic_eps_incl_extra_items = param3;
                                        }

                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "dilution adjustment")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText.Trim('(').Trim(')'), out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText.Trim('(').Trim(')'), out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText.Trim('(').Trim(')'), out param3);

                                            temp_year_one.epsr_dilution_adjustment = param1;
                                            temp_year_two.epsr_dilution_adjustment = param2;
                                            temp_year_three.epsr_dilution_adjustment = param3;
                                        }


                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "diluted weighted average shares")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText.Trim('(').Trim(')'), out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText.Trim('(').Trim(')'), out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText.Trim('(').Trim(')'), out param3);

                                            temp_year_one.epsr_diluted_weighted_average_shares = param1;
                                            temp_year_two.epsr_diluted_weighted_average_shares = param2;
                                            temp_year_three.epsr_diluted_weighted_average_shares = param3;
                                        }

                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "diluted eps excl. extra items")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText.Trim('(').Trim(')'), out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText.Trim('(').Trim(')'), out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText.Trim('(').Trim(')'), out param3);

                                            temp_year_one.epsr_diluted_eps_excl_extra_items = param1;
                                            temp_year_two.epsr_diluted_eps_excl_extra_items = param2;
                                            temp_year_three.epsr_diluted_eps_excl_extra_items = param3;
                                        }

                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "diluted eps incl. extra items")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText.Trim('(').Trim(')'), out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText.Trim('(').Trim(')'), out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText.Trim('(').Trim(')'), out param3);

                                            temp_year_one.epsr_diluted_eps_incl_extra_items = param1;
                                            temp_year_two.epsr_diluted_eps_incl_extra_items = param2;
                                            temp_year_three.epsr_diluted_eps_incl_extra_items = param3;
                                        }
                                    }

                                    if (TypeID == 5)
                                    {
                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "dps - common stock primary issue")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText.Trim('(').Trim(')'), out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText.Trim('(').Trim(')'), out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText.Trim('(').Trim(')'), out param3);

                                            temp_year_one.csd_dps_common_stock_primary_issue = param1;
                                            temp_year_two.csd_dps_common_stock_primary_issue = param2;
                                            temp_year_three.csd_dps_common_stock_primary_issue = param3;
                                        }

                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "gross dividend - common stock")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText.Trim('(').Trim(')'), out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText.Trim('(').Trim(')'), out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText.Trim('(').Trim(')'), out param3);

                                            temp_year_one.csd_gross_dividend_common_stock = param1;
                                            temp_year_two.csd_gross_dividend_common_stock = param2;
                                            temp_year_three.csd_gross_dividend_common_stock = param3;
                                        }
                                    }

                                    if (TypeID == 6)
                                    {

                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "pro forma net income")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText.Trim('(').Trim(')'), out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText.Trim('(').Trim(')'), out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText.Trim('(').Trim(')'), out param3);

                                            temp_year_one.pfi_pro_forma_net_income = param1;
                                            temp_year_two.pfi_pro_forma_net_income = param2;
                                            temp_year_three.pfi_pro_forma_net_income = param3;
                                        }

                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "interest expense, supplemental")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText.Trim('(').Trim(')'), out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText.Trim('(').Trim(')'), out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText.Trim('(').Trim(')'), out param3);

                                            temp_year_one.pfi_interest_expense_supplemental = param1;
                                            temp_year_two.pfi_interest_expense_supplemental = param2;
                                            temp_year_three.pfi_interest_expense_supplemental = param3;
                                        }

                                    }

                                    if (TypeID == 7)
                                    {

                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "depreciation, supplemental")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText.Trim('(').Trim(')'), out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText.Trim('(').Trim(')'), out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText.Trim('(').Trim(')'), out param3);

                                            temp_year_one.si_depreciation_supplemental = param1;
                                            temp_year_two.si_depreciation_supplemental = param2;
                                            temp_year_three.si_depreciation_supplemental = param3;
                                        }


                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "total special items")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText.Trim('(').Trim(')'), out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText.Trim('(').Trim(')'), out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText.Trim('(').Trim(')'), out param3);

                                            temp_year_one.si_total_special_items = param1;
                                            temp_year_two.si_total_special_items = param2;
                                            temp_year_three.si_total_special_items = param3;
                                        }
                                    }

                                    if (TypeID == 8)
                                    {
                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "normalized income before taxes")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText.Trim('(').Trim(')'), out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText.Trim('(').Trim(')'), out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText.Trim('(').Trim(')'), out param3);

                                            temp_year_one.ni_normalized_income_before_taxes = param1;
                                            temp_year_two.ni_normalized_income_before_taxes = param2;
                                            temp_year_three.ni_normalized_income_before_taxes = param3;
                                        }

                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "effect of special items on income taxes")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText.Trim('(').Trim(')'), out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText.Trim('(').Trim(')'), out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText.Trim('(').Trim(')'), out param3);

                                            temp_year_one.ni_effect_of_special_items_on_income_taxes = param1;
                                            temp_year_two.ni_effect_of_special_items_on_income_taxes = param2;
                                            temp_year_three.ni_effect_of_special_items_on_income_taxes = param3;
                                        }

                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "income tax excluding impact of special items")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText.Trim('(').Trim(')'), out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText.Trim('(').Trim(')'), out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText.Trim('(').Trim(')'), out param3);

                                            temp_year_one.ni_income_tax_excluding_impact_of_special_items = param1;
                                            temp_year_two.ni_income_tax_excluding_impact_of_special_items = param2;
                                            temp_year_three.ni_income_tax_excluding_impact_of_special_items = param3;
                                        }

                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "normalized income after tax")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText.Trim('(').Trim(')'), out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText.Trim('(').Trim(')'), out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText.Trim('(').Trim(')'), out param3);

                                            temp_year_one.ni_normalized_income_after_tax = param1;
                                            temp_year_two.ni_normalized_income_after_tax = param2;
                                            temp_year_three.ni_normalized_income_after_tax = param3;
                                        }

                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "normalized income avail. to common")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText.Trim('(').Trim(')'), out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText.Trim('(').Trim(')'), out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText.Trim('(').Trim(')'), out param3);

                                            temp_year_one.ni_normalized_income_avail_to_common = param1;
                                            temp_year_two.ni_normalized_income_avail_to_common = param2;
                                            temp_year_three.ni_normalized_income_avail_to_common = param3;
                                        }

                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "basic normalized eps")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText.Trim('(').Trim(')'), out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText.Trim('(').Trim(')'), out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText.Trim('(').Trim(')'), out param3);

                                            temp_year_one.ni_basic_normalized_eps = param1;
                                            temp_year_two.ni_basic_normalized_eps = param2;
                                            temp_year_three.ni_basic_normalized_eps = param3;
                                        }

                                        if (tr.ChildNodes[0].InnerText.Replace("&nbsp;", " ").ToLower().Trim() == "diluted normalized eps")
                                        {
                                            decimal param1 = 0;
                                            decimal param2 = 0;
                                            decimal param3 = 0;

                                            decimal.TryParse(tr.ChildNodes[1].InnerText.Trim('(').Trim(')'), out param1);
                                            decimal.TryParse(tr.ChildNodes[2].InnerText.Trim('(').Trim(')'), out param2);
                                            decimal.TryParse(tr.ChildNodes[3].InnerText.Trim('(').Trim(')'), out param3);

                                            temp_year_one.ni_diluted_normalized_eps = param1;
                                            temp_year_two.ni_diluted_normalized_eps = param2;
                                            temp_year_three.ni_diluted_normalized_eps = param3;
                                        }
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
                                if (tr.ChildNodes[0].InnerText.ToUpper() == "EPS RECONCILIATION")
                                {
                                    TypeID = 4;
                                }

                                if (tr.ChildNodes[0].InnerText.ToUpper() == "COMMON STOCK DIVIDENDS")
                                {
                                    TypeID = 5;
                                }
                                if (tr.ChildNodes[0].InnerText.ToUpper() == "PRO FORMA INCOME")
                                {
                                    TypeID = 6;
                                }
                                if (tr.ChildNodes[0].InnerText.ToUpper() == "SUPPLEMENTAL INCOME")
                                {
                                    TypeID = 7;
                                }
                                if (tr.ChildNodes[0].InnerText.ToUpper() == "NORMALIZED INCOME")
                                {
                                    TypeID = 8;
                                }
                            }



                        }

                        
                      
                        lst.Add(temp_year_one);
                        lst.Add(temp_year_two);
                        lst.Add(temp_year_three);
                    }
                }
            }
            else
            {
                string warningmsg = Helper.GetWarningMSG(stock_id, "ft_Financials", URL);
                Helper.AddtoLog(warningmsg, job_id, true, Helper.LogStatus.warning);
            }
            return lst;
        }

    }
}
