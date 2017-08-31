namespace HotelRentalBookingClient2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoomBooking")]
    public partial class RoomBooking
    {
        [Key]
        public long IdBooking { get; set; }

        public long? IdCustomer { get; set; }

        public DateTime? DateCheckin { get; set; }

        [StringLength(500)]
        public string RoomType { get; set; }

        public bool? IsApproved { get; set; }
    }
}
