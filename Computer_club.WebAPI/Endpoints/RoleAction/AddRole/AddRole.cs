using Computer_club.Data.Models.UserModels;
using Computer_club.Services.Services.UserServices.RoleService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.RoleAction.AddRole;

public class AddRole : EndpointBaseAsync
    .WithRequest<AddRoleCommand>
    .WithActionResult
{
    private readonly IRoleService _roleService;
    private readonly IMapper _mapper;

    public AddRole(IRoleService service, IMapper mapper)
    {
        _mapper = mapper;
        _roleService = service;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [HttpPost("api/roles")]
    [SwaggerOperation(
        Summary = "Change user role",
        Description = "Change user role",
        OperationId = "Role.Change",
        Tags = new[] { "RolesEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync([FromBody]AddRoleCommand request, CancellationToken token = default)
    {
        await _roleService.ChangeUserRoleAsync(request.UserId, request.Role);
        var result = _mapper.Map<AddRoleResult>(request);
        return Ok(result);
    }
}