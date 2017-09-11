
using HotelRentalBooking.SysModel;
using iTextSharp.text;
using iTextSharp.text.pdf;

using PdfSharp;
using System;
using System.Collections.Generic;
using System.Data;
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
        [HttpGet]
        public HttpResponseMessage GetCSV()
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine("\"User'ID number\",\"FullName\",\"Username\",\"Role\"");
         
            List<User> users = db.Users.ToList();
            foreach(var item in users)
            {
                string rolestr="";
                if (item.RoleID == 1) rolestr = Tools.CommonConstant.RECEPTIONIST_ROLE;
                if (item.RoleID == 2) rolestr = Tools.CommonConstant.CASHIER_ROLE;
                writer.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\"",
                    item.IdUser,item.Name,item.Username,rolestr));
            }
            writer.Flush();
            stream.Position = 0;


            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "Export.csv" };
            return result;
        }
        [HttpGet]
        public HttpResponseMessage GetXLS(string od)
        {

            GridView grid = new GridView();         
            var dt = UserDataTable();
            grid.DataSource = dt;
            grid.DataBind();
            grid.GridLines = GridLines.Both;      
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            grid.HeaderStyle.Font.Bold = true;
            grid.RenderControl(htmltextwrtter);
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new StringContent(strwritter.ToString());
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "Report.xls" };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/excel");
       
      
            return result;


           
        }
        [HttpGet]
        public HttpResponseMessage GetWord(int id)
        {

            GridView grid = new GridView();

            var dt = UserDataTable();
            grid.DataSource = dt;
            grid.DataBind();
            grid.GridLines = GridLines.Both;
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            htmltextwrtter.WriteLine("<center><b>User List TMA Hotel </b></center> \n");
            grid.HeaderStyle.Font.Bold = true;
            grid.Width = Unit.Percentage(100);
            grid.RenderControl(htmltextwrtter);
   
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new StringContent(strwritter.ToString());
          
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "Report.doc" };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/ms-word");
            return result;



        }
        public System.Data.DataTable UserDataTable()
        {
            List<User> users = db.Users.ToList();
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("User's Id", typeof(int));
            table.Columns.Add("Full Name", typeof(string));
            table.Columns.Add("Username", typeof(string));
            table.Columns.Add("Role", typeof(string));
            foreach (var item in users)
            {
                string rolestr = "";
                if (item.RoleID == 1) rolestr = Tools.CommonConstant.RECEPTIONIST_ROLE;
                if (item.RoleID == 2) rolestr = Tools.CommonConstant.CASHIER_ROLE;
                table.Rows.Add(item.IdUser,item.Name,item.Username,rolestr);
            }
            return table;
        }
    }
}
