//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GardenCommunity.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Indications
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public double LastIndication { get; set; }
        public double CurrentIndication { get; set; }
        public double LoosesPercent { get; set; }
    
        public virtual Payments Payments { get; set; }
    }
}
