namespace Computer_club.Domain.Models;

public class Response<T> where T : class
{
    public T Data { get; set; }
}