﻿using HotelRentalBookingClient2.DataFormsModel;
using HotelRentalBookingClient2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using PagedList;
using System.Net;
namespace HotelRentalBookingClient2.ViewModels
{
    public class OccupacyClient
    {
        public IEnumerable<RoomBooking> GetBookingRequest(int page, int pageSize)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(tools.Constants.Base_URL);
                client.DefaultRequestHeaders.Add("API_KEY", "12345678");
                //client.DefaultRequestHeaders.Add("username", "admin");
                //client.DefaultRequestHeaders.Add("pass", "21232f297a57a5a743894a0e4a801fc3");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                HttpResponseMessage response = client.GetAsync("RoomBooking/GetNotApprovedBooking").Result;
                
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<RoomBooking>>().Result.ToPagedList(page, pageSize);
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public IEnumerable<Occupacy> GetAllOccupacies(int page, int pageSize)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(tools.Constants.Base_URL);
                client.DefaultRequestHeaders.Add("API_KEY", "12345678");
                //client.DefaultRequestHeaders.Add("username", "admin");
                //client.DefaultRequestHeaders.Add("pass", "21232f297a57a5a743894a0e4a801fc3");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                HttpResponseMessage response = client.GetAsync("Occupacies/GetAllOccupacies").Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<IEnumerable<Occupacy>>().Result.ToPagedList(page, pageSize);
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Occupacy addOccupy(long IdBooking,long IdRoom)
        {
           

            try
            {
                BookingRequestModel booking = new BookingRequestModel();
                booking.IdBooking = IdBooking;
                booking.IdRoom = IdRoom;

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(tools.Constants.Base_URL);
                client.DefaultRequestHeaders.Add("API_KEY", "12354678");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                HttpResponseMessage response = client.PutAsJsonAsync("Occupacies/PutOccupacy/",booking).Result;
                if(response.IsSuccessStatusCode)

                    return response.Content.ReadAsAsync<Occupacy>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}