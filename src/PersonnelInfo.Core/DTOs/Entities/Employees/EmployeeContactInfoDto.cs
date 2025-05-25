using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Core.DTOs.Entities.Employees;

public class EmployeeContactInfoDto
{
    [StringLength(3)]
    public string InternalContactNumber { get; set; } = "000";

    [StringLength(11)]
    public string? LandPhoneNumber { get; set; }

    public string? Address { get; set; }

    [StringLength(10)]
    public string? PostalCode { get; set; }
}
