using System.ComponentModel.DataAnnotations;

namespace PersonnelInfo.Core.DTOs.Validators;

public class NationalIdAttribute : ValidationAttribute
{
    public NationalIdAttribute() { }

    private static bool IsValidnationalId(string nationalId)
    {
        // Check if the length of the nationalId is exactly 10 characters
        if (nationalId.Length != 10)
            return false;

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
            {
                // If any character cannot be parsed as a digit, return false
                return false;
            }
        }

        // Calculate and compare the last digit using the checksum algorithm
        var calc = sum % 11 < 2 ? sum % 11 : 11 - sum % 11;
        return calc == lastDigit;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is string nationalId)
        {
            if (string.IsNullOrWhiteSpace(nationalId) || !IsValidnationalId(nationalId))
            {
                // Return without a custom message if invalid
                return new ValidationResult(string.Empty); // or return null to suppress error message
            }

            return ValidationResult.Success;
        }
        else
        {
            // If the value is not a string, return an invalid result
            return new ValidationResult(string.Empty); // or return null to suppress error message
        }
    }
}
