using HotelRentalBookingClient2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HotelRentalBookingClient2.tools;
namespace HotelRentalBookingClient2.Controllers
{
    public class BaseCashierController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (User)Session[Constants.CASHIER_SESSION];
       
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Home", action = "Index" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}