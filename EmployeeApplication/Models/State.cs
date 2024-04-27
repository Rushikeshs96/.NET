using System;
using System.Collections.Generic;

namespace EmployeeApplication.Models
{
    public partial class State
    {
       

        public int StateId { get; set; }
        public string? StateName { get; set; }


        public List<Emp>? Emps { get; set; }
        public List<City>? Cities { get; set; }
    }
}
