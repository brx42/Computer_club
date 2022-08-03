﻿using Computer_club.Data.Models.User;
using Computer_club.Services.Services.UserServices.RoleService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.RoleAction.Delete;

public class DeleteRole : EndpointBaseAsync
    .WithRequest<IdentityRole<Guid>>
    .WithActionResult
{
    private readonly IRoleService<IdentityRole<Guid>> _service;

    public DeleteRole(IRoleService<IdentityRole<Guid>> service)
    {
        _service = service;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [HttpDelete("api/roles")]
    [SwaggerOperation(
        Summary = "Deletes a Role",
        Description = "Deletes a Role",
        OperationId = "Role.Delete",
        Tags = new[] { "RolesEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync([FromBody]IdentityRole<Guid> role, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await _service.DeleteRoleAsync(role);
        if (!result.Succeeded) return BadRequest();
        return Ok(result);
    }
}