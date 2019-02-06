using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeTrainingProject.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using PagedList;
using PagedList.Mvc;


namespace EmployeeTrainingProject.Controllers
{
    public class EmployeesController : Controller
    {
        ApplicationDbContext apDbContext;

        public EmployeesController()
        {
            apDbContext = new ApplicationDbContext();
        }

        // GET: Employees
        public ActionResult Index(string searchBy, string search, int? page)
        {
            if (searchBy == "Name")
            {
                return View(apDbContext.Employees.Where(x => x.Name.StartsWith(search)).ToList().ToPagedList(page ?? 1, 3));
            }
            else if (searchBy == "DepartmentName")
            {
                return View(apDbContext.Departments.Where(x => x.DepartmentName.StartsWith(search)).ToList().ToPagedList(page ?? 1, 3));
            }
            else
            {
                var cust = apDbContext.Employees.Include(e => e.Department).ToList().ToPagedList(page ?? 1, 3);
                return View(cust);
            }

        }


        [HttpGet]
        public ActionResult Create()
        {
            TrainingProjectViewModel emp = new TrainingProjectViewModel
            {
                Employee = new Employee(),
                Departments = apDbContext.Departments,
                Locations = apDbContext.Locations
            };
            return View(emp);
        }



        [HttpPost]
        public ActionResult Create(TrainingProjectViewModel trainingProjectViewModel)
        {
            if (ModelState.IsValid)
            {
                Employee emp = new Employee();
                emp.Name = trainingProjectViewModel.Employee.Name;
                emp.Salary = trainingProjectViewModel.Employee.Salary;
                emp.LocationID = trainingProjectViewModel.Employee.LocationID;
                emp.DepartmentId = trainingProjectViewModel.Employee.DepartmentId;
                apDbContext.Employees.Add(emp);
                apDbContext.SaveChanges();
                return RedirectToAction("Index", "Employees");
            }
            else
            {
                return View("new", "Create");
            }
        }



        public ActionResult Edit(int id = -1)
        {
            if (id == -1)
            {
                return RedirectToAction("Index");
            }
            TrainingProjectViewModel emp = new TrainingProjectViewModel
            {
                Employee = new Employee(),
                Departments = apDbContext.Departments,
                Locations = apDbContext.Locations
            };

            emp.Employee.Name = apDbContext.Employees.FirstOrDefault(i => i.Id == id).Name;
            emp.Employee.Salary = apDbContext.Employees.FirstOrDefault(i => i.Id == id).Salary;
            emp.Employee.DepartmentId = apDbContext.Employees.FirstOrDefault(i => i.Id == id).DepartmentId;
            emp.Employee.LocationID = apDbContext.Employees.FirstOrDefault(i => i.Id == id).LocationID;
            emp.Employee.Id = id;
            return View(emp);
        }


        [HttpPost]
        public ActionResult Update(TrainingProjectViewModel trainingProjectViewModel)
        {
            if (ModelState.IsValid)
            {
                Employee emp = apDbContext.Employees.Include(e => e.Department).Single(i => i.Id == trainingProjectViewModel.Employee.Id);
                //int id = trainingProjectViewModel.Employee.Id;
                emp.Name = trainingProjectViewModel.Employee.Name;
                emp.Salary = trainingProjectViewModel.Employee.Salary;
                emp.DepartmentId = trainingProjectViewModel.Employee.DepartmentId;
                emp.LocationID = trainingProjectViewModel.Employee.LocationID;

                apDbContext.Employees.Add(emp);
                apDbContext.Entry(emp).State = EntityState.Modified;
                apDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Edit",new { id = trainingProjectViewModel.Employee.Id });
            }

        }



        public ActionResult Delete(int id = -1)
        {
            Employee emp = new Employee();
            emp = apDbContext.Employees.Find(id);
            apDbContext.Employees.Remove(emp);
            apDbContext.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Details(int id = -1)
        {
            //TrainingProjectDbContext trainingProjectDbContext = new TrainingProjectDbContext();
            //Employee emp = new Employee();
            //emp = apDbContext.Employees.Find(id);
            //return View(emp);

            TrainingProjectViewModel emp = new TrainingProjectViewModel
            {
                Employee = new Employee(),
                Departments = apDbContext.Departments,
                Locations = apDbContext.Locations
            };

            Employee e = new Employee();
            e = apDbContext.Employees.Find(id);

            emp.Employee.Name = e.Name;
            emp.Employee.Salary = e.Salary;
            return View(emp);
        }

    }



}