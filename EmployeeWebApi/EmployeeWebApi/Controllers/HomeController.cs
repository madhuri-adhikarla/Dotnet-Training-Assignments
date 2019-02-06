using BusinessLayer;
using IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using EmployeeDataAccess;

namespace EmployeeWebApi.Controllers
{
    public class HomeController : Controller
    {
        GetEmployeeDetails getEmployeeDetails;
        public HomeController()
        {
            getEmployeeDetails = new GetEmployeeDetails();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Departments()
        {
           return View();
        }
        [HttpPost]
        public ActionResult Departments(FormCollection formCollection)
        {
            string DepartmentId = formCollection.Get("DepartmentId");
            if (DepartmentId != null)
            {
                int id = Int32.Parse(DepartmentId);
                var list = getEmployeeDetails.searchdetails(id);


                return View(list);
            }
            return View();
        }


    }
}