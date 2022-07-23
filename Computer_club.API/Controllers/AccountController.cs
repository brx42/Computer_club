using System.ComponentModel.DataAnnotations;
using Computer_club.Domain.Data;
using Computer_club.Domain.DTO;
using Computer_club.Domain.Entities;
using Computer_club.Domain.Models;
using Computer_club.Domain.Services.AuthService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Computer_club.Controllers;

[Route("[controller]")]
[ApiController]
[AllowAnonymous]
public class AccountController : ControllerBase
{
    private readonly IAuthService _auth;
    private readonly RoleManager<IdentityRole<Guid>> _role;

    public AccountController(IAuthService auth, RoleManager<IdentityRole<Guid>> role, AppDbContext context,
        UserManager<User> manager)
    {
        _auth = auth;
        _role = role;
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