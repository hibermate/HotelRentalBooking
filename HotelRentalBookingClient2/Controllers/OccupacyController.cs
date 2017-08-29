using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelRentalBookingClient2.Controllers
{
    public class OccupacyController : BaseReceptionistController
    {
        // GET: Occupacy
        public ActionResult Index()
        {
            return View();
        }
    }
}