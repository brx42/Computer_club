namespace Computer_club.Domain.Exceptions;

public class AuthException : Exception
{
    public AuthException(string exc) : base(exc) {}
}