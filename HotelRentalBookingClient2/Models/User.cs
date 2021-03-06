namespace HotelRentalBookingClient2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Key]
        public long IdUser { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(500)]
        public string Password { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        public int? RoleID { get; set; }
    }
}
