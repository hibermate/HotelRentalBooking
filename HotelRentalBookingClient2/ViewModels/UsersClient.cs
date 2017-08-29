using HotelRentalBookingClient2.DataFormsModel;
using HotelRentalBookingClient2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace HotelRentalBookingClient2.ViewModels
{
    public class UsersClient
    {
        public User findUser(LoginModel model)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:59692/api/");
                client.DefaultRequestHeaders.Add("API_KEY", "123456789");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                HttpResponseMessage response = client.GetAsync("Users/UserLogin?username=" + model.Username + "&password=" + model.Password).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<User>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }

       
    }
}