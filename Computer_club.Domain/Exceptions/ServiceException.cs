namespace Computer_club.Domain.Exceptions;

public class ServiceException : Exception
{
    public ServiceException(string message) : base(message)
    {
        
    }
}