using Microsoft.AspNetCore.Mvc.ModelBinding;
using PersonnelInfo.Razor.DTOs.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonnelInfo.Razor.DTOs.Entities.Employees;

public class UpdateEmployeeDto : EmployeeBaseDto
{
    [BindNever]
    public long Id { get; set; }

    #region Basic Information
    [Display(Name = "کد پرسنلی")]
    public long PersonnelCode { get; set; }

    [Display(Name = "نام")]
    public string FirstName { get; set; } = string.Empty;

    [Display(Name = "نام خانوادگی")]
    public string LastName { get; set; } = string.Empty;

    [Display(Name = "کد ملی")]
    public string NationalId { get; set; } = string.Empty;

    [Display(Name = "شماره تماس")]
    public string ContactNumber { get; set; } = string.Empty;
    #endregion

    #region Gender and Status
    [Display(Name = "جنسیت")]
    public GenderType GenderDisplay { get; set; } = GenderType.NotSelected;

    [Display(Name = "وضعیت اشتغال")]
    public WorkingStatusType WorkingStatusDisplay { get; set; } = WorkingStatusType.NotSelected;
    #endregion

    #region Family Information
    [Display(Name = "نام پدر")]
    public string FatherName { get; set; } = string.Empty;

    [Display(Name = "متأهل")]
    public MaritalStatusType MaritalStatus { get; set; } = MaritalStatusType.NotSelected;

    [Display(Name = "تعداد فرزندان")]
    public int ChildrenCount { get; set; } = 0;
    #endregion

    #region Identity Information
    [Display(Name = "شماره شناسنامه")]
    public string ShenasnameNumber { get; set; } = string.Empty;

    [Display(Name = "حرف سریال شناسنامه")]
    public string ShenasnameSerialLetter { get; set; } = string.Empty;

    [Display(Name = "سری شناسنامه")]
    public string ShenasnameSerie { get; set; } = string.Empty;

    [Display(Name = "سریال شناسنامه")]
    public string ShenasnameSerial { get; set; } = string.Empty;
    #endregion

    #region Birth and Place Information
    [Display(Name = "تاریخ تولد")]
    public DateTime BirthDate { get; set; } = DateTime.Now;

    [Display(Name = "محل تولد")]
    public long BirthPlaceId { get; set; } // should get from database in razor class file
    #endregion

    #region Shenasname Issuance Information
    [Display(Name = "محل صدور شناسنامه")]  // should get from database in razor class file
    public long ShenasnameIssuedPlaceId { get; set; }
    #endregion

    #region Insurance Information
    [Display(Name = "کد بیمه")]
    public string InsurranceCode { get; set; } = string.Empty;

    [Display(Name = "وضعیت بیمه")]
    public string InsurranceStatus { get; set; } = string.Empty;

    [Display(Name = "بیمه دارد؟")]
    public bool HasInsurance { get; set; }

    [Display(Name = "تعداد بیمه ‌تکمیلی")]
    public int ExtraInsurranceCount { get; set; } = 0;
    #endregion

    #region Employment Information
    [Display(Name = "واحد")]
    public string DepartmentId { get; set; } = string.Empty;

    [Display(Name = "نوع استخدام")]
    public EmploymentType EmploymentTypeDisplay { get; set; } = EmploymentType.Official;

    [Display(Name = "تاریخ شروع به کار")]
    public DateTime StartingDate { get; set; } = DateTime.Now;

    [Display(Name = "تاریخ پایان کار")]
    public DateTime? LeavingDate { get; set; } // nullable

    [Display(Name = "کد سرپرست")]
    public long SupervisorId { get; set; }
    #endregion

    #region Contact Information
    [Display(Name = "شماره تماس داخلی")]
    public string InternalContactNumber { get; set; } = string.Empty;

    [Display(Name = "شماره تلفن ثابت")]
    public string LandPhoneNumber { get; set; } = string.Empty;

    [Display(Name = "آدرس")]
    public string Address { get; set; } = string.Empty;

    [Display(Name = "کد پستی")]
    public string PostalCode { get; set; } = string.Empty;
    #endregion

    #region Academic Information
    [Display(Name = "آخرین مدرک تحصیلی")]
    public string MostRecentDegree { get; set; } = string.Empty;

    [Display(Name = "رشته تحصیلی")]
    public string Major { get; set; } = string.Empty;
    #endregion
}

