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
    
    public partial class Log
    {
        public int Log_Id { get; set; }
        public int Job_Id { get; set; }
        public string LogMsg { get; set; }
        public byte[] Time_ST { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
    
        public virtual Job Job { get; set; }
    }
}
