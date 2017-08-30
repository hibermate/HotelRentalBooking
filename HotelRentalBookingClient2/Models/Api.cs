namespace HotelRentalBookingClient2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Api")]
    public partial class Api
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long IdAPI { get; set; }

        [StringLength(250)]
        public string ApiKey { get; set; }

        public bool? Status { get; set; }
    }
}
