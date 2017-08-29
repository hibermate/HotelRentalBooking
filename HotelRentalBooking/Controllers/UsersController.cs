using HotelRentalBooking.Credential;
using HotelRentalBooking.SysModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Services;

namespace HotelRentalBooking.Controllers
{
    public class UsersController : ApiController
    {
        private RoomRentalManagementDBEntities db = new RoomRentalManagementDBEntities();

        [HasAuthorized]
            public IQueryable<User> GetAllUsers()
        {

            return db.Users;
        }

        [ResponseType(typeof(User))]
        [HttpGet]
        [WebMethod(EnableSession = true)]
        public IHttpActionResult UserLogin(string username, string password)
        {
            User result = db.Users.FirstOrDefault(x => x.Username.Equals(username) && x.Password.Equals(password));
            if (result == null)
            {
                return NotFound();
            }
            User _user = new User();

            return Ok(result);
        }


    }
}
