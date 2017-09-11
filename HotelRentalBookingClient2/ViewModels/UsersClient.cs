using HotelRentalBookingClient2.DataFormsModel;
using HotelRentalBookingClient2.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
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
                client.BaseAddress = new Uri(tools.Constants.Base_URL);
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
        public List<User> GetAllUsers()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(tools.Constants.Base_URL);
                client.DefaultRequestHeaders.Add("API_KEY", "123456789");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

                HttpResponseMessage response = client.GetAsync("Users/GetAllUsers").Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<List<User>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public PdfDocument getUserReport()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(tools.Constants.Base_URL);
                client.DefaultRequestHeaders.Add("API_KEY", "123456789");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                HttpResponseMessage response = client.GetAsync("FileExport/DownloadPdf").Result;
                var stream= response.Content.ReadAsStreamAsync();
                Document document = new Document(iTextSharp.text.PageSize.A4, 25, 25, 30, 30);
                PdfWriter wri = PdfWriter.GetInstance(document, stream.Result);
               var writer=new PdfCopy(document, stream.Result);

            
              
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<PdfDocument>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
        public ReportFileModel getReportFile(string id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(tools.Constants.Base_URL);
                client.DefaultRequestHeaders.Add("API_KEY", "123456789");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
               // HttpResponseMessage response = client.GetAsync("Report/FileReport?id="+id).Result;
                HttpResponseMessage response = client.PutAsJsonAsync("Report/FileReport?id=" + id, id).Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<ReportFileModel>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }

    }
}