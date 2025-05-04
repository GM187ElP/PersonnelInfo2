using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using PersonnelInfo.Core.DTOs.Validators;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Core.Enums;
using System.ComponentModel.DataAnnotations;

public class AddEmployeeDto
{
    #region Basic Information
    [BindNever]
    [Display(Name ="کد پرسنلی")]
    public int PersonnelCode { get; set; }

    [StringLength(1, ErrorMessage = "StringLength")]
    //[Required(ErrorMessage = "Required")]
    [Display(Name ="نام")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Required")]
    [Display(Name ="نام خانوادگی")]
    [StringLength(21, ErrorMessage = "StringLength")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Required")]
    [Display(Name ="کد ملی")]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "StringLength")]
    [NationalId(ErrorMessage = "NationalId")]
    public string NationalId { get; set; }

    [Required(ErrorMessage = "Required")]
    [Display(Name ="شماره همراه")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "StringLength")]
    public string ContactNumber { get; set; }
    #endregion
}
