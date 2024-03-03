using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeDetails.Models;

namespace EmployeeDetails.Controllers
{
    public class EmployeeController : Controller
    {
        //private EmployeeDetailsContext db = new EmployeeDetailsContext();
        EmployeeDBHandle dBHandle = new EmployeeDBHandle();
       
        public ActionResult Index()
        {
            EmployeesPersonalDetailsEntities db = new EmployeesPersonalDetailsEntities();

            IEnumerable<tbl_EmployeeDetails> emp = db.tbl_EmployeeDetails;

            emp.Select(x => new tbl_EmployeeDetails
            {
                EmpID = x.EmpID,
                EmployeeName = x.EmployeeName,
                PhoneNumber = x.PhoneNumber,
                Description = x.Description,
                EmpRank = x.EmpRank,
                EmailID = x.EmailID,
            });

            //EmployeeDBHandle dBHandle = new EmployeeDBHandle();
            //ModelState.Clear();
            return View(emp);
        }

       
        public ActionResult Details(int? id)
        {            
            return View();
        }

       
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public bool InsertData(tbl_EmployeeDetails insertdata)
        {
            EmployeesPersonalDetailsEntities db = new EmployeesPersonalDetailsEntities();
            tbl_EmployeeDetails Employee = new tbl_EmployeeDetails
            {
                EmployeeName = insertdata.EmployeeName,
                PhoneNumber = insertdata.PhoneNumber,
                Description = insertdata.Description,
                EmailID = insertdata.EmailID,
                UserID = insertdata.UserID,
                Pwd = insertdata.Pwd,
                EmpRank = insertdata.EmpRank
               
            };
            db.tbl_EmployeeDetails.Add(Employee);
            try
            {
                db.SaveChanges();
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public ActionResult Edit(int? id)
        {                      
            return View(dBHandle.GetEmployeesForEdit().Find(smodel => smodel.EmpID == id));
        }

        
        [HttpPost]
        public bool EditEmployee(tbl_EmployeeDetails employeeDetailsdata)
        {
            EmployeesPersonalDetailsEntities db = new EmployeesPersonalDetailsEntities();

            var employeeDetails = new tbl_EmployeeDetails { EmpID = employeeDetailsdata.EmpID };
            db.Entry(employeeDetailsdata).State = EntityState.Modified;
            

            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        
        public ActionResult Delete(int id)
        {
            return View();
        }
     
        [HttpPost]
        public bool Delete(int id, FormCollection collection)
        {
            


            EmployeesPersonalDetailsEntities db = new EmployeesPersonalDetailsEntities();

            var employeeDetails = new tbl_EmployeeDetails { EmpID = id };
            db.Entry(employeeDetails).State = EntityState.Deleted;
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        

    }
}
