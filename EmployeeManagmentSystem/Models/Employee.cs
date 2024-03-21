using System.ComponentModel.DataAnnotations;

namespace EmployeeManagmentSystem.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double Salary { get; set; }

        public string Mail { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

    }
}
