using System.ComponentModel.DataAnnotations;

namespace PersonnelInfo.Core.DTOs.Validators;

public class NationalIdAttribute : ValidationAttribute
{
    private static bool IsValidnationalId(string nationalId)
    {
        var sum = 0;
        var lastDigit = 0;

        for (var i = 0; i < 10; i++)
        {
            if (int.TryParse(nationalId[i].ToString(), out int digit))
            {
                if (i < 9)
                    sum += (10 - i) * digit;
                else
                    lastDigit = digit;
            }
            else
                return false;
        }

        var calc = sum % 11 < 2 ? sum % 11 : 11 - sum % 11;
        return calc == lastDigit;
    }
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is not string nationalId)
            return new ValidationResult("National Id must be a string.");

        if (string.IsNullOrWhiteSpace(nationalId))
            return new ValidationResult("National Id cannot be empty or contain only whitespace.");

        if (nationalId.Length != 10)
            return new ValidationResult("National Id must be exactly 10 digits long.");

        if (!IsValidnationalId(nationalId))
            return new ValidationResult("Invalid National Id.");

        return ValidationResult.Success;
    }
}

