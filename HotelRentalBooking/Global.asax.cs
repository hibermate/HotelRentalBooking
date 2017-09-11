using HotelRentalBooking.Credential;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace HotelRentalBooking
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
          //  GlobalConfiguration.Configuration.MessageHandlers.Add(new ApiKeyHandle());
            GlobalConfiguration.Configure(WebApiConfig.Register);

         
        }
    }
}
