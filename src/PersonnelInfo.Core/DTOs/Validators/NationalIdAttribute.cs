using System.ComponentModel.DataAnnotations;

namespace PersonnelInfo.Core.DTOs.Validators;

public class NationalIdAttribute : ValidationAttribute
{
    public NationalIdAttribute() { }
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
        //if (value is not string nationalId)
        //    return new ValidationResult("National Id must be a string.");

        //if (nationalId.Length != 10)
        //    return new ValidationResult(errorMessage);

        if (value is string nationalId)
        {
            if (string.IsNullOrWhiteSpace(nationalId))
                return new ValidationResult(base.ErrorMessage);

            if (!IsValidnationalId(nationalId))
                return new ValidationResult(base.ErrorMessage);

            return ValidationResult.Success;
        }
        else
            return new ValidationResult(base.ErrorMessage);
    }
}

