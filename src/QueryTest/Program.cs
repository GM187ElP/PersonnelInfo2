using Newtonsoft.Json;
using PersonnelInfo.Razor.DTOs.Entities.Employees;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Test;
using JsonSerializer = System.Text.Json.JsonSerializer;


//




//var db = new DatabaseContext();

//var _dbSet = db.Set<City>();

//var dictionary = await _dbSet.AsNoTracking()
//    .Where(c => c.ProvinceId != null)
//    .GroupBy(c => c.ProvinceId)
//    .ToDictionaryAsync(
//        g => _dbSet.AsNoTracking().First(p => p.Id == g.Key).Name,
//        g => g.Select(c => c.Name).ToList()
//    );




//var value=ValidationMessageGenerator.DtoGenerateValidationMessages(typeof(UpdateEmployeeDto));
//Console.WriteLine(value);
//Console.ReadKey();
//----------------------------------------------------------------------------------------
//using Newtonsoft.Json;
//using System;

//public class Program
//{
//    public static void Main()
//    {
//        string json = "{ 'Errors': { 'AddEmployeeDto': { 'FirstName': { 'StringLength': { 'En': 'First name must be between 3 and 50 characters long.', 'Fa': 'نام باید بین 3 و 50 کاراکتر باشد.' } } } } } }";

//        try
//        {
//            //var validationErrors = JsonConvert.DeserializeObject<ValidationErrors>(json);
//            Console.WriteLine("Deserialization successful");
//        }
//        catch (JsonReaderException ex)
//        {
//            Console.WriteLine($"JSON Error: {ex.Message}");
//        }
//    }
//}
//-----------------------------------------------------------------------------------------
//var props = typeof(AddEmployeeDto).GetProperties();
//foreach (var prop in props)
//{
//    var attrs = prop.GetCustomAttributes(typeof(ValidationAttribute), true);
//    foreach (var attr in attrs)
//    {
//        Console.WriteLine($"{prop.Name}: {attr}");
//    }
//}


var log = new StructuredLog
{
    Category = LogCategory.Api,
    ErrorType = ErrorType.Validation,
    Level = LogLevel.Critical,
    Message = "test",
    Timestamp = DateTime.Now,
    //Context=  new { userId = 123, endPoint = "/admin/data" }
    Context = new Dictionary<string,object> { ["userId"] = 123, ["endPoint"] = "/admin/data" }
};


log.LogStructured(log);

public class StructuredLog
{
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public LogCategory Category { get; set; }
    public LogLevel Level { get; set; }
    public ErrorType ErrorType { get; set; } = ErrorType.None;
    public string Message { get; set; } = string.Empty;
    public object? Context { get; set; }

    public void LogStructured(StructuredLog log)
    {
        var json = JsonSerializer.Serialize(log, new JsonSerializerOptions { WriteIndented = false });
        Console.WriteLine(json);
    }
}



public enum LogCategory { Api, Database, UI, Auth, BackgroundTask }
public enum LogLevel { Trace, Debug, Info, Warning, Error, Critical }
public enum ErrorType { None, Validation, Unauthorized, Network, Timeout, Unexpected }