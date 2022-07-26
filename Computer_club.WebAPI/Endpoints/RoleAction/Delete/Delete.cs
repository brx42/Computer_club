using Computer_club.Services.UserServices.RoleService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.RoleAction.Delete;

public class Delete : EndpointBaseAsync.WithRequest<IdentityRole<Guid>>.WithActionResult
{
    private readonly IRoleService<IdentityRole<Guid>> _service;

    public Delete(IRoleService<IdentityRole<Guid>> service)
    {
        _service = service;
    }

    [HttpDelete("api/role")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Deletes a Role",
        Description = "Deletes a Role",
        OperationId = "Role.Delete",
        Tags = new[] { "RoleEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync([FromBody]IdentityRole<Guid> role, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await _service.DeleteRoleAsync(role);
        if (!result.Succeeded) return BadRequest();
        return Ok(result);
    }
}