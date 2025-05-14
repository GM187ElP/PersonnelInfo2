using PersonnelInfo.Core.Entities;
using PersonnelInfo.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PersonnelInfo.Infrastructure.Data.Seeders;

public class EmployeeSeeder
{
    private readonly DatabaseContext _context;

    public EmployeeSeeder(DatabaseContext context) => _context = context;

    public async Task SeedEmployeesFromJson()
    {
        // Path to the Employees.json file
        var filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "src", "PersonnelInfo.Infrastructure", "Data", "SeedData", "Employees.json");

        // Read the content of the Employees.json file
        var jsonData = await File.ReadAllTextAsync(filePath);

        var employeesDict = JsonSerializer.Deserialize<Dictionary<string, EmployeeRaw>>(jsonData);

        // Convert the dictionary to a list if needed
        var employeesRaw = employeesDict.Values.ToList();
        var employees = new List<Employee>();

        // Loop through each employee and trim string fields
        foreach (var employeeRaw in employeesRaw)
        {
            var employee = new Employee();
            employee.PersonnelCode = employeeRaw.PersonnelCode;  // Assuming it's an int, no trimming needed
            employee.FirstName = employeeRaw.FirstName?.Trim();
            employee.LastName = employeeRaw.LastName?.Trim();
            employee.NationalId = employeeRaw.NationalId?.Trim()??string.Empty;
            employee.ContactNumber = employeeRaw.ContactNumber?.Trim();
            employee.IsDeleted = employeeRaw.IsDeletedString?.ToUpper() == "TRUE";
            employee.IsMarried = employeeRaw.IsMarriedString?.ToUpper() == "TRUE";
            employee.GenderDisplay = employeeRaw.GenderDisplay;  // No trimming needed (enum type)
            employee.WorkingStatusDisplay = employeeRaw.WorkingStatusDisplay;  // No trimming needed (enum type)
            employee.FatherName = employeeRaw.FatherName?.Trim()??string.Empty;
            employee.ChildrenCount = employeeRaw.ChildrenCount;  // Assuming it's an int, no trimming needed
            employee.ShenasnameNumber = employeeRaw.ShenasnameNumber?.Trim()??string.Empty;
            employee.ShenasnameSerial = employeeRaw.ShenasnameSerial?.Trim() ?? string.Empty;
            employee.BirthDate = employeeRaw.BirthDate;  // No trimming needed (DateTime type)
            employee.InsurranceCode = employeeRaw.InsurranceCode?.Trim()??string.Empty;
            employee.InsurranceStatus = employeeRaw.InsurranceStatus?.Trim()??string.Empty;
            employee.ExtraInsurranceCount = employeeRaw.ExtraInsurranceCount;  // Assuming it's an int, no trimming needed
            employee.EmploymentTypeDisplay = employeeRaw.EmploymentTypeDisplay;  // No trimming needed (enum type)
            employee.StartingDate = employeeRaw.StartingDate;  // No trimming needed (DateTime type)
            employee.LeavingDate = employeeRaw.LeavingDate;  // No trimming needed (DateTime type)
            employee.InternalContactNumber = employeeRaw.InternalContactNumber?.Trim();
            employee.LandPhoneNumber = employeeRaw.LandPhoneNumber?.Trim();
            employee.Address = employeeRaw.Address?.Trim()??string.Empty;
            employee.PostalCode = employeeRaw.PostalCode?.Trim()??string.Empty;
            employee.MostRecentDegree = employeeRaw.MostRecentDegree?.Trim()??string.Empty;
            employee.Major = employeeRaw.Major?.Trim() ?? string.Empty;
            employee.BirthPlaceId = employeeRaw.BirthPlaceId;
            employee.ShenasnameIssuedPlaceId = employeeRaw.ShenasnameIssuedPlaceId;
            employee.DepartmentId = employeeRaw.DepartmentId;
            employees.Add(employee);
        }

        // Add each employee to the context
        foreach (var employee in employees)
        {
            await _context.AddAsync(employee);
        }

        // Save the changes to the database
        await _context.SaveChangesAsync();
        Console.WriteLine("success");
    }
}
