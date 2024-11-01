using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();  
        public IActionResult Index()
        {
            return View("Index", context.Employee.ToList());  
        }
        public IActionResult Details(int id)
        {
            string msg = "Hello From Action";
            int temp = 50;
            List<string> branches = new List<string>();

            branches.Add("cairo");
            branches.Add("Alex");
            branches.Add("Assiut");
            //Additional info to send to view from action , not found in model .. Employee model 
            //We are sending 4 things this way , the model and the three view data 
            ViewData["Msg"] = msg;
            ViewData["Temp"] = temp;
            ViewData["Branches"] = branches;
            Employee empModel =  context.Employee.FirstOrDefault(e=>e.Id == id);
            return View("Details", empModel);
        }

        public IActionResult DetailsVM(int id)
        {
            Employee empModel = context.Employee.Include(e=>e.Department).FirstOrDefault(e => e.Id == id);
           
            List<string> branches = new List<string>();

            branches.Add("cairo");
            branches.Add("Alex");
            branches.Add("Assiut");
            //Mapping from empModel to viewmodel 
            EmpVM empVM = new EmpVM();
            empVM.EmpName = empModel.Name;
            empVM.DeptName = empModel.Department.Name;
            empVM.Color = "Red";
            empVM.Msg = "Welcome";
            empVM.Branches = branches;
            return View("DetailsVM", empVM);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee employee = context.Employee.FirstOrDefault(e=> e.Id == id);
            return View("Edit", employee);

        }

        [HttpPost]
        //Employee Emp: an object containing the updated data for an employee.

        public IActionResult SaveEdit(Employee Emp, int id)
        {
            if (Emp.Name != null)
            {
                Employee empfromdb = context.Employee.FirstOrDefault(e => e.Id == id);

                empfromdb.Name = Emp.Name;
                empfromdb.Salary = Emp.Salary;
                empfromdb.JobTitle = Emp.JobTitle;
                empfromdb.Address = Emp.Address;
                empfromdb.ImageURL = Emp.ImageURL;
                empfromdb.DepartmentID = Emp.DepartmentID;
                return RedirectToAction("Index");

            }
            return View("Edit", Emp);

        }
        //[HttpPost]
        //public IActionResult Edit(Employee employee)
        //{
        //    if (employee.Name != null)
        //    {
        //        context.Employee.Update(employee);
        //        context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(employee);
        //}



    }
}
