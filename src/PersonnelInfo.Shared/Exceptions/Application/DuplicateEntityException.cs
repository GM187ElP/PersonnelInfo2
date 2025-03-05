namespace PersonnelInfo.Shared.Exceptions.Application;

[Serializable]
public class DuplicateEntityException : Exception
{
    public DuplicateEntityException()
    {
    }

    public DuplicateEntityException(string? message) : base(message)
    {
    }

    public DuplicateEntityException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}