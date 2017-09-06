
using HotelRentalBooking.SysModel;
using iTextSharp.text;
using iTextSharp.text.pdf;

using PdfSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelRentalBooking.Controllers
{
    public class TestController : ApiController
    {
        private RoomRentalManagementDBEntities db = new RoomRentalManagementDBEntities();
        public HttpResponseMessage ExportToWord()
        {
            // get the data from database
            var data = db.Users.ToList();
            // instantiate the GridView control from System.Web.UI.WebControls namespace
            // set the data source
            GridView gridview = new GridView();
            gridview.DataSource = data;
            gridview.DataBind();
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            // Clear all the content from the current response
            response.ClearContent();
            response.Buffer = true;
            // set the header
            response.Headers("content-disposition", "attachment;
filename = itfunda.doc");
            Response.ContentType = "application/ms-word";
            Response.Charset = "";


            string contentType = "application/ms-word";
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(System.IO.File.OpenRead(filePath));
            response.Content.Headers.ContentType = MediaTypeHeaderValue.Parse(contentType);
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = fileName
            };

            // create HtmlTextWriter object with StringWriter
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    // render the GridView to the HtmlTextWriter
                    gridview.RenderControl(htw);
                    // Output the GridView content saved into StringWriter
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
            return View();
        }
    }
}
