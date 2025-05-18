using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using PersonnelInfo.Core.DTOs.Validators;
using System.ComponentModel.DataAnnotations;

//public class AddAddEmployeeDto
//{
//    #region Basic Information
//    [BindNever]
//    [Display(Name = "کد پرسنلی")]
//    public int PersonnelCode { get; set; }

//    [Required]
//    [StringLength(21, MinimumLength = 3)]
//    [Display(Name = "نام")]
//    public string FirstName { get; set; }

//    [Required]
//    [StringLength(21, MinimumLength = 3)]
//    [Display(Name = "نام خانوادگی")]
//    public string LastName { get; set; }

//    [Required]
//    [NationalId]
//    [StringLength(10, MinimumLength = 10)]
//    [RegularExpression(@"^\d+$")]
//    [Display(Name = "کد ملی")]
//    public string NationalId { get; set; }

//    [Required]
//    [StringLength(11, MinimumLength = 11)]
//    [RegularExpression(@"^\d+$")]
//    [Display(Name = "شماره همراه")]
//    public string ContactNumber { get; set; }
//    #endregion
//}


public class AddAddEmployeeDto
{
    [BindNever]
    [Display(Name = "کد پرسنلی")]
    public int PersonnelCode { get; set; }

    [Required(ErrorMessage = "AddEmployeeDto.FirstName.Required")]
    [StringLength(21, MinimumLength = 3, ErrorMessage = "AddEmployeeDto.FirstName.StringLength")]
    [Display(Name = "نام")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "AddEmployeeDto.LastName.Required")]
    [StringLength(21, MinimumLength = 3, ErrorMessage = "AddEmployeeDto.LastName.StringLength")]
    [Display(Name = "نام خانوادگی")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "AddEmployeeDto.NationalId.Required")]
    [NationalId(ErrorMessage = "AddEmployeeDto.NationalId.NationalId")]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "AddEmployeeDto.NationalId.StringLength")]
    [RegularExpression(@"^\d+$", ErrorMessage = "AddEmployeeDto.NationalId.RegularExpression")]
    [Display(Name = "کد ملی")]
    public string NationalId { get; set; }

    [Required(ErrorMessage = "AddEmployeeDto.ContactNumber.Required")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "AddEmployeeDto.ContactNumber.StringLength")]
    [RegularExpression(@"^\d+$", ErrorMessage = "AddEmployeeDto.ContactNumber.RegularExpression")]
    [Display(Name = "شماره همراه")]
    public string ContactNumber { get; set; }
}