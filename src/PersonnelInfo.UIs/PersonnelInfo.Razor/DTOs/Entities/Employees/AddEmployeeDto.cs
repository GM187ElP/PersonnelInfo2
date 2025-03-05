using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace PersonnelInfo.Razor.DTOs.Entities.Employees
{
    public class AddEmployeeDto
    {
        [BindNever]
        public int PersonnelCode { get; set; }

        [Display(Name = "نام")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "کد ملی")]
        public string NationalId { get; set; } = string.Empty;

        [Display(Name = "شماره تماس")]
        public string ContactNumber { get; set; } = string.Empty;
    }
}