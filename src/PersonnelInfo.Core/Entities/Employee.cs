using PersonnelInfo.Core.Enums;

namespace PersonnelInfo.Core.Entities;

public class Employee
{
    public long Id { get; set; }

    #region Basic Information
    public long PersonnelCode { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string NationalId { get; set; } = string.Empty;
    public string ContactNumber { get; set; } = string.Empty;
    #endregion

    #region Gender and Status
    public GenderType GenderDisplay { get; set; } = GenderType.NotSelected;
    public WorkingStatusType WorkingStatusDisplay { get; set; } = WorkingStatusType.Working;
    #endregion

    #region Family Information
    public string FatherName { get; set; } = string.Empty;
    public bool IsMarried { get; set; } = false;
    public int ChildrenCount { get; set; } = 0;
    #endregion

    #region Identity Information
    public string ShenasnameNumber { get; set; } = string.Empty;
    public string ShenasnameSerialLetter { get; set; } = string.Empty;
    public string ShenasnameSerie { get; set; } = string.Empty;
    public string ShenasnameSerial { get; set; } = string.Empty;
    #endregion

    #region Birth and Place Information
    public DateTime BirthDate { get; set; } = DateTime.Now;
    public long BirthPlaceId { get; set; }
    public City? BirthPlace { get; set; } 
    #endregion

    #region Shenasname Issuance Information
    public long ShenasnameIssuedPlaceId { get; set; }
    public City? ShenasnameIssuedPlace { get; set; }
    #endregion

    #region Insurance Information
    public string InsurranceCode { get; set; } = string.Empty;
    public string InsurranceStatus { get; set; } = string.Empty;
    public bool HasInsurance { get; set; }
    public int ExtraInsurranceCount { get; set; } = 0;
    #endregion

    #region Employment Information
    public string DepartmentId { get; set; } = string.Empty;
    public JobTitle? JobTitle { get; set; }
    public EmploymentType EmploymentTypeDisplay { get; set; } = EmploymentType.Official;
    public DateTime StartingDate { get; set; } = DateTime.Now;
    public DateTime? LeavingDate { get; set; } // nullable
    public long SupervisorId { get; set; }
    public Employee? SuperVisor { get; set; }
    public ICollection<Employee> Employees { get; set; } = [];
    #endregion

    #region Contact Information
    public string InternalContactNumber { get; set; } = "000";
    public string LandPhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    #endregion

    #region Academic Information
    public string MostRecentDegree { get; set; } = string.Empty;
    public string Major { get; set; } = string.Empty;
    #endregion

    #region Collection Properties
    public ICollection<ChequePromissionaryNote> ChequePromissionaryNotes { get; set; } = [];
    public ICollection<StartLeaveHistory> StartLeftHistories { get; set; } = [];
    public ICollection<BankAccount> BankAccounts { get; set; } = [];
    #endregion
}
