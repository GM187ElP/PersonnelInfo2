using ExcelDataReader;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Test;


public partial class ValidationMessageGenerator
{
    public static string DtoGenerateValidationMessages(Type dto)
    {
        var result = new Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, string>>>>();

        var dtoName = dto.Name;
        var properties = dto.GetProperties();
        string json = string.Empty;

        foreach (var property in properties)
        {
            var propertyName = property.Name;
            var validationAttributes = property.GetCustomAttributes(true)
                .OfType<ValidationAttribute>()
                .ToList();

            foreach (var vAttr in validationAttributes)
            {
                var attributeName = vAttr.GetType().Name.Substring(0, vAttr.GetType().Name.Length - 9);
                var errorMessage = vAttr.ErrorMessage;

                if (!result.ContainsKey(dtoName))
                    result[dtoName] = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();

                if (!result[dtoName].ContainsKey(propertyName))
                    result[dtoName][propertyName] = new Dictionary<string, Dictionary<string, string>>();

                if (!result[dtoName][propertyName].ContainsKey(attributeName))
                    result[dtoName][propertyName][attributeName] = new Dictionary<string, string>();

                var messageDictionary = ErrorMessageService.PopulateMessageDictionary();

                var errorMessageEn = FetchErrorMessage(messageDictionary, propertyName, attributeName, "En");
                var errorMessageFa = FetchErrorMessage(messageDictionary, propertyName, attributeName, "Fa");

                result[dtoName][propertyName][attributeName]["En"] = errorMessageEn;
                result[dtoName][propertyName][attributeName]["Fa"] = errorMessageFa;
            }
        }

        json = JsonConvert.SerializeObject(result, Formatting.Indented);
        

        var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        var filePath = Path.Combine(desktopPath, $"{dtoName}ValidationMessages.json");
        File.WriteAllText(filePath, json);

        return json;
    }

    public static string FetchErrorMessage(Dictionary<string, Dictionary<string, Dictionary<string, string>>> messageDictionary, string propertyKey, string errorKey, string languageKey)
    {
        var property = messageDictionary.FirstOrDefault(m => m.Key == propertyKey);

        if (property.Value != null && property.Value.ContainsKey(errorKey))
            return property.Value[errorKey].GetValueOrDefault(languageKey, "Error message not found.");
        else
            return "Error message not found.";
    }


    private class ErrorMessageService
    {
        public static Dictionary<string, Dictionary<string, Dictionary<string, string>>> PopulateMessageDictionary()
        {
            var messageDictionary = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var filePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\", "Errors.xlsx"));

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // skip first two rows
                    reader.Read(); // first row
                    reader.Read(); // second row

                    while (reader.Read())
                    {
                        var propertyKeyFromExcel = reader.GetValue(1)?.ToString()?.Trim();
                        var errorKeyFromExcel = reader.GetValue(2)?.ToString()?.Trim();
                        var englishMessage = reader.GetValue(3)?.ToString()?.Trim();
                        var persianMessage = reader.GetValue(4)?.ToString()?.Trim();

                        if (!string.IsNullOrEmpty(propertyKeyFromExcel) && !string.IsNullOrEmpty(errorKeyFromExcel))
                        {
                            if (!messageDictionary.ContainsKey(propertyKeyFromExcel))
                                messageDictionary[propertyKeyFromExcel] = new Dictionary<string, Dictionary<string, string>>();

                            if (!messageDictionary[propertyKeyFromExcel].ContainsKey(errorKeyFromExcel))
                                messageDictionary[propertyKeyFromExcel][errorKeyFromExcel] = new Dictionary<string, string>();

                            messageDictionary[propertyKeyFromExcel][errorKeyFromExcel]["En"] = englishMessage!;
                            messageDictionary[propertyKeyFromExcel][errorKeyFromExcel]["Fa"] = persianMessage!;
                        }
                    }
                }
            }

            return messageDictionary;
        }
    }







}