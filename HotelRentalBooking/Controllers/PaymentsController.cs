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
    public class PaymentsController : ApiController
    {
        public class EmployeesController : ApiController
        {
            private RoomRentalManagementDBEntities db = new RoomRentalManagementDBEntities();
            [ResponseType(typeof(Payment))]
            [HttpGet]
            [WebMethod(EnableSession = true)]
            public IHttpActionResult Makebill(long OccupacyNumber)
            {
                Occupacy _OC = db.Occupacies.FirstOrDefault(x => x.OccupacyNumber == OccupacyNumber);
                if (_OC == null)
                {
                    return NotFound();
                }
                Payment payment = new Payment();
                DateTime datecheckin = _OC.DateOccupacied.GetValueOrDefault(DateTime.Now);

                var totaltime = DateTime.Now - datecheckin;
                int totalday = (int)totaltime.TotalDays + 1;

                payment.PaymentDate = DateTime.Now;
                payment.TaxAmount = 10;
                payment.TotalDays = totalday;
                payment.AmountCharged = _OC.RateApplied * totalday;
                payment.TaxAmount = payment.AmountCharged * payment.TaxAmount / 100;
                payment.PaymentTotal = payment.AmountCharged + payment.TaxAmount;
               
            return Ok(payment);
            }
        }
    }
}
