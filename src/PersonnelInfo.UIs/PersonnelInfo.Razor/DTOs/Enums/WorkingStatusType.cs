using System.ComponentModel.DataAnnotations;

namespace PersonnelInfo.Razor.DTOs.Enums;

public enum WorkingStatusType
{
    [Display(Name = "انتخاب نشده")] NotSelected, [Display(Name = "در حال کار")] Working, [Display(Name = "ترک کار")] Left
}
