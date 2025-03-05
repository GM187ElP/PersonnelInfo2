using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PersonnelInfo.Razor.DTOs.Entities.JobTitles;

public class JobTitleDto
{
    public int Id { get; set; }

    [Display(Name = "عنوان شغلی")]
    public string Title { get; set; } = string.Empty;

    [Display(Name = "واحد")]
    public string Department { get; set; } = string.Empty;
    public List<SelectListItem> Departments { get; set; } = new();
}