using HotelRentalBookingClient2.Models;
using HotelRentalBookingClient2.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HotelRentalBookingClient2.Controllers
{
    public class HomeController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //var session = (User)Session[Constants.CASHIER_SESSION];
            //session = (User)Session[Constants.RECEPTIONIST_SESSION];
            //if (session == null)
            //{
            //    filterContext.Result = new RedirectToRouteResult(
            //        new RouteValueDictionary(new { controller = "Login", action = "Index" }));
            //}
            //base.OnActionExecuting(filterContext);
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}