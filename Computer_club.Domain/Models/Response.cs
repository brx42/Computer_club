using System.Net;
using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Computer_club.Domain.Models;

public class Response<T> where T : class
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
}

// public class ResponseLogin : Response<HttpResponse>
// {
//     public Token Token { get; set; }
// }
//
// public class ResponseRegistration : Response<HttpResponse>
// {
//     public IEnumerable<IdentityError> Errors { get; set; }
// }