using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Core.DTOs.Entities.Employees;

public class EmployeeIdentityInfoDto
{
    [StringLength(10)]
    public string ShenasnameNumber { get; set; }

    public string ShenasnameSerialLetter { get; set; }

    [StringLength(6)]
    public string ShenasnameSerie { get; set; }

    [StringLength(2)]
    public string ShenasnameSerial { get; set; }
}
