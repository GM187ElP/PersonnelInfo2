using PersonnelInfo.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Core.DTOs.Entities.Employees;

public class EmployeeFamilyInfoDto
{
    [Required]
    [StringLength(21, MinimumLength = 3)]
    public string FatherName { get; set; }

    public MaritalStatusType MaritalStatus { get; set; } = MaritalStatusType.NotSelected;

    [Range(0, int.MaxValue)]
    public int ChildrenCount { get; set; } = 0;
}
