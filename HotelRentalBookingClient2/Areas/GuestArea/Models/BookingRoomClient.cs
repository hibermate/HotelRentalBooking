using HotelRentalBookingClient2.Areas.GuestArea.ViewModels;
using HotelRentalBookingClient2.DataFormsModel;
using HotelRentalBookingClient2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace HotelRentalBookingClient2.Areas.GuestArea.Models
{
    public class BookingRoomClient
    {
        public RoomBooking addBooking(CustomerRoomBookingModel model)
        {
            RoomBooking booking = new RoomBooking();
            booking.DateCheckin = model.DateCheckin;
            booking.RoomType = model.RoomType;
            booking.IdCustomer = model.IdCustomer;
            booking.IsApproved = model.IsApproved;
            
            //

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(tools.Constants.Base_URL);
                client.DefaultRequestHeaders.Add("API_KEY", "12354678");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                HttpResponseMessage response = client.PostAsJsonAsync("RoomBooking/PostBooking", booking).Result;
          
                return response.Content.ReadAsAsync<RoomBooking>().Result;
            }
            catch
            {
                return null;
            }
        }
    }
}