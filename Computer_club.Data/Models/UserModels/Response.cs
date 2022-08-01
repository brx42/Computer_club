namespace Computer_club.Data.Models.UserModels;

public class Response<T> where T : class
{
    public T Data { get; set; }
}