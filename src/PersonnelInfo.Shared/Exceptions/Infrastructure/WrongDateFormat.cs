namespace PersonnelInfo.Shared.Exceptions.Infrastructure;

public class WrongDateFormat : Exception
{
    public WrongDateFormat(string datePart) : base(datePart switch
    {
        "Year" => "فرمت سال صحیح نمی باشد",
        "Month" => "فرمت ماه صحیح نمی باشد",
        "Day" => "فرمت روز صحیح نمی باشد",
        _ => "فرمت تاریخ صحیح نمی باشد"
    })
    { }
}
