using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Core.DTOs.Entities.Employees;

public class CompleteEmployeeDto
{
    public EmployeeBasicInfoDto BasicInfo { get; set; }
    public EmployeeFamilyInfoDto FamilyInfo { get; set; }
    public EmployeeIdentityInfoDto IdentityInfo { get; set; }
    public EmployeeBirthInfoDto BirthInfo { get; set; }
    public EmployeeInsuranceInfoDto InsuranceInfo { get; set; }
    public EmployeeEmploymentInfoDto EmploymentInfo { get; set; }
    public EmployeeContactInfoDto ContactInfo { get; set; }
    public EmployeeAcademicInfoDto AcademicInfo { get; set; }
}
