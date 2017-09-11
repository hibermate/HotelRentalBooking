using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelRentalBooking.Models
{
    public class ReportFileModel
    {
        public byte[] renderedBytes { get; set; }
        public string mimeType { get; set; }
    }
}