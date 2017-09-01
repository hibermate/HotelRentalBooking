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
using HotelRentalBookingClient2.DataFormsModel;

namespace HotelRentalBooking.Controllers
{
    [HasAuthorized]
    public class OccupaciesController : ApiController
    {
        private RoomRentalManagementDBEntities db = new RoomRentalManagementDBEntities();

     
        public IHttpActionResult PutOccupacy(BookingRequestModel booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Occupacy _OC = new Occupacy();
            RoomBooking _RB = db.RoomBookings.FirstOrDefault(m => m.IdBooking == booking.IdBooking);
            Room _R = db.Rooms.FirstOrDefault(m => m.IdRoom== booking.IdRoom);

            _OC.IdCustomer = _RB.IdCustomer;
            _OC.IdRoom = _R.IdRoom;
            _OC.DateOccupacied = _RB.DateCheckin;
            _OC.RateApplied = _R.Rate;
            _OC.IsPaid = false;
        
            db.Occupacies.Add(_OC);
            db.RoomBookings.FirstOrDefault(m => m.IdBooking == booking.IdBooking).IsApproved = true;

            DateTime checkinDate = _RB.DateCheckin.GetValueOrDefault(DateTime.Now);
            db.Rooms.FirstOrDefault(m => m.IdRoom == booking.IdRoom).Status = checkinDate.ToString("MM/dd/yyyy");

            db.SaveChanges();

            return Ok(_OC);
        }
        [HttpGet]
        public IQueryable<Occupacy> GetAllOccupacies()
        {

            return db.Occupacies.Where(m => m.IsPaid == false);
        }
    }
}
