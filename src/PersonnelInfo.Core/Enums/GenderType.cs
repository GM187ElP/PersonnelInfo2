using System.ComponentModel.DataAnnotations;

namespace PersonnelInfo.Core.Enums;

public enum GenderType
{
    [Display(Name = "انتخاب نشده")] NotSelected, [Display(Name = "آقای")] Male, [Display(Name = "خانم")] Female
}
