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
    
    public partial class Reuters_Financials_SalesEstimates
    {
        public int Reuters_FinancialsSalesEstimates_Id { get; set; }
        public int Stock_Id { get; set; }
        public int Job_Id { get; set; }
        public string Effective_Date { get; set; }
        public string Title { get; set; }
        public string Estimates { get; set; }
        public string Mean { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string One_Year_Ago { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public byte[] Time_ST { get; set; }
        public short SaleType { get; set; }
    
        public virtual Job Job { get; set; }
        public virtual Stock Stock { get; set; }
    }
}
