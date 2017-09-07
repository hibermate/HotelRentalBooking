using HotelRentalBookingClient2.Models;
using HotelRentalBookingClient2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelRentalBookingClient2.Controllers
{
    public class PaymentController : BaseCashierController
    {
        // GET: Payment
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            OccupacyClient OC = new OccupacyClient();
            var model = OC.GetAllOccupacies(page, pageSize);


            return View(model);
        }
        public ActionResult MakeBill(long OccupacyNumber)
        {
            PaymentClient PC = new PaymentClient();
    
            var model = PC.MakeBill(OccupacyNumber);
            ViewBag.OccupacyNumber = OccupacyNumber;
            ViewBag.model = model;      
            return View();
        }

        public ActionResult Commit(long OccupacyNumber)
        {
            PaymentClient PC = new PaymentClient();

            var model = PC.CommitBill(OccupacyNumber);
            ViewBag.model = model;
         

            return View();
        }
        public ActionResult UserReport()
        {
            UsersClient UC = new UsersClient();
          
            return View();
        }

   
        //public FileContentResult DownloadCSV()
        //{

        //    string csv = string.Concat(from employee in db.Employees
        //                               select employee.EmployeeCode + ","
        //                               + employee.EmployeeName + ","
        //                               + employee.Department + ","
        //                               + employee.Supervisor + "\n");
        //    return File(new System.Text.UTF8Encoding().GetBytes(csv), "text/csv", "Report.csv");
        //}
    }
}