using System.ComponentModel.DataAnnotations;

namespace PersonnelInfo.Razor.DTOs.Enums;

public enum GenderType
{
    [Display(Name = "انتخاب نشده")] NotSelected, [Display(Name = "آقای")] Male, [Display(Name = "خانم")] Female
}
