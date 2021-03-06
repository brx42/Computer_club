using Computer_club.Services.UserServices.RoleService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.RoleAction.Get;

public class GetById : EndpointBaseAsync.
        WithRequest<Guid>.
        WithActionResult<GetByIdRoleResult>
{
    private readonly IRoleService<IdentityRole<Guid>> _service;
    private readonly IMapper _mapper;

    public GetById(IRoleService<IdentityRole<Guid>> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    
    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet("api/role/{id:guid}")]
    [SwaggerOperation(
        Summary = "Gets a single User role",
        Description = "Gets a single Role by Id",
        OperationId = "Role.GetById",
        Tags = new[] { "RoleEndpoints" })
    ]
    public override async Task<ActionResult<GetByIdRoleResult>> HandleAsync
        (Guid id, CancellationToken token = default)
    {
        var role = await _service.GetRoleByIdAsync(id);
        if (role == null) return BadRequest();
        var result = _mapper.Map<GetByIdRoleResult>(role);
        return Ok(result);
    }
}