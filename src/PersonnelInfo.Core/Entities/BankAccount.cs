
namespace PersonnelInfo.Core.Entities;

public class BankAccount
{
    public long Id { get; set; }
    public string? AccountNumber { get; set; }
    public int BankNameId { get; set; }
    public BankName BankName { get; set; }
    public long EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public bool IsMain { get; set; }
    public string Iban { get; set; }
}
