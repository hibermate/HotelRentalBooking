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
    public class GuestUserClient
    {
        public Customer findUser(LoginModel model)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(HotelRentalBookingClient2.tools.Constants.Base_URL);
                client.DefaultRequestHeaders.Add("API_KEY", "123456789");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                HttpResponseMessage response = client.GetAsync("Customers/CustomerLogin?username=" + model.Username + "&password=" + model.Password).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<Customer>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }

        public bool findUsername(string username)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(HotelRentalBookingClient2.tools.Constants.Base_URL);
                client.DefaultRequestHeaders.Add("API_KEY", "123456789");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                HttpResponseMessage response = client.GetAsync("Customers/CheckCustomerName?username=" + username).Result;

                if (response.IsSuccessStatusCode)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool addCustomer(SignUpModel model)
        {
            Customer _user = new Customer();
            _user.Name = model.Name;
            _user.Password = model.Password;
            _user.Username = model.Username;
            _user.Phone = model.Phone;
       
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(tools.Constants.Base_URL);
                client.DefaultRequestHeaders.Add("API_KEY", "12354678");               
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                HttpResponseMessage response = client.PostAsJsonAsync("Customers/PostCustomer", _user).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}