using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelRentalBookingClient2.Controllers
{
    public class OccupacyController : Controller
    {
        // GET: Occupacy
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddOccupacyPage()
        {
            return View(); 
        }
    }
}