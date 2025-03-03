using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Core.DTOs.Entities.Employees;
public class EmployeeBaseDto
{
    public List<SelectListItem> ShenasnameSerialLetterList { get; set; } = new();

    public static List<SelectListItem> SeedShenasnameSerialLetter()
    {
        return
        [
            new SelectListItem { Text = "الف", Value = "الف" },
            new SelectListItem { Text = "ب", Value = "ب" },
            new SelectListItem { Text = "پ", Value = "پ" },
            new SelectListItem { Text = "ت", Value = "ت" },
            new SelectListItem { Text = "ث", Value = "ث" },
            new SelectListItem { Text = "ج", Value = "ج" },
            new SelectListItem { Text = "چ", Value = "چ" },
            new SelectListItem { Text = "ح", Value = "ح" },
            new SelectListItem { Text = "خ", Value = "خ" },
            new SelectListItem { Text = "د", Value = "د" },
            new SelectListItem { Text = "ذ", Value = "ذ" },
            new SelectListItem { Text = "ر", Value = "ر" },
            new SelectListItem { Text = "ز", Value = "ز" },
            new SelectListItem { Text = "ژ", Value = "ژ" },
            new SelectListItem { Text = "س", Value = "س" },
            new SelectListItem { Text = "ش", Value = "ش" },
            new SelectListItem { Text = "ص", Value = "ص" },
            new SelectListItem { Text = "ض", Value = "ض" },
            new SelectListItem { Text = "ط", Value = "ط" },
            new SelectListItem { Text = "ظ", Value = "ظ" },
            new SelectListItem { Text = "ع", Value = "ع" },
            new SelectListItem { Text = "غ", Value = "غ" },
            new SelectListItem { Text = "ف", Value = "ف" },
            new SelectListItem { Text = "ق", Value = "ق" },
            new SelectListItem { Text = "ک", Value = "ک" },
            new SelectListItem { Text = "گ", Value = "گ" },
            new SelectListItem { Text = "ل", Value = "ل" },
            new SelectListItem { Text = "م", Value = "م" },
            new SelectListItem { Text = "ن", Value = "ن" },
            new SelectListItem { Text = "و", Value = "و" },
            new SelectListItem { Text = "ه", Value = "ه" },
            new SelectListItem { Text = "ی", Value = "ی" }
            ];
    }
}


