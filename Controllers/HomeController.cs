using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeDetails.Models;

namespace EmployeeDetails.Controllers
{
    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult ValidateUser(string username, string password)
        {
            EmployeesPersonalDetailsEntities db = new EmployeesPersonalDetailsEntities();

            var data = from c in db.tbl_EmployeeDetails where c.UserID == username && c.Pwd == password select c;
            if (data.Count() > 0)
                return Json(new { Success = true, username }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { Success = false, }, JsonRequestBehavior.AllowGet);
        }

    }
}