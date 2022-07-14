using Computer_club.Domain.Data.Entities;
using Computer_club.Domain.Exceptions;
using Computer_club.Domain.Models;
using Computer_club.Domain.Services.AccountService;
using Microsoft.AspNetCore.Mvc;

namespace Computer_club.Controllers;

[Route("[controller]")]
public class RegisterController : ControllerBase
{
    private readonly IAccountService _service;

    public RegisterController(IAccountService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Register([FromBody] UserRegisterRequest request)
    {
        if (!TryValidateModel(request))
            return BadRequest();
        try
        {
            _service.Register(request.Login, request.Email, request.Password);
            return Ok();
        }
        catch (ServiceException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}