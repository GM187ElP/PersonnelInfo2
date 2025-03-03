using PersonnelInfo.Core.Enums;

namespace PersonnelInfo.Core.Entities;

public class Employee
{
    public long Id { get; set; }

    #region Basic Information
    public long PersonnelCode { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalId { get; set; }
    public string ContactNumber { get; set; }
    #endregion

    #region Gender and Status
    public GenderType GenderDisplay { get; set; } = GenderType.NotSelected;
    public WorkingStatusType WorkingStatusDisplay { get; set; } = WorkingStatusType.Working;
    #endregion

    #region Family Information
    public string? FatherName { get; set; }
    public bool IsMarried { get; set; } = false;
    public int ChildrenCount { get; set; } = 0;
    #endregion

    #region Identity Information
    public string? ShenasnameNumber { get; set; }
    public string? ShenasnameSerialLetter { get; set; }
    public string? ShenasnameSerie { get; set; }
    public string? ShenasnameSerial { get; set; }
    #endregion

    #region Birth and Place Information
    public DateTime? BirthDate { get; set; } = DateTime.Now;
    public long? BirthPlaceId { get; set; }
    public City? BirthPlace { get; set; }
    #endregion

    #region Shenasname Issuance Information
    public long? ShenasnameIssuedPlaceId { get; set; }
    public City? ShenasnameIssuedPlace { get; set; }
    #endregion

    #region Insurance Information
    public string? InsurranceCode { get; set; }
    public string? InsurranceStatus { get; set; }
    public bool? HasInsurance { get; set; }
    public int ExtraInsurranceCount { get; set; } = 0;
    #endregion

    #region Employment Information
    public string? DepartmentId { get; set; }
    public JobTitle? JobTitle { get; set; }
    public EmploymentType EmploymentTypeDisplay { get; set; } = EmploymentType.Official;
    public DateTime? StartingDate { get; set; } = DateTime.Now;
    public DateTime? LeavingDate { get; set; }
    public long? SupervisorId { get; set; }
    public Employee? SuperVisor { get; set; }
    public ICollection<Employee>? Employees { get; set; } = new List<Employee>();
    #endregion

    #region Contact Information
    public string InternalContactNumber { get; set; } = "000";
    public string? LandPhoneNumber { get; set; }
    public string? Address { get; set; }
    public string? PostalCode { get; set; }
    #endregion

    #region Academic Information
    public string? MostRecentDegree { get; set; }
    public string? Major { get; set; }
    #endregion

    #region Collection Properties
    public ICollection<ChequePromissionaryNote> ChequePromissionaryNotes { get; set; } = new List<ChequePromissionaryNote>();
    public ICollection<StartLeaveHistory> StartLeftHistories { get; set; } = new List<StartLeaveHistory>();
    public ICollection<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
    #endregion
}
