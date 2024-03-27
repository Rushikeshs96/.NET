using System;
using System.Collections.Generic;

namespace EmployeeApplication.Models
{
    public partial class City
    {
        public int Id { get; set; }
        public string? City1 { get; set; }
        public int? StateId { get; set; }

        public virtual State? State { get; set; }
    }
}
