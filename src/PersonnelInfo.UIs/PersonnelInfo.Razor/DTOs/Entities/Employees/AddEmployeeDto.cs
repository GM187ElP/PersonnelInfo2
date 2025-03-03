using Microsoft.AspNetCore.Mvc.ModelBinding;
using PersonnelInfo.Core.DTOs.Validators;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Core.Enums;
using System.ComponentModel.DataAnnotations;

public class AddEmployeeDto
{
    #region Basic Information
    [BindNever]
    public int PersonnelCode { get; set; }

    [Required(ErrorMessage = "نام الزامی است.")]
    [Display(Name = "نام")]
    [StringLength(21, ErrorMessage = "نام نباید بیشتر از {0} کاراکتر باشد.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "نام خانوادگی الزامی است.")]
    [Display(Name = "نام خانوادگی")]
    [StringLength(21, ErrorMessage = "نام خانوادگی نباید بیشتر از {0} کاراکتر باشد.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "کد ملی الزامی است.")]
    [Display(Name = "کد ملی")]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "کد ملی باید {0} رقمی باشد.")]
    [NationalId]
    public string NationalId { get; set; }

    [Required(ErrorMessage = "شماره تماس الزامی است.")]
    [Display(Name = "شماره تماس")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "شماره تماس باید {0} رقمی باشد.")]
    public string ContactNumber { get; set; }
    #endregion
}
