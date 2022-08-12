namespace Computer_club.Services.Options;

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
}

public interface IPagination
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}