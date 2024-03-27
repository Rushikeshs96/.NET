using System;
using System.Collections.Generic;

namespace EmployeeApplication.Models
{
    public partial class State
    {
        public State()
        {
            Cities = new HashSet<City>();
        }

        public int Id { get; set; }
        public string? State1 { get; set; }

        public virtual ICollection<City> Cities { get; set; }

       // public virtual ICollection<Emp> Emps { get; set; }



    }
}
