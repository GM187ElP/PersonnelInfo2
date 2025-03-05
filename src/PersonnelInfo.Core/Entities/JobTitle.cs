namespace PersonnelInfo.Core.Entities;

public class JobTitle
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? DepartmentId { get; set; } 
    public JobTitle? Department { get; set; } 
    public ICollection<JobTitle> JobTitles { get; set; } = [];
    public ICollection<Employee> Employees { get; set; } = [];
}