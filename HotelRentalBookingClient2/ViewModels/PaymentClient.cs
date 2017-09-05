using HotelRentalBookingClient2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;

namespace HotelRentalBookingClient2.ViewModels
{
    public class PaymentClient
    {
        public Payment MakeBill(long OccupacyNumber)
        {


            try
            {             
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(tools.Constants.Base_URL);
                client.DefaultRequestHeaders.Add("API_KEY", "12354678");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                HttpResponseMessage response = client.GetAsync("Payments/MakeBill?OccupacyNumber=" + OccupacyNumber).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<Payment>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
       
        public Payment CommitBill(long OccupacyNumber)
        {


            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(tools.Constants.Base_URL);
                client.DefaultRequestHeaders.Add("API_KEY", "12354678");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                HttpResponseMessage response = client.PutAsJsonAsync("Payments/CommitBill?Occupacynumber="+OccupacyNumber,OccupacyNumber).Result;


                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<Payment>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}