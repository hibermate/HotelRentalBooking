using HotelRentalBookingClient2.Areas.GuestArea.Models;
using HotelRentalBookingClient2.Areas.GuestArea.ViewModels;
using HotelRentalBookingClient2.DataFormsModel;
using HotelRentalBookingClient2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelRentalBookingClient2.Areas.GuestArea.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: GuestArea/UserLogin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                //model.Password = tools.Encrypt.MD5Hash(model.Password);
                var result = new GuestUserClient().findUser(model);

                if (result != null)
                {
                    Customer _customer = new HotelRentalBookingClient2.Models.Customer();
                    _customer.Username = result.Username;
                    _customer.Name = result.Name;
                    _customer.Password = result.Password;
                    _customer.Phone = result.Phone;
                  
                        Session.Add(tools.Constants.CUSTOMER_SESSION, _customer);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Sai tên tài khoản hoặc mật khẩu!");
                    return View("Index");
                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(SignUpModel model)
        {
            if (ModelState.IsValid)
            {
                var result = new GuestUserClient().findUsername(model.Username);
                if (result)
                {
                    ModelState.AddModelError("", "Tên tài khoản đã tồn tại!");
                    return View("SignUp");
                }
                else
                {
                    //thêm tài khoản
                 //  var _curentSession = (User)Session[CommonConstants.ADMIN_SESSION];
                    var result1 = new GuestUserClient().addCustomer(model);
                    if(result1)
                    return RedirectToAction("Index", "Home");
                    else
                        RedirectToAction("SaiAdd", "Home");
                }
            }
            return View();
        }
    }
}