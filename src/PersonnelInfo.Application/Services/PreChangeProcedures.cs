using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Application.Services;

public class PreChangeProcedures
{
    public static Dictionary<string, int> GetRelatedEntityCounts<TEntity>(TEntity entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        var relatedEntityCounts = new Dictionary<string, int>();

        // Get all properties that are collections
        var collectionProperties = typeof(TEntity)
            .GetProperties()
            .Where(p => typeof(IEnumerable<object>).IsAssignableFrom(p.PropertyType));

        // Check the count for each collection property
        foreach (var property in collectionProperties)
        {
            var value = property.GetValue(entity) as IEnumerable<object>;
            int count = value?.Count() ?? 0;
            relatedEntityCounts[property.Name] = count;
        }

        return relatedEntityCounts;
    }
}