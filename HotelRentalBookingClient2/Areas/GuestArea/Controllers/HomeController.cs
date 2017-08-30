using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelRentalBookingClient2.Areas.GuestArea.Controllers
{
    public class HomeController : Controller
    {
        // GET: GuestArea/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}