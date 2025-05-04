namespace PersonellInfo.Blazor.Validations;


// Helpers/ValidationMessageProvider.cs
using System.Text.Json;

public static class ValidationMessageProvider
{
    private static Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, string>>>> _errors;

    static ValidationMessageProvider()
    {
        var json = File.ReadAllText("./ErrorList.json");
        _errors = JsonSerializer.Deserialize<RootWrapper>(json)?.Errors ?? new();
    }

    public static string GetMessage(string dto, string property, string rule, string lang = "Fa")
    {
        return _errors.TryGetValue(dto, out var props)
            && props.TryGetValue(property, out var rules)
            && rules.TryGetValue(rule, out var messages)
            && messages.TryGetValue(lang, out var message)
                ? message
                : null;
    }

    private class RootWrapper
    {
        public Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, string>>>> Errors { get; set; }
    }
}
