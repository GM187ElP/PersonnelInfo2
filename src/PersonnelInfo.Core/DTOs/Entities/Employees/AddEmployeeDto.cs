using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using PersonnelInfo.Core.DTOs.Validators;
using System.ComponentModel.DataAnnotations;

public class AddEmployeeDto
{
    #region Basic Information
    [BindNever]
    [Display(Name ="کد پرسنلی")]
    public int PersonnelCode { get; set; }

    [Required(ErrorMessage = "Required")]
    [StringLength(2, MinimumLength =1,ErrorMessage = "StringLength")]
    [NationalId(ErrorMessage = "NationalId")]
    [Display(Name ="نام")]
    public string FirstName { get; set; }

    //[Required(ErrorMessage = "Required")]
    //[Display(Name ="نام خانوادگی")]
    //[StringLength(21, ErrorMessage = "StringLength")]
    //public string LastName { get; set; }

    //[Required(ErrorMessage = "Required")]
    [NationalId(ErrorMessage = "NationalId")]
    [Display(Name = "کد ملی")]
    [StringLength(1, MinimumLength = 1, ErrorMessage = "StringLength")]
    public string NationalId { get; set; }

    //[Required(ErrorMessage = "Required")]
    //[StringLength(11, MinimumLength = 11, ErrorMessage = "StringLength")]
    //[Display(Name ="شماره همراه")]
    //public string ContactNumber { get; set; }
    #endregion
}
