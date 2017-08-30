using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace HotelRentalBookingClient2.Areas.GuestArea.ViewModels
{
    public class SignUpModel
    {
        [Required(ErrorMessage = "Bạn chưa nhập Tên đăng nhập!")]
        [StringLength(50, ErrorMessage = "Tên đăng nhập tối thiếu là 5 ký tự và tối đa là 50 ký tự.", MinimumLength = 5)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Mật khẩu!")]
        [DataType(DataType.Password)]
        [MembershipPassword(
        MinRequiredNonAlphanumericCharacters = 1,
        MinNonAlphanumericCharactersError = "Mật khẩu phải chứa những ký tự đặc biệt. VD: !, @, #,...",
        MinPasswordLengthError = "Mật khẩu tối thiếu là 7 ký tự"),
        StringLength(50, ErrorMessage = "Mật khẩu tối đa là 50 ký tự.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Mật khẩu nhập lại!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Mật khẩu nhập lại không khớp với mật khẩu!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập Họ và Tên!")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Bạn chưa nhập Số điện thoại")]
        public string Phone { get; set; }
    }
}