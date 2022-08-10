using Computer_club.Data.Models.UserModels;
using Computer_club.Services.Services.UserServices.RoleService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.RoleAction.AddRole;

public class AddUserRole : EndpointBaseAsync
    .WithRequest<AddUserRoleCommand>
    .WithActionResult
{
    private readonly IRoleService _roleService;
    private readonly IMapper _mapper;

    public AddUserRole(IRoleService service, IMapper mapper)
    {
        _mapper = mapper;
        _roleService = service;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [HttpPost("api/roles")]
    [SwaggerOperation(
        Summary = "Add user role",
        Description = "Add user role",
        OperationId = "Role.Add",
        Tags = new[] { "RolesEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync([FromBody]AddUserRoleCommand request, CancellationToken token = default)
    {
        await _roleService.ChangeUserRoleAsync(request.UserId, request.Role);
        var result = _mapper.Map<AddUserRoleResult>(request);
        return Ok(result);
    }
}