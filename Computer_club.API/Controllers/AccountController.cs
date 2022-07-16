﻿using System.ComponentModel.DataAnnotations;
using Computer_club.Domain.Data;
using Computer_club.Domain.DTO;
using Computer_club.Domain.Entities;
using Computer_club.Domain.Services.AuthService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Computer_club.Controllers;

[Route("[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAuthService _auth;
    private readonly RoleManager<IdentityRole> _role;
    private readonly AppDbContext _context;
    private readonly UserManager<AppUser> _manager;

    public AccountController(IAuthService auth, RoleManager<IdentityRole> role, AppDbContext context, UserManager<AppUser> manager)
    {
        _auth = auth;
        _role = role;
        _context = context;
        _manager = manager;
    }

    [HttpPost("registration")]
    public async Task<IActionResult> Registration(RegistrationDTO registration)
    {
        var result = await _auth.Registration(registration);
        if (!result.Success)
            return BadRequest(result);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO login)
    {
        var result = await _auth.Login(login);
        if (!result.Success)
            return BadRequest(result);
        return Ok(result);
    }

    [HttpPost("refresh_token")]
    public async Task<IActionResult> RefreshToken([Required] string token)
    {
        var result = await _auth.RefreshToken(token);
        if (!result.Success)
            return BadRequest(result);
        return Ok(result);  
    }

    [HttpGet("logout")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> Logout([Required] string refreshToken)
    {
        await _auth.Logout(refreshToken);
        return Ok();
    }
}