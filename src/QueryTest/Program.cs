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




var value=ValidationMessageGenerator.DtoGenerateValidationMessages(typeof(UpdateEmployeeDto));
Console.WriteLine(value);
Console.ReadKey();

