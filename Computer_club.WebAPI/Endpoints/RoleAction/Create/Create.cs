﻿using Computer_club.Services.Services.UserServices.RoleService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.RoleAction.Create;

public class CreateRole : EndpointBaseAsync
    .WithRequest<string>
    .WithActionResult
{
    private readonly IRoleService<IdentityRole<Guid>> _service;

    public CreateRole(IRoleService<IdentityRole<Guid>> service)
    {
        _service = service;
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost("api/roles")]
    [SwaggerOperation(
        Summary = "Creates a new Role",
        Description = "Creates a new Role",
        OperationId = "Role.Create",
        Tags = new[] { "RolesEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync([FromBody]string request, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await _service.CreateRoleAsync(request);
        if (!result.Succeeded) return BadRequest();
        return Ok(result);
    }
}