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
    
    public partial class ws_JobScheduler_Monthly
    {
        public int scheduler_monthly_id { get; set; }
        public int schedulder_id { get; set; }
        public int monthly_nominal_day { get; set; }
        public int monthly_nominal_month { get; set; }
        public int monthly_day { get; set; }
        public int monthly_week_of_day { get; set; }
        public int monthly_freq { get; set; }
        public byte[] CreatedOn { get; set; }
    
        public virtual ws_JobScheduler ws_JobScheduler { get; set; }
    }
}
