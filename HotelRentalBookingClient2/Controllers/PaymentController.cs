using HotelRentalBookingClient2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelRentalBookingClient2.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            OccupacyClient OC = new OccupacyClient();
            var model = OC.GetAllOccupacies(page, pageSize);


            return View(model);
        }
        public ActionResult MakeBill(long IdOccupacy)
        {
            OccupacyClient OC = new OccupacyClient();
            
            return View();
        }
    }
}