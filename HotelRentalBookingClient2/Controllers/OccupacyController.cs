using HotelRentalBookingClient2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using HotelRentalBookingClient2.DataFormsModel;
using HotelRentalBookingClient2.Models;

namespace HotelRentalBookingClient2.Controllers
{
    public class OccupacyController : BaseReceptionistController
    {
        // GET: Occupacy
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            OccupacyClient OC = new OccupacyClient();
            var model = OC.GetBookingRequest(page, pageSize);
           
         
            return View(model);
        }

        public ActionResult ApproveRequest(long IdBooking, int page = 1, int pageSize = 10)
        {

            RoomClient RC = new RoomClient();
            var model = RC.findRoomAvailable(IdBooking,page, pageSize);

            ViewBag.IdBooking = IdBooking;

            return View(model);
        }
        public ActionResult ChoseRoom(long IdRoom, long IdBooking)
        {
            
            

            OccupacyClient OC = new OccupacyClient();
          var result=  OC.addOccupy(IdBooking, IdRoom);
            if (result!=null)
            {
                Occupacy _OC = result;
                ViewBag.Date = _OC.DateOccupacied.GetValueOrDefault(DateTime.Now).ToString("MM/dd/yyyy");
                ViewBag.IdOccupacy = _OC.OccupacyNumber;
                ViewBag.IdRoom = _OC.IdRoom;
                ViewBag.IdCustomer = _OC.IdCustomer;
                ViewBag.RateApplied = _OC.RateApplied;
             
            }
           

            return View();
        }
    }
}