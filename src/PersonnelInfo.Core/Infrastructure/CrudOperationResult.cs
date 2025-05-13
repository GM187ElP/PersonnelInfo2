namespace PersonnelInfo.Core.Infrastructure;

public class CrudOperationResult
{
    public bool Success { get; set; }
    public int? AffectedRows { get; set; }
    public long? EntityId { get; set; }
    public string? ErrorMessage { get; set; }
    public string? StatusCode { get; set; }
    public object? Data { get; set; }
    public int TotalCount { get; set; } = 0;
}
