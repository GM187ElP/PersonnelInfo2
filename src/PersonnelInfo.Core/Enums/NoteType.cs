using System.ComponentModel.DataAnnotations;

namespace PersonnelInfo.Core.Enums;

public enum NoteType
{
    [Display(Name = "انتخاب نشده")] NotSelected,[Display(Name = "چک")] Checque, [Display(Name = "سفته")] PromissionaryNote
}