using Microsoft.AspNetCore.Mvc.Localization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace PersonellInfo.Blazor.Services;

public class ValidationServices
{
    private readonly Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, LocalizedMessage>>>> _errorDict;

    public ValidationServices()
    {
        try
        {
            var json = File.ReadAllText("./wwwroot/ErrorList.json"); // Adjust path as needed
            _errorDict = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, LocalizedMessage>>>>>(json)
                         ?? new(StringComparer.OrdinalIgnoreCase);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading validation messages: {ex.Message}");
            _errorDict = new(StringComparer.OrdinalIgnoreCase); // Fallback
        }
    }

    /// <summary>
    /// Gets the display name from a DisplayAttribute on the model property.
    /// </summary>
    public string GetDisplayName<T>(Expression<Func<T>> propertyExpression)
    {
        var member = (propertyExpression.Body as MemberExpression)?.Member;
        return member?.GetCustomAttribute<DisplayAttribute>()?.Name ?? member?.Name ?? string.Empty;
    }

    /// <summary>
    /// Retrieves a localized error message from the dictionary.
    /// </summary>
    public string GetError(string dtoName, string propertyName, string errorKey, string lang)
    {
        dtoName = dtoName?.Trim();
        propertyName = propertyName?.Trim();
        errorKey = errorKey?.Trim();
        lang = lang?.Trim().ToLower();

        if (_errorDict.TryGetValue("Errors", out var dtoErrors) &&
            dtoErrors.TryGetValue(dtoName, out var fieldErrors) &&
            fieldErrors.TryGetValue(propertyName, out var errorTypes) &&
            errorTypes.TryGetValue(errorKey, out var localizedMessage))
        {
            return lang switch
            {
                "fa" => localizedMessage.Fa ?? "خطای نامشخص",
                "en" => localizedMessage.En ?? "Unknown error",
                _ => localizedMessage.En ?? "Unknown error"
            };
        }

        return lang == "fa" ? "خطای نامشخص" : "Unknown error";
    }

    /// <summary>
    /// Optional: Returns all error keys available for a given field (for debugging or UI).
    /// </summary>
    public IEnumerable<string> GetAvailableKeys(string dtoName, string propertyName)
    {
        dtoName = dtoName?.Trim();
        propertyName = propertyName?.Trim();

        if (_errorDict.TryGetValue("Errors", out var dtoErrors) &&
            dtoErrors.TryGetValue(dtoName, out var propErrors) &&
            propErrors.TryGetValue(propertyName, out var keys))
        {
            return keys.Keys;
        }

        return Enumerable.Empty<string>();
    }
}

/// <summary>
/// Localized message model for a validation entry.
/// </summary>
public class LocalizedMessage
{
    public string En { get; set; }
    public string Fa { get; set; }
}
