using System.ComponentModel.DataAnnotations;

namespace EmployeeManagmentSystem.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string password { get; set; }
    }
}
