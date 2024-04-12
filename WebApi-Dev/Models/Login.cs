using System.ComponentModel.DataAnnotations;

namespace WebApi_Dev.Models
{
    public class Login
    {
        [Key]
        public int id { get; set; }

        public String? Uid { get; set; }

        public string? Mail { get; set; }

        public string? Password { get; set; }

        public int? IsActive { get; set; }
    }
}
