using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public String? Name { get; set; }

        [Required]
        public string? Gender { get; set; }

        [Required]
        [DisplayFormat(NullDisplayText = "NA")]              //it will display NA if from db is null
        public string? City { get; set; }

        [DisplayFormat(NullDisplayText = "NA")]              //it will display NA if from db is null
        public int? Salary { get; set; }

        public int? DepartmentId { get; set; }

        public Department? Department { get; set; }

    }
}
