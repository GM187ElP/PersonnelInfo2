using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using PersonnelInfo.Core.DTOs.Validators;
using System.ComponentModel.DataAnnotations;

public class AddEmployeeDto
{
    #region Basic Information
    [BindNever]
    [Display(Name = "کد پرسنلی")]
    public int PersonnelCode { get; set; }

    [Required]
    [StringLength(21, MinimumLength = 3)]
    [Display(Name = "نام")]
    public string FirstName { get; set; }

    [Required]
    [StringLength(21, MinimumLength = 3)]
    [Display(Name = "نام خانوادگی")]
    public string LastName { get; set; }

    [Required]
    [NationalId]
    [StringLength(10, MinimumLength = 10)]
    [RegularExpression(@"^\d+$")]
    [Display(Name = "کد ملی")]
    public string NationalId { get; set; }

    [Required]
    [StringLength(11, MinimumLength = 11)]
    [RegularExpression(@"^\d+$")]
    [Display(Name = "شماره همراه")]
    public string ContactNumber { get; set; }
    #endregion
}
