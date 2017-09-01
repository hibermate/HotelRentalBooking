using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelRentalBookingClient2.Areas.GuestArea.ViewModels
{
    public class CustomerRoomBookingModel
    {
        public long IdBooking { get; set; }

        public long? IdCustomer { get; set; }
        [Display(Name = "Ngày đặt phòng")]
        [DataType(DataType.Date )]
        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        [Required(ErrorMessage = "Bạn chưa nhập Ngày check in!")]
        public DateTime? DateCheckin { get; set; }


        [Required(ErrorMessage = "Bạn chưa chọn loại phòng !")] 
        [Display(Name ="Loại Phòng")]
        public string RoomType { get; set; }      
        public bool? IsApproved { get; set; }


        
    }
}