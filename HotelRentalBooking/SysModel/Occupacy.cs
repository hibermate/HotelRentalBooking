//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelRentalBooking.SysModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Occupacy
    {
        public long OccupacyNumber { get; set; }
        public Nullable<long> EmloyeeNumber { get; set; }
        public Nullable<System.DateTime> DateOccupacied { get; set; }
        public Nullable<long> IdCustomer { get; set; }
        public Nullable<long> IdRoom { get; set; }
        public Nullable<long> RateApplied { get; set; }
        public Nullable<bool> IsPaid { get; set; }
    }
}
