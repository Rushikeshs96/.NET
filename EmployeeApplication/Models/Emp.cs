using System;
using System.Collections.Generic;

namespace EmployeeApplication.Models
{
    public partial class Emp
    {
        public int Id { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public DateTime? Dob { get; set; }
        public int? Contact { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public byte[]? Photo { get; set; }
        public int? StateId { get; set; }
        public virtual State? State { get; set; }
    }
}
