using PersonnelInfo.Core.DTOs.Validators;
using PersonnelInfo.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Core.DTOs.Entities.Employees;

public class EmployeeBasicInfoDto
{
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
    public string ContactNumber { get; set; }

    public GenderType GenderDisplay { get; set; } = GenderType.NotSelected;

    public WorkingStatusType WorkingStatusDisplay { get; set; } = WorkingStatusType.Working;
}
