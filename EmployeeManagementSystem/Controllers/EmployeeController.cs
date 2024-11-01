using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();  
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

    }
}
