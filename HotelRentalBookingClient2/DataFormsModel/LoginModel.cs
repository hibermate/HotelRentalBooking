using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelRentalBookingClient2.DataFormsModel
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Tên đăng nhập không được bỏ trống!")]
        [StringLength(50, ErrorMessage = "Tên đăng nhập tối thiếu là 3 ký tự và tối đa là 50 ký tự.", MinimumLength = 3)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được bỏ trống!")]
        [DataType(DataType.Password)]
        [StringLength(500, ErrorMessage = "Mật khẩu tối thiếu là 3 ký tự và tối đa là 500 ký tự.", MinimumLength = 3)]
        public string Password { get; set; }
    }
}