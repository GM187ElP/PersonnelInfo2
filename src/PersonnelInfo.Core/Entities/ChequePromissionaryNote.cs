

using PersonnelInfo.Core.Enums;

namespace PersonnelInfo.Core.Entities;

public class ChequePromissionaryNote
{
    public long Id { get; set; }
    public string Number { get; set; }
    public NoteType Type { get; set; }
    public long Amount { get; set; }
    public long EmployeeId { get; set; }
    public Employee Employee { get; set; }
}
