﻿using Computer_club.Data.Models.User;
using Computer_club.Services.Services.UserServices.RoleService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.RoleAction.GetAll;

public class GetAllRoles : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult
{
    private readonly IRoleService<IdentityRole<Guid>> _service;

    public GetAllRoles(IRoleService<IdentityRole<Guid>> service)
    {
        _service = service;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [HttpGet("api/roles")]
    [SwaggerOperation(
        Summary = "Get a list of all Roles",
        Description = "Get a list of all Roles",
        OperationId = "Role.GetAll",
        Tags = new[] { "RolesEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(CancellationToken token = default)
    {
        var result = await _service.GetAllAsync(token);
        return Ok(result);
    }
}