
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
namespace HotelRentalBooking.Controllers
{
    public class FileExportController : ApiController
    {
        private RoomRentalManagementDBEntities db = new RoomRentalManagementDBEntities();
        public HttpResponseMessage DownloadPdf()
        {
            string fileName = "";
            string filePath = "";
            fileName = "users_list.pdf";
            filePath = System.Web.HttpContext.Current.Server.MapPath("/App_Data/" + fileName);
         

            List<User> users = db.Users.ToList();
            int result = CreatePdf(filePath, users);
            if (result == 0)
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            else
                return DownloadPdf(filePath, fileName);

   
        }
        private HttpResponseMessage DownloadPdf(string filePath, string fileName)
        {

            if (fileName != "" && filePath != "")
            {
                string contentType = "application/pdf";
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StreamContent(System.IO.File.OpenRead(filePath));
                response.Content.Headers.ContentType = MediaTypeHeaderValue.Parse(contentType);
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = fileName
                };
                return response;

            }
            else
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return response;
            }

        }
        private int CreatePdf(string filepath, List<User> users)
        {

            // create pdf using itextsharp
            try
            {
                using (System.IO.FileStream fs = new FileStream(filepath, FileMode.Create))
                {

                    Document document = new Document(iTextSharp.text.PageSize.A4, 25, 25, 30, 30);

                    PdfWriter writer = PdfWriter.GetInstance(document, fs);

                    document.AddAuthor("TMA AUTHORIZATION");
                    document.AddCreator("THAI TRUONG CREATOR");
                    document.AddKeywords("Users List");
                    document.AddSubject("Users List");
                    document.AddTitle("Hotel Users List");
                    document.Open();



                    PdfPTable table = new PdfPTable(4);
                    PdfPCell cell = new PdfPCell(new Phrase("The users list of TMA HOTEL", new Font(Font.FontFamily.HELVETICA, 20f, Font.BOLD)));
                    cell.Colspan = 4;
                    cell.PaddingTop = 6f;
                    cell.PaddingBottom = 6f;
                    cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                    table.AddCell(cell);
                    // Colum title
                    cell = new PdfPCell(new Phrase("User'ID number", new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL)));
                    cell.PaddingTop = 6f;
                    cell.PaddingBottom = 6f;
                    table.AddCell(cell);


                    cell = new PdfPCell(new Phrase("Full Name", new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL)));
                    cell.PaddingTop = 6f;
                    cell.PaddingBottom = 6f;
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase("Username", new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL)));
                    cell.PaddingTop = 6f;
                    cell.PaddingBottom = 6f;
                    table.AddCell(cell);
                   
                    cell = new PdfPCell(new Phrase("Role", new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL)));
                    cell.PaddingTop = 6f;
                    cell.PaddingBottom = 6f;
                    table.AddCell(cell);

                    foreach (var g in users.GroupBy(s => s.Name.First()).OrderBy(g => g.Key))
                    {

                        cell = new PdfPCell(new Phrase(g.Key.ToString(), new Font(Font.FontFamily.HELVETICA, 24f, Font.BOLD)));
                        cell.Colspan = 4;
                        cell.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
                        cell.PaddingTop = 6f;
                        cell.PaddingBottom = 6f;
                        table.AddCell(cell);



                        foreach (var item in g.OrderBy(s => s.Name))
                        {
                            cell = new PdfPCell(new Phrase(item.IdUser.ToString(), new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL)));
                            cell.PaddingTop = 6f;
                            cell.PaddingBottom = 6f;
                            table.AddCell(cell);


                            cell = new PdfPCell(new Phrase(item.Name, new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL)));
                            cell.PaddingTop = 6f;
                            cell.PaddingBottom = 6f;
                            table.AddCell(cell);

                            cell = new PdfPCell(new Phrase(item.Username, new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL)));
                            cell.PaddingTop = 6f;
                            cell.PaddingBottom = 6f;
                            table.AddCell(cell);
                            string role;
                            if (item.RoleID == 1) role = Tools.CommonConstant.RECEPTIONIST_ROLE;
                            else role = Tools.CommonConstant.CASHIER_ROLE; 

                            cell = new PdfPCell(new Phrase(role, new Font(Font.FontFamily.TIMES_ROMAN, 12f, Font.NORMAL)));
                            cell.PaddingTop = 6f;
                            cell.PaddingBottom = 6f;
                            table.AddCell(cell);

                        }

                    }

                    document.Add(table);

                    document.Close();
                    writer.Close();
                }

                return 1;
            }
            catch
            {
                return 0;

            }

        }
    }
}
