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
                model.Password = tools.Encrypt.MD5Hash(model.Password);
                var result = new GuestUserClient().findUser(model);

                if (result != null)
                {
                    Customer _customer = new HotelRentalBookingClient2.Models.Customer();
                    _customer.Username = result.Username;
                    _customer.Name = result.Name;
                    _customer.Password = result.Password;
                    _customer.Phone = result.Phone;
                    _customer.IdCustomer = result.IdCustomer;
                        Session.Add(tools.Constants.CUSTOMER_SESSION, _customer);
                    Session.Add("name", _customer.Name);
                    return RedirectToAction("Index", "CustomerHome");
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
                    model.Password = tools.Encrypt.MD5Hash(model.Password);
                 //  var _curentSession = (User)Session[CommonConstants.ADMIN_SESSION];
                    var result1 = new GuestUserClient().addCustomer(model);
                 
                    return RedirectToAction("Index", "CustomerHome");
                  
                   
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            
            return RedirectToAction("Index","UserLogin");
        }
    }
}