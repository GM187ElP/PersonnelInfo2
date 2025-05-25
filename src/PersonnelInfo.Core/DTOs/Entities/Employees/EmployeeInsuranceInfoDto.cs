using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Core.DTOs.Entities.Employees;

public class EmployeeInsuranceInfoDto
{
    [StringLength(8)]
    public string? InsurranceCode { get; set; }

    public string? InsurranceStatus { get; set; }

    public bool HasInsurance { get; set; }

    [Range(0, int.MaxValue)]
    public int ExtraInsurranceCount { get; set; } = 0;
}
