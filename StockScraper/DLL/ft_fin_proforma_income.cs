//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DLL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ft_fin_proforma_income
    {
        public long proforma_income_id { get; set; }
        public int job_run_id { get; set; }
        public int stock_id { get; set; }
        public string effective_date { get; set; }
        public string Title { get; set; }
        public string First_Year { get; set; }
        public string Second_Year { get; set; }
        public string Third_Year { get; set; }
        public byte[] CreatedOn { get; set; }
    
        public virtual ws_Jobs ws_Jobs { get; set; }
        public virtual ws_Stocks ws_Stocks { get; set; }
    }
}
