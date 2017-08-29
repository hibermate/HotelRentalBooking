namespace HotelRentalBookingClient2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Room")]
    public partial class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long IdRoom { get; set; }

        [StringLength(500)]
        public string RoomType { get; set; }

        [StringLength(500)]
        public string BedType { get; set; }

        public long? Rate { get; set; }

        [StringLength(500)]
        public string Status { get; set; }
    }
}
