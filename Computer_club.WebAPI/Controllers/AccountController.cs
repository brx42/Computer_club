using System.ComponentModel.DataAnnotations;
using Computer_club.Data.Models.User;
using Computer_club.Data.Models.UserModels;
using Computer_club.Services.Services.UserServices.AuthService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Computer_club.WebAPI.Controllers;

[Route("[controller]")]
[ApiController]
[AllowAnonymous]
public class AccountController : ControllerBase
{
    private readonly IAuthService _auth;

    public AccountController(IAuthService auth)
    {
        _auth = auth;
    }

    [HttpPost("registration")]
    public async Task<IActionResult> Registration(RegistrationDTO registration)
    {
        try
        {
            await _auth.Registration(registration);
        }
        catch (Exception e)
        {
            return BadRequest( new Exception());
        }

        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO login)
    {
        var result = await _auth.Login(login);
        if (!ModelState.IsValid)
            return BadRequest(result);
        return Ok(result);
    }

    [HttpPost("refresh_token")]
    public async Task<IActionResult> RefreshToken([Required] string token)
    {
        var result = await _auth.RefreshToken(token);
        if (!ModelState.IsValid)
            return BadRequest(result);
        return Ok(result);
    }

    [HttpGet("logout")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> Logout()
    {
        await _auth.Logout();
        return Ok();
    }
}