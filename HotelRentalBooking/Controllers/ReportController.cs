using HotelRentalBooking.Models;
using HotelRentalBooking.SysModel;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace HotelRentalBooking.Controllers
{
    public class ReportController : ApiController
    {
        private RoomRentalManagementDBEntities db = new RoomRentalManagementDBEntities();

        [ResponseType(typeof(ReportFileModel))]
        [HttpPut]
        public IHttpActionResult FileReport(string id)
        {
         
         
        LocalReport lr = new LocalReport();
            string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Reporting"),"Report236.rdlc");

            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return NotFound();
            }
            List<User> users = new List<User>();
            users = db.Users.ToList();
         
            ReportDataSource rd = new ReportDataSource("MyDataset", users);
            lr.DataSources.Add(rd);
            string reportType = id;
            string mimeType=string.Empty;
            string encoding=string.Empty;
            string fileNameExtension=string.Empty;



            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + id + "</OutputFormat>" +
            "  <PageWidth>8.5in</PageWidth>" +
            "  <PageHeight>11in</PageHeight>" +
            "  <MarginTop>0.5in</MarginTop>" +
            "  <MarginLeft>1in</MarginLeft>" +
            "  <MarginRight>1in</MarginRight>" +
            "  <MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            ReportFileModel rfm = new ReportFileModel();
            try
            {
                renderedBytes = lr.Render(
                    reportType,
                    deviceInfo,
                    out mimeType,
                    out encoding,
                    out fileNameExtension,
                    out streams,
                    out warnings);
              
                rfm.renderedBytes = renderedBytes;
                rfm.mimeType = mimeType;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        
          
            return Ok(rfm);
        }
    }
}
