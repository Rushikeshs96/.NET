using EmployeeApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace EmployeeApplication.Models
{
    public partial class Emp
    {
        [Key]
        public int Id { get; set; }

       
        [MinLength(2)]
        [Required]
        public string? Fname { get; set; }

        
        [MinLength(2)]
        [Required]
        public string? Lname { get; set; }

        
        public DateTime? Dob { get; set; }

        [Required]
       [RegularExpression(@"\d{10}")]
        public int? Contact { get; set; }

        
        [EmailAddress]
        [Required]
        public string? Email { get; set; }

        [RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{8,15})")] 
        public string? Password { get; set; }

        public byte[]? Photo { get; set; }

        //  public int? StateId { get; set; }

        //public virtual State? State { get; set; }

    }
}











