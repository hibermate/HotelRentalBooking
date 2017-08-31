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
    public class RoomBookingController : ApiController
    {
        private RoomRentalManagementDBEntities db = new RoomRentalManagementDBEntities();

        [HttpPost]
        [ResponseType(typeof(RoomBooking))]
        public IHttpActionResult PostBooking(RoomBooking _booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RoomBookings.Add(_booking);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = _booking.IdBooking }, _booking);
        }
        [HttpGet]
        public IQueryable<RoomBooking> GetNotApprovedBooking()
        {
         
            return db.RoomBookings.Where(m => m.IsApproved == false);
        }
    }
}
