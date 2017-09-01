using HotelRentalBookingClient2.DataFormsModel;
using HotelRentalBookingClient2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using PagedList;
namespace HotelRentalBookingClient2.ViewModels
{
    public class RoomClient
    {
        public IEnumerable<Room> findRoomAvailable(long IdBooking,int page,int pageSize)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(tools.Constants.Base_URL);
                client.DefaultRequestHeaders.Add("API_KEY", "123456789");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                HttpResponseMessage response = client.GetAsync("Rooms/RoomTypeAvailable?IdBooking=" + IdBooking).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<Room>>().Result.ToPagedList(page, pageSize);
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}