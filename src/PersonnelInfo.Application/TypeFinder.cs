using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Application;
public static class TypeFinder
{
    public static Type FindEntityType(string entityType)
    {
        var resolvedType = Type.GetType(entityType);

        if (resolvedType == null)
            throw new InvalidOperationException($"Entity type '{entityType}' not found.");

        return resolvedType;
    }

    public static Type FindDtoType(string dtoType, string? operation = "")
    {
        var dtoTypeName = $"{dtoType}{operation}Dto";

        var resolvedType = Type.GetType(dtoTypeName);

        if (resolvedType == null)
            throw new InvalidOperationException($"DTO type '{dtoTypeName}' not found.");

        return resolvedType;
    }
}

