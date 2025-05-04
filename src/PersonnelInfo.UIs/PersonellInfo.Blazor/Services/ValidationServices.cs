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
        var json = File.ReadAllText("./wwwroot/ErrorList.json"); // adjust path if needed
        _errorDict = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, LocalizedMessage>>>>>(json);
    }

    public string GetDisplayName<T>(Expression<Func<T>> propertyExpression)
    {
        var member = (propertyExpression.Body as MemberExpression)?.Member;
        return member?.GetCustomAttribute<DisplayAttribute>()?.Name ?? member?.Name ?? string.Empty;
    }

    public string GetError(string dtoName, string propertyName, string errorKey, string lang)
    {
        var message = string.Empty;
        if (_errorDict.TryGetValue("Errors", out var dtoErrors) &&
            dtoErrors.TryGetValue(dtoName, out var fieldErrors) &&
            fieldErrors.TryGetValue(propertyName, out var errorTypes) &&
            errorTypes.TryGetValue(errorKey, out var localizedMessage))
        {
            message= lang.ToLower() switch
            {
                "fa" => localizedMessage.Fa ?? "خطای نامشخص",
                "en" => localizedMessage.En ?? "Unknown error",
                _ => localizedMessage.En ?? "Unknown error"
            };
            return message;
        }

        return "خطای نامشخص";
    }

}

internal class LocalizedMessage
{
    public string En { get; set; }
    public string Fa { get; set; }
}