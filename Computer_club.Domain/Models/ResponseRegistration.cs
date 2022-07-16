using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Computer_club.Domain.Models;

public class ResponseRegistration : BaseResponse
{
    public IEnumerable<IdentityError> Errors { get; set; }
}