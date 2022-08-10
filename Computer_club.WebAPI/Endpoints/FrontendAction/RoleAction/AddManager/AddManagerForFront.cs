using Computer_club.Data.Models.UserModels;
using Computer_club.Services.Services.UserServices.RoleService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.RoleAction.AddManager;

public class AddManagerForFront : EndpointBaseAsync
    .WithRequest<Guid>
    .WithActionResult
{
    private readonly IRoleService _service;

    public AddManagerForFront(IRoleService service)
    {
        _service = service;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [HttpPost("roles/managers/{userId}")]
    [SwaggerOperation(
        Summary = "Add user role manager",
        Description = "Add user role manager",
        OperationId = "Role.AddManager",
        Tags = new[] { "FrontEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(Guid userId, CancellationToken token = default)
    {
        var result = await _service.AddManagerAsync(userId);
        if (result == null) return NotFound(result);
        return Ok(result);
    }
}