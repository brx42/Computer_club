using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Computer_club.Domain.Options;

public class Pagination : IPagination
{
    public Pagination() { }
    public Pagination(int pageNumber, int pageSize)
    {
        PageSize = pageSize;
        PageNumber = pageNumber;
    }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;

    [BindNever]
    public int Skip
    {
        get
        {
            return (PageNumber - 1) * PageSize;
        }
    }
    
    [BindNever]
    public int Take
    {
        get
        {
            return PageSize;
        }
    }
}

public interface IPagination
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}