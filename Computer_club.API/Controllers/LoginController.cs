using Computer_club.Domain.Exceptions;
using Computer_club.Domain.Models;
using Computer_club.Domain.Services.AccountService;
using Microsoft.AspNetCore.Mvc;

namespace Computer_club.Controllers;

[Route("[controller]")]
public class LoginController : ControllerBase
{
    private readonly IAccountService _service;

    public LoginController(IAccountService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Login([FromBody] AccountLoginRequest request)
    {
        if (!TryValidateModel(request))
            return BadRequest();

        try
        {
            var jwtToken = _service.Login(request.Login, request.Password);
            return Ok(new {token = jwtToken});
        }
        catch (ServiceException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}