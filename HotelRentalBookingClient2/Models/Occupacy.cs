namespace HotelRentalBookingClient2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Occupacy")]
    public partial class Occupacy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long OccupacyNumber { get; set; }

        public long? EmloyeeNumber { get; set; }

        public DateTime? DateOccupacied { get; set; }

        public long? IdCustomer { get; set; }

        public long? IdRoom { get; set; }

        public long? RateApplied { get; set; }
    }
}
