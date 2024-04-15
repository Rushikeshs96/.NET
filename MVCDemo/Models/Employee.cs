using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public String? Name { get; set; }

        public string? Gender { get; set; }

        public string? City { get; set; }

        public int? DepartmentId { get; set; }
    }
}
