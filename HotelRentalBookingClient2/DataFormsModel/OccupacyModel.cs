using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelRentalBookingClient2.DataFormsModel
{
    public class OccupacyModel
    {
        public long OccupacyNumber { get; set; }
        public long EmloyeeNumber { get; set; }
        public DateTime DateOccupacied { get; set; }
        public long IdCustomer { get; set; }
        public long IdRoom { get; set; }
        public long RateApplied { get; set; }
        public bool IsPaid { get; set; } = false;
    }
}