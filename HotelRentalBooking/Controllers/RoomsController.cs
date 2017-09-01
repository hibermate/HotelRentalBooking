using System;
using System.Collections.Generic;
using System.Linq;
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
    public class RoomsController : ApiController
    {
        private RoomRentalManagementDBEntities db = new RoomRentalManagementDBEntities();
        [HttpGet]
        public IQueryable<Room> RoomTypeAvailable(int IdBooking)
        {

            var x = db.RoomBookings.FirstOrDefault(m => m.IdBooking == IdBooking);
            string RoomType = x.RoomType;
            return db.Rooms.Where(m => m.RoomType == RoomType && m.Status=="OK");
        }
    }
}
