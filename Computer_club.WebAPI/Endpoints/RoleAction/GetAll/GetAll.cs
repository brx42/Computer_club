using Computer_club.Services.Services.UserServices.RoleService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.RoleAction.GetAll;

public class GetAll : EndpointBaseAsync.
    WithoutRequest.
    WithActionResult
{
    private readonly IRoleService<IdentityRole<Guid>> _service;

    public GetAll(IRoleService<IdentityRole<Guid>> service)
    {
        _service = service;
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet("api/role")]
    [SwaggerOperation(
        Summary = "Get a list of all Roles",
        Description = "Get a list of all Roles",
        OperationId = "Role.GetAll",
        Tags = new[] { "RoleEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(CancellationToken token = default)
    {
        var result = await _service.GetAllAsync(token);
        return Ok(result);
    }
}