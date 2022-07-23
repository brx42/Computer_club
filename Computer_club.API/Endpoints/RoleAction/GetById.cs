using Computer_club.Domain.Entities;
using Computer_club.Domain.Services.RoleService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.Endpoints.RoleAction;

public class GetById : EndpointBaseAsync.
        WithRequest<Guid>.
        WithActionResult<GetByIdRoleResult>
{
    private readonly IRoleService<Role> _service;
    private readonly IMapper _mapper;

    public GetById(IRoleService<Role> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    
    [HttpGet("api/role/{id:guid}")]
    [Authorize]
    [SwaggerOperation(
        Summary = "Gets a single User role",
        Description = "Gets a single Role by Id",
        OperationId = "Role.GetById",
        Tags = new[] { "RoleEndpoints" })
    ]
    public override async Task<ActionResult<GetByIdRoleResult>> HandleAsync
        (Guid id, CancellationToken cancellationToken = default)
    {
        var role = await _service.GetRoleByIdAsync(id);
        if (role == null) return BadRequest();
        var result = _mapper.Map<GetByIdRoleResult>(role);
        return Ok(result);
    }
}