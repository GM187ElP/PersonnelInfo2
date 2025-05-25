using PersonnelInfo.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Core.DTOs.Entities.Employees;

public class EmployeeEmploymentInfoDto
{
    public string? DepartmentId { get; set; }

    public EmploymentType EmploymentTypeDisplay { get; set; } = EmploymentType.Official;

    [Required]
    public DateTime StartingDate { get; set; } = DateTime.Now;

    public DateTime? LeavingDate { get; set; }

    [Range(1, long.MaxValue)]
    public long? SupervisorId { get; set; }
}
