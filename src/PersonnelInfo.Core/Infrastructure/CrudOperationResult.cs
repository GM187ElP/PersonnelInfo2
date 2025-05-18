namespace PersonnelInfo.Core.Infrastructure;


//public class CrudOperationResult  
//{
//    public bool Success { get; set; }
//    public int? AffectedRows { get; set; }
//    public long? EntityId { get; set; }
//    public string? ErrorMessage { get; set; }
//    public string? StatusCode { get; set; }
//    public T? Data { get; set; }
//    public int TotalCount { get; set; } = 0;
//}



public class CrudOperationResult  // update delete 
{
    public bool Success { get; set; }
    public int? AffectedRows { get; set; }
    public string? ErrorMessage { get; set; }
    public string? StatusCode { get; set; }
}

public class CrudDataResult<T> : CrudOperationResult // getbyid<entity> ,add<entity>, exist<bool>
{
    public T? Data { get; set; }
}


public class CrudListResult<T> : CrudOperationResult  // getall<entity>
{
    public List<T>? Data { get; set; }
    public int TotalCount { get; set; }
}
