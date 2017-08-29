﻿using HotelRentalBookingClient2.DataFormsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelRentalBookingClient2.ViewModels;
using HotelRentalBookingClient2.Models;
namespace HotelRentalBookingClient2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
           
            return View("Index");
       
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                //model.Password = tools.Encrypt.MD5Hash(model.Password);
                var result = new UsersClient().findUser(model);

                if (result != null)
                {
                    User _user = new HotelRentalBookingClient2.Models.User();
                    _user.Username = result.Username;
                    _user.Name = result.Name;
                    _user.Password = result.Password;
                    _user.IdUser = result.IdUser;
                    _user.RoleID = result.RoleID;
                    // Session.Add(Areas.Client.Common.CommonConstants.ADMIN_SESSION, _user);

                    return RedirectToAction("Index", "Song");
                }
                else
                {
                    ModelState.AddModelError("", "Sai tên tài khoản hoặc mật khẩu!");
                    return View("Index");
                }
            }
            return View("Index");
        }

    }
}