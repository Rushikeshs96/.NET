using System;
using System.Collections.Generic;

namespace EmployeeApplication.Models
{
    public partial class State
    {
        public State()
        {
            Cities = new HashSet<City>();
            Emps = new HashSet<Emp>();
        }

        public int StateId { get; set; }
        public string? StateName { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Emp> Emps { get; set; }
    }
}
