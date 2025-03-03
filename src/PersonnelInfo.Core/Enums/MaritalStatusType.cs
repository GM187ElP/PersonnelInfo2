using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Core.Enums;
public enum MaritalStatusType
{
    [Display(Name = "انتخاب نشده")] NotSelected, [Display(Name = "مجرد")] Single, [Display(Name = "متاهل")] Married
}