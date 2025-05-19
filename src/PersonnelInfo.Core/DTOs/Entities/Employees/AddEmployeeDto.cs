using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using PersonnelInfo.Core.DTOs.Validators;
using System.ComponentModel.DataAnnotations;

public class AddEmployeeDto
{
    [BindNever]
    public int PersonnelCode { get; set; }

    [Required]
    [StringLength(21, MinimumLength = 3)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(21, MinimumLength = 3)]
    public string LastName { get; set; }

    [Required]
    [NationalId]
    [StringLength(10, MinimumLength = 10)]
    [RegularExpression(@"^\d+$")]
    public string NationalId { get; set; }

    [Required]
    [StringLength(11, MinimumLength = 11)]
    [RegularExpression(@"^\d+$")]
    public string ContactNumber { get; set; }
}