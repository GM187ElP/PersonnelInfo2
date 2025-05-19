using Microsoft.AspNetCore.Mvc.ModelBinding;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonnelInfo.Core.DTOs.Entities.Employees;

public class EmployeeDto : EmployeeBaseDto
{
    [BindNever]
    public long Id { get; set; }

    public int RowNumber { get; set; }

    #region Basic Information
    public int PersonnelCode { get; set; }

    [StringLength(21, ErrorMessage = "نام نباید بیشتر از {0} کاراکتر باشد.")]
    public string FirstName { get; set; }

    [StringLength(21, ErrorMessage = "نام خانوادگی نباید بیشتر از {0} کاراکتر باشد.")]
    public string LastName { get; set; }

    [StringLength(10, MinimumLength = 10, ErrorMessage = "کد ملی باید {0} رقمی باشد.")]
    public string NationalId { get; set; }

    [StringLength(11, MinimumLength = 11, ErrorMessage = "شماره تماس باید {0} رقمی باشد.")]
    public string ContactNumber { get; set; }
    #endregion

    #region Gender and Status
    public GenderType GenderDisplay { get; set; } = GenderType.NotSelected;

    public WorkingStatusType WorkingStatusDisplay { get; set; } = WorkingStatusType.Working;
    #endregion

    #region Family Information
    [StringLength(21, ErrorMessage = "نام پدر نباید بیشتر از {0} کاراکتر باشد.")]
    public string FatherName { get; set; }

    public MaritalStatusType MaritalStatus { get; set; } = MaritalStatusType.NotSelected;

    [Range(0, int.MaxValue, ErrorMessage = "تعداد فرزندان نمی‌تواند منفی باشد.")]
    public int ChildrenCount { get; set; } = 0;
    #endregion

    #region Identity Information
    [StringLength(10, ErrorMessage = "شماره شناسنامه نباید بیشتر از {0} رقم باشد.")]
    public string ShenasnameNumber { get; set; }

    public string ShenasnameSerialLetter { get; set; }

    [StringLength(6, ErrorMessage = "سری شناسنامه نباید بیشتر از {0} رقم باشد.")]
    public string ShenasnameSerie { get; set; }

    [StringLength(2, ErrorMessage = "سری شناسنامه نباید بیشتر از {0} رقم باشد.")]
    public string ShenasnameSerial { get; set; }
    #endregion

    #region Birth and Place Information
    public DateTime BirthDate { get; set; } = DateTime.Now;

    public long BirthPlaceId { get; set; }

    //public City? BirthPlace { get; set; }
    #endregion

    #region Shenasname Issuance Information
    public long? ShenasnameIssuedPlaceId { get; set; }

    //public City? ShenasnameIssuedPlace { get; set; }
    #endregion

    #region Insurance Information
    [StringLength(8, ErrorMessage = "کد بیمه نباید بیشتر از {0} رقم باشد.")]
    public string? InsurranceCode { get; set; }

    public string? InsurranceStatus { get; set; }

    public bool HasInsurance { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "تعداد بیمه‌های اضافی نمی‌تواند منفی باشد.")]
    public int ExtraInsurranceCount { get; set; } = 0;
    #endregion

    #region Employment Information
    public string? DepartmentId { get; set; }

    //public JobTitle? JobTitle { get; set; }

    public EmploymentType EmploymentTypeDisplay { get; set; } = EmploymentType.Official;

    public DateTime StartingDate { get; set; } = DateTime.Now;

    public DateTime? LeavingDate { get; set; }

    [Range(1, long.MaxValue, ErrorMessage = "کد سرپرست باید عدد مثبت باشد.")]
    public long? SupervisorId { get; set; }
    #endregion

    #region Contact Information
    [StringLength(3, ErrorMessage = "تعداد ارقام کدپستی باید {0} رقم باشد")]
    public string InternalContactNumber { get; set; } = "000";

    [StringLength(11, ErrorMessage = "تعداد ارقام کدپستی باید {0} رقم باشد")]
    public string? LandPhoneNumber { get; set; }

    public string? Address { get; set; }

    [StringLength(10, ErrorMessage = "تعداد ارقام کدپستی باید {0} رقم باشد")]
    public string? PostalCode { get; set; }
    #endregion

    #region Academic Information
    [StringLength(21, ErrorMessage = "نام خانوادگی نباید بیشتر از {0} کاراکتر باشد.")]
    public string? MostRecentDegree { get; set; }

    [StringLength(21, ErrorMessage = "نام خانوادگی نباید بیشتر از {0} کاراکتر باشد.")]
    public string? Major { get; set; }
    #endregion
}

