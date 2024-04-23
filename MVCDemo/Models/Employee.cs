using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String? Name { get; set; }

        [Required]
        public string? Gender { get; set; }

        [Required]
        public string? City { get; set; }

        public int? DepartmentId { get; set; }

        public Department? Department { get; set; }

    }
}
