using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace HotelRentalBooking.Credential
{
    public class HasAuthorizedAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            return;
            base.OnAuthorization(actionContext);
        }
    }
}