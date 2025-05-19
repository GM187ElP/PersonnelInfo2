using System;
using System.Collections.Generic;

public class AppLanguageService
{
    private static readonly HashSet<string> RtlLanguages = new(StringComparer.OrdinalIgnoreCase)
    {
        "Fa" 
    };

    public string Language { get; private set; } = "Fa";
    public string Direction { get; private set; } = "rtl";

    public event Action? LanguageChanged;

    public void SetLanguage(string language)
    {
        if (!string.Equals(Language, language, StringComparison.OrdinalIgnoreCase))
        {
            Language = language;
            Direction = RtlLanguages.Contains(Language) ? "rtl" : "ltr";
            LanguageChanged?.Invoke();
        }
    }
}
