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
    
    public partial class reuters_Financials_ValuationRatios
    {
        public long Reuters_FinancialsValuationRatio_Id { get; set; }
        public int Stock_Id { get; set; }
        public int job_run_Id { get; set; }
        public string EffectiveDate { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Industry { get; set; }
        public string Sector { get; set; }
        public byte[] CreatedOn { get; set; }
    
        public virtual ws_Jobs ws_Jobs { get; set; }
        public virtual ws_Stocks ws_Stocks { get; set; }
    }
}
