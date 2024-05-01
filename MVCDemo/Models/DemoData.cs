using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace MVCDemo.Models
{
    public class DemoData
    {
        [Key]
        public int Id { get; set; }

        public string? EmailAdress { get; set; }

        public string? PhoneNumber { get; set; }

        public int? Salary { get; set; }

        public string? PersonalWebsite { get; set; }

        public DateTime? HireDate { get; set; }

        public string? Gender { get; set; }
    }
}
