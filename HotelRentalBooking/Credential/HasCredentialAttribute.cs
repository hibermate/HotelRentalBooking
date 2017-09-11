using HotelRentalBooking.SysModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace HotelRentalBooking.Credential
{
    public class HasCredentialAttribute : AuthorizeAttribute
    {
        public string RoleID { set; get; }
        private RoomRentalManagementDBEntities db = new RoomRentalManagementDBEntities();
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {

            if (AuthorizeRequest(actionContext))
            {
                //check ok
                return;
            }
            base.OnAuthorization(actionContext);
        }

        private bool AuthorizeRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (RoleID.Equals(GetGroup(actionContext)))
                return true;
            return false;
        }


        private int? GetGroup(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            //IEnumerable<String> uname;
            //IEnumerable<String> passw;
            var username = HttpContext.Current.Request.Headers["username"];
            var pass = HttpContext.Current.Request.Headers["pass"];

            User _user = new User();

            if (username != null && pass != null)
            {
                _user = db.Users.FirstOrDefault(x => x.Username.Equals(username) && x.Password.Equals(pass));
            }

            return _user.RoleID;
            //var credentials = (List<string>)HttpContext.Current.Session[Common.CommonConstants.SESSION_CREDENTIALS];
            //return credentials;
        }
    }
}