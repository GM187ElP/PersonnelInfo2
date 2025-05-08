using Microsoft.AspNetCore.Mvc.Localization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace PersonellInfo.Blazor.Services;

/// <summary>
/// Localized message model for a validation entry.
/// </summary>
public class LocalizedMessage
{
    public string En { get; set; }
    public string Fa { get; set; }
}

public class ValidationServices
{

    string json = File.ReadAllText("./wwwroot/ErrorList.json"); // or load from embedded resource / API

    public void TempTest()
    {
        var _errorDict = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, LocalizedMessage>>>>>(json);
    }
}
