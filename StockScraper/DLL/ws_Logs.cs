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
    
    public partial class ws_Logs
    {
        public int Log_Id { get; set; }
        public int job_run_Id { get; set; }
        public string log_msg { get; set; }
        public string log_status { get; set; }
        public byte[] CreatedOn { get; set; }
    
        public virtual ws_Jobs ws_Jobs { get; set; }
    }
}