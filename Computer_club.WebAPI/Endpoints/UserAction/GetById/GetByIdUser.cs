using Computer_club.Data.Entities.UserEntities;
using Computer_club.Data.Models.User;
using Computer_club.Services.Services.UserServices.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.UserAction.GetById;

public class GetByIdUser : EndpointBaseAsync
    .WithRequest<Guid>
    .WithActionResult<GetByIdUserResult>
{
    private readonly IUserService<User> _repository;
    private readonly IMapper _mapper;

    public GetByIdUser(IUserService<User> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.ClubAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpGet("api/users/{id:guid}")]
    [SwaggerOperation(
        Summary = "Gets a single User",
        Description = "Gets a single User by Id",
        OperationId = "User.GetById",
        Tags = new[] { "UsersEndpoints" })
    ]
    public override async Task<ActionResult<GetByIdUserResult>> HandleAsync
        (Guid id, CancellationToken token = default)
    {
        var user = await _repository.GetByIdAsync(id);
        if (user == null) return NotFound();
        var result = _mapper.Map<GetByIdUserResult>(user);
        return Ok(result);
    }   
}