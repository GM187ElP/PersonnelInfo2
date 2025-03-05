using System.ComponentModel.DataAnnotations;

namespace PersonnelInfo.Razor.DTOs.Enums;

public enum NoteType
{
    [Display(Name = "انتخاب نشده")] NotSelected,[Display(Name = "چک")] Checque, [Display(Name = "سفته")] PromissionaryNote
}