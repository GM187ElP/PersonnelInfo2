using System.ComponentModel.DataAnnotations;

namespace PersonnelInfo.Core.Enums;

public enum EmploymentType
{
    [Display(Name = "انتخاب نشده")] NotSelected, [Display(Name = "رسمی")] Official, [Display(Name = "پیمانی")] Contract
}
