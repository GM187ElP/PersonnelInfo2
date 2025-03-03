using Microsoft.AspNetCore.Mvc.ModelBinding;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonnelInfo.Core.DTOs.Entities.Employees;

public class EmployeeDto : EmployeeBaseDto
{
    [BindNever]
    public long Id { get; set; }

    #region Basic Information
    [Display(Name = "کد پرسنلی")]
    public long PersonnelCode { get; set; }

    [Display(Name = "نام")]
    [StringLength(21, ErrorMessage = "نام نباید بیشتر از {0} کاراکتر باشد.")]
    public string FirstName { get; set; }

    [Display(Name = "نام خانوادگی")]
    [StringLength(21, ErrorMessage = "نام خانوادگی نباید بیشتر از {0} کاراکتر باشد.")]
    public string LastName { get; set; }

    [Display(Name = "کد ملی")]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "کد ملی باید {0} رقمی باشد.")]
    public string NationalId { get; set; }

    [Display(Name = "شماره تماس")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "شماره تماس باید {0} رقمی باشد.")]
    public string ContactNumber { get; set; }
    #endregion

    #region Gender and Status
    [Display(Name = "جنسیت")]
    public GenderType GenderDisplay { get; set; } = GenderType.NotSelected;

    [Display(Name = "وضعیت اشتغال")]
    public WorkingStatusType WorkingStatusDisplay { get; set; } = WorkingStatusType.Working;
    #endregion

    #region Family Information
    [Display(Name = "نام پدر")]
    [StringLength(21, ErrorMessage = "نام پدر نباید بیشتر از {0} کاراکتر باشد.")]
    public string FatherName { get; set; }

    [Display(Name = "متأهل")]
    public MaritalStatusType MaritalStatus { get; set; } = MaritalStatusType.NotSelected;

    [Display(Name = "تعداد فرزندان")]
    [Range(0, int.MaxValue, ErrorMessage = "تعداد فرزندان نمی‌تواند منفی باشد.")]
    public int ChildrenCount { get; set; } = 0;
    #endregion

    #region Identity Information
    [Display(Name = "شماره شناسنامه")]
    [StringLength(10, ErrorMessage = "شماره شناسنامه نباید بیشتر از {0} رقم باشد.")]
    public string ShenasnameNumber { get; set; }

    [Display(Name = "حرف سریال شناسنامه")]
    public string ShenasnameSerialLetter { get; set; }

    [Display(Name = "سری شناسنامه")]
    [StringLength(6, ErrorMessage = "سری شناسنامه نباید بیشتر از {0} رقم باشد.")]
    public string ShenasnameSerie { get; set; }

    [Display(Name = "سریال شناسنامه")]
    [StringLength(2, ErrorMessage = "سری شناسنامه نباید بیشتر از {0} رقم باشد.")]
    public string ShenasnameSerial { get; set; }
    #endregion

    #region Birth and Place Information
    [Display(Name = "تاریخ تولد")]
    public DateTime BirthDate { get; set; } = DateTime.Now;

    [Display(Name = "محل تولد")]
    public long BirthPlaceId { get; set; }

    //[Display(Name = "شهر تولد")]
    //public City? BirthPlace { get; set; }
    #endregion

    #region Shenasname Issuance Information
    [Display(Name = "محل صدور شناسنامه")]
    public long? ShenasnameIssuedPlaceId { get; set; }

    //[Display(Name = "شهر محل صدور")]
    //public City? ShenasnameIssuedPlace { get; set; }
    #endregion

    #region Insurance Information
    [Display(Name = "کد بیمه")]
    [StringLength(8, ErrorMessage = "کد بیمه نباید بیشتر از {0} رقم باشد.")]
    public string? InsurranceCode { get; set; }

    [Display(Name = "وضعیت بیمه")]
    public string? InsurranceStatus { get; set; }

    [Display(Name = "بیمه دارد؟")]
    public bool HasInsurance { get; set; }

    [Display(Name = "تعداد بیمه‌تکمیلی")]
    [Range(0, int.MaxValue, ErrorMessage = "تعداد بیمه‌های اضافی نمی‌تواند منفی باشد.")]
    public int ExtraInsurranceCount { get; set; } = 0;
    #endregion

    #region Employment Information
    [Display(Name = "واحد")]
    public string? DepartmentId { get; set; }

    //[Display(Name = "عنوان شغلی")]
    //public JobTitle? JobTitle { get; set; }

    [Display(Name = "نوع استخدام")]
    public EmploymentType EmploymentTypeDisplay { get; set; } = EmploymentType.Official;

    [Display(Name = "تاریخ شروع به کار")]
    public DateTime StartingDate { get; set; } = DateTime.Now;

    [Display(Name = "تاریخ پایان کار")]
    public DateTime? LeavingDate { get; set; }

    [Display(Name = "کد سرپرست")]
    [Range(1, long.MaxValue, ErrorMessage = "کد سرپرست باید عدد مثبت باشد.")]
    public long? SupervisorId { get; set; }
    #endregion

    #region Contact Information
    [Display(Name = "شماره تماس داخلی")]
    [StringLength(3, ErrorMessage = "تعداد ارقام کدپستی باید {0} رقم باشد")]
    public string InternalContactNumber { get; set; } = "000";

    [Display(Name = "شماره تلفن ثابت")]
    [StringLength(11, ErrorMessage = "تعداد ارقام کدپستی باید {0} رقم باشد")]
    public string? LandPhoneNumber { get; set; }

    [Display(Name = "آدرس")]
    public string? Address { get; set; }

    [Display(Name = "کد پستی")]
    [StringLength(10, ErrorMessage = "تعداد ارقام کدپستی باید {0} رقم باشد")]
    public string? PostalCode { get; set; }
    #endregion

    #region Academic Information
    [Display(Name = "آخرین مدرک تحصیلی")]
    [StringLength(21, ErrorMessage = "نام خانوادگی نباید بیشتر از {0} کاراکتر باشد.")]
    public string? MostRecentDegree { get; set; }

    [Display(Name = "رشته تحصیلی")]
    [StringLength(21, ErrorMessage = "نام خانوادگی نباید بیشتر از {0} کاراکتر باشد.")]
    public string? Major { get; set; }
    #endregion
}

