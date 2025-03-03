using System.ComponentModel.DataAnnotations;

namespace PersonnelInfo.Core.Enums;

public enum WorkingStatusType
{
    [Display(Name = "انتخاب نشده")] NotSelected, [Display(Name = "در حال کار")] Working, [Display(Name = "ترک کار")] Left
}
