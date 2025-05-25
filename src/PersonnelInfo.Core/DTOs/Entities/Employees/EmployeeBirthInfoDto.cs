using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Core.DTOs.Entities.Employees;

public class EmployeeBirthInfoDto
{
    [Required]
    public DateTime BirthDate { get; set; } = DateTime.Now;

    [Required]
    public long BirthPlaceId { get; set; }

    public long? ShenasnameIssuedPlaceId { get; set; }
}
