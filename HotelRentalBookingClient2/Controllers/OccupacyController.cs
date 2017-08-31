using HotelRentalBookingClient2.ViewModels;
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
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            OccupacyClient SC = new OccupacyClient();
            var model = SC.GetBookingRequest(page, pageSize);
           
          //  ViewBag.listIDSongToIDSinger = new OccupacyClient().ListAllSingerOfSong();
            return View(model);
        }
        public ActionResult AddOccupacyPage()
        {
            return View(); 
        }
    }
}