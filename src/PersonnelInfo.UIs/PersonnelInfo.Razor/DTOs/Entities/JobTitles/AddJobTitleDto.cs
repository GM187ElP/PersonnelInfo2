﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PersonnelInfo.Razor.DTOs.Entities.JobTitles;

public class AddJobTitleDto
{
    [Display(Name = "عنوان شغلی")]
    public string Title { get; set; } = string.Empty;

    [Display(Name = "واحد")]
    public List<SelectListItem> Departments { get; set; } = new();
}