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
    
    public partial class Reuters_Financials_GrowthRates
    {
        public int Reuters_FinancialsGrowthRate_Id { get; set; }
        public int Stock_Id { get; set; }
        public string EffectiveDate { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Sector { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public byte[] Time_ST { get; set; }
    
        public virtual Stock Stock { get; set; }
    }
}
