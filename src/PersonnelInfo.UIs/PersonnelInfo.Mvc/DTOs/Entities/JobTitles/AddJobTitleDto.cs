using PersonnelInfo.Core.Entities;

namespace PersonnelInfo.Core.DTOs.Entities.JobTitles;

public class AddJobTitleDto
{
    public string Title { get; set; }
    public string? DepartmentId { get; set; }
    public JobTitle Department { get; set; }
    public ICollection<JobTitle> JobTitles { get; set; }
    public ICollection<Employee> PersonList { get; set; }
}