namespace HotelRentalBookingClient2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long IdReceipt { get; set; }

        public long? EmployeeNumber { get; set; }

        public DateTime? PaymentDate { get; set; }

        public long? TotalDays { get; set; }

        public long? AmountCharged { get; set; }

        public long? TaxAmount { get; set; }

        public long? PaymentTotal { get; set; }
    }
}
