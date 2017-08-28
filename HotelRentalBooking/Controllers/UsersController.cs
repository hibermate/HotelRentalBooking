using HotelRentalBooking.Credential;
using HotelRentalBooking.SysModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
    }
}
