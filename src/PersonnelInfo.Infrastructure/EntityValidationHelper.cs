using Microsoft.EntityFrameworkCore;

namespace PersonnelInfo.Infrastructure;

public static class EntityValidationHelper<T> where T : class
{
    public static List<string> ValidateEntity(T entity, DbContext context) 
    {
        var errors = new List<string>();
        var entityType = context.Model.FindEntityType(typeof(T));

        if (entityType == null)
            return errors;

        foreach (var property in entityType.GetProperties())
        {
            var clrProperty = typeof(T).GetProperty(property.Name);
            if (clrProperty == null)
                continue;

            var value = clrProperty.GetValue(entity);

            // Check MaxLength
            if (property.GetMaxLength().HasValue && value is string strValue && strValue.Length > property.GetMaxLength()!.Value)
            {
                errors.Add($"{property.Name} exceeds maximum length of {property.GetMaxLength()!.Value}.");
            }

            // Check Required
            if (!property.IsNullable && value == null)
            {
                errors.Add($"{property.Name} is required but was null.");
            }
        }

        return errors;
    }
}


