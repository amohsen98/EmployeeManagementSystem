using EmployeeManagementSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.ViewModel
{
    public class EmpWithDeptListVM
    {
        //Because in some cases we don't want all properties in some class
        public int Id { get; set; }

        public string Name { get; set; }
        public string Salary { get; set; }
        public string JobTitle { get; set; }
        public string ImageURL { get; set; }
        public string Address { get; set; }

        public int DepartmentID { get; set; }
        public List<Department> DepList { get; set; }
    }
}
