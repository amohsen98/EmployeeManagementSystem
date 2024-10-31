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
    }
}
