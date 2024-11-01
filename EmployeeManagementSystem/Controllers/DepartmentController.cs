using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        
        public IActionResult Index()

        {
            //Department has navigation property which is list of employees 
            List<Department> departmentList = context.Department.Include(d=>d.Employees).ToList();
            return View("Index" , departmentList);
        }
        [HttpGet]
        public IActionResult Add() //this action method when called model is null because the view of add contain Model
        {

            return View("Add");
        }

        [HttpPost] //this works as a filter for requests put in url
        public IActionResult SaveAdd(Department dept)
        {
            if (dept.Name != null)
            {
                context.Department.Add(dept); //save in memory 
                context.SaveChanges(); //save in database
                return RedirectToAction("Index");
            }
            return View("Add", dept);   
        }

    }
}
