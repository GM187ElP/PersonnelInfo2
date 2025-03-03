using System;

namespace PersonnelInfo.Shared.Exceptions.Infrastructure;

[Serializable]
public class NotFoundEntity : Exception
{
    public Type EntityType { get; }

    public NotFoundEntity() : base("The specified entity was not found.")
    {
    }

    public NotFoundEntity(Type type) : base($"The entity of type {type?.Name} was not found.")
    {
        EntityType = type;
    }

    public NotFoundEntity(string? message)
        : base(message)
    {
    }

    public NotFoundEntity(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }

    public override string ToString()
    {
        return $"{base.ToString()}, " + $"Entity Type: {EntityType?.Name}";
    }
}