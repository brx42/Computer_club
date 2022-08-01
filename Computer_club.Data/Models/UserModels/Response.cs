namespace Computer_club.Data.Models.User;

public class Response<T> where T : class
{
    public T Data { get; set; }
}