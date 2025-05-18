using PersonnelInfo.Core.DTOs.Entities.Employees;
using PersonnelInfo.Core.Enums;

namespace PersonellInfo.Blazor.Components.Pages.Update;

public class EmployeeState
{
    public EmployeeDto? CurrentEmployee { get; set; }

    public event Action? OnChange;
    public void NotifyStateChanged() => OnChange?.Invoke();
}
