using System;
using System.Collections.Generic;

namespace DOTNET_JWT.Models
{
    public partial class Login
    {
        public int Id { get; set; }
        public string? LoginId { get; set; }
        public string? Password { get; set; }
        public string? Role { get;set; }
    }
}
