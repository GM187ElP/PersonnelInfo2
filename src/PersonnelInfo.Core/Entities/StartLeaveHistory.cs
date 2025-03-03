namespace PersonnelInfo.Core.Entities;

public class StartLeaveHistory
{
    public long Id { get; set; }
    public string JobTitle { get; set; } = default!;
    public DateTime? StartedDate { get; set; }
    public DateTime? LeftDate { get; set; }
    public long EmployeeId { get; set; }
    public Employee Employee { get; set; }
}
