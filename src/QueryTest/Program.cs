using Newtonsoft.Json;
using PersonnelInfo.Razor.DTOs.Entities.Employees;
using Test;


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

using Newtonsoft.Json;
using System;

public class Program
{
    public static void Main()
    {
        string json = "{ 'Errors': { 'AddEmployeeDto': { 'FirstName': { 'StringLength': { 'En': 'First name must be between 3 and 50 characters long.', 'Fa': 'نام باید بین 3 و 50 کاراکتر باشد.' } } } } } }";

        try
        {
            //var validationErrors = JsonConvert.DeserializeObject<ValidationErrors>(json);
            Console.WriteLine("Deserialization successful");
        }
        catch (JsonReaderException ex)
        {
            Console.WriteLine($"JSON Error: {ex.Message}");
        }
    }
}
