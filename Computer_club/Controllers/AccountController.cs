using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Computer_club.Domain.Models;
using Computer_club.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Computer_club.Controllers;

[Route("user/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IUserService _service;

    public AccountController(IUserService service)
    {
        _service = service;
    }

    [HttpPost("register")]
    public async Task<ActionResult> RegisterAsync(Register register)
    {
        var result = await _service.RegisterAsync(register);
        return Ok(result);
    }

    [HttpPost("token")]
    public async Task<IActionResult> GetTokenAsync(TokenRequestModel model)
    {
        var result = await _service.GetTokenAsync(model);
        SetRefreshTokenInCookie(result.RefreshToken);
        return Ok(result);
    }

    [HttpPost("add_role")]
    public async Task<IActionResult> AddRoleAsync(AddRole role)
    {
        var result = await _service.AddRoleAsync(role);
        return Ok(result);
    }

    [HttpPost("refresh_token")]
    public async Task<IActionResult> RefreshToken()
    {
        var refreshToken = Request.Cookies["refreshToken"];
        var response = await _service.RefreshTokenAsync(refreshToken);
        if (!string.IsNullOrEmpty(response.RefreshToken))
            SetRefreshTokenInCookie(response.RefreshToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenRequest request)
    {
        var token = request.Token ?? Request.Cookies["refreshToken"];
        if (string.IsNullOrEmpty(token))
            return BadRequest(new { message = "Требуется токен" });

        var response = _service.RevokeToken(token);

        if (!response)
            return NotFound(new { message = "Токен не найден" });
        return Ok(new { message = "Токен аннулирован" });
    }


    private void SetRefreshTokenInCookie(string refreshToken)
    {
        var cookieOption = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddDays(10),
        };
        Response.Cookies.Append("refreshToken", refreshToken, cookieOption);
    }
}