using System.ComponentModel.DataAnnotations.Schema;


namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Salary { get; set; }
        public string JobTitle { get; set; }
        public string ImageURL { get; set; }
        public string Address { get; set; }
        [ForeignKey("Department")]

        public int DepartmentID { get; set; }
        public Department Department { get; set; }  
    }
}
