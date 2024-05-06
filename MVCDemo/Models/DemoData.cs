using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace MVCDemo.Models
{
    public partial class DemoData
    {
        [Key]
        [HiddenInput(DisplayValue =false)]
        public int Id { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Mail Adress")]
        public string? EmailAdress { get; set; }

        [StringLength(10,MinimumLength =10)]
        public string? PhoneNumber { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(NullDisplayText ="NA")]
        public int? Salary { get; set; }

        [DataType(DataType.Url)]
        public string? PersonalWebsite { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:d}")]
        public DateTime? HireDate { get; set; }

        public string? Gender { get; set; }
    }

}
