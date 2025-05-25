using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Core.DTOs.Entities.Employees;

public class EmployeeAcademicInfoDto
{
    [StringLength(21, MinimumLength = 3)]
    public string? MostRecentDegree { get; set; }

    [StringLength(21, MinimumLength = 3)]
    public string? Major { get; set; }
}
