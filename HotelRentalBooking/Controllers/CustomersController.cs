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
    public class CustomersController : ApiController
    {
        private RoomRentalManagementDBEntities db = new RoomRentalManagementDBEntities();

        [ResponseType(typeof(Customer))]
        [HttpGet]
        [WebMethod(EnableSession = true)]
        public IHttpActionResult UserLogin(string username, string password)
        {
            Customer result = db.Customers.FirstOrDefault(x => x.Username.Equals(username) && x.Password.Equals(password));
            if (result == null)
            {
                return NotFound();
            }
          //  Customer _customer = new Customer();

            return Ok(result);
        }

        [HttpPost]
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Customers.Add(customer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customer.IdCustomer }, customer);
        }
        [HttpGet]
        public IHttpActionResult CheckCustumerName(string username)
        {
            Customer customer = db.Customers.FirstOrDefault(x => x.Username.Equals(username));
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
    }
}
