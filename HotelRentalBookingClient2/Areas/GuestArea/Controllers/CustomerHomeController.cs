using HotelRentalBookingClient2.Areas.GuestArea.Models;
using HotelRentalBookingClient2.Areas.GuestArea.ViewModels;
using HotelRentalBookingClient2.Models;
using HotelRentalBookingClient2.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelRentalBookingClient2.Areas.GuestArea.Controllers
{
    public class CustomerHomeController : Controller
    {
        // GET: GuestArea/Home
        public ActionResult Index()
        {
            var session = (Customer)Session[tools.Constants.CUSTOMER_SESSION];
           
            if (session == null)
            {
                return RedirectToAction("Index", "UserLogin");
            }
            return View();
        }
        [HttpGet]
        public ActionResult RoomBooking()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RoomBooking(CustomerRoomBookingModel model)
        {
            if (ModelState.IsValid)
            {
                var _customer= (Customer)Session[Constants.CUSTOMER_SESSION];
                model.IdCustomer = _customer.IdCustomer;
                model.IsApproved = false;
                RoomBooking result = new BookingRoomClient().addBooking(model);
                if (result!=null)
                {
                    
                    ViewBag.RoomBooking = result.IdBooking;
                    return RedirectToAction("BookingResult", "CustomerHome",new {
                        IdBooking = result.IdBooking,
                        DateCheckin = result.DateCheckin,
                        RoomType = result.RoomType,
                        IsApproved=result.IsApproved
                    });

                }
                else
                {
                    ModelState.AddModelError("", "Không đặt phòng được!");
                    return View("RoomBooking");
                }
            }
            return View();
        }
        public ActionResult BookingResult(int IdBooking,DateTime DateCheckin,string RoomType,bool IsApproved)
        {
            ViewBag.BookingID = IdBooking;
            ViewBag.DateCheckin = DateCheckin.ToString("MM/dd/yyyy");
            ViewBag.RoomType = RoomType;
            ViewBag.Status = "Wating for Approved";
            return View();
        }
    }
}