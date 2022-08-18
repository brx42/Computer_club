using Computer_club.Data.Entities;
using Computer_club.Data.Models.UserModels;
using Computer_club.Domain.Repositories.UserRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.UserAction.Create;

public class CreateUser : EndpointBaseAsync
    .WithRequest<CreateUserCommand>
    .WithActionResult
{
    private readonly IUserRepository<User> _repository;
    private readonly IMapper _mapper;


    public CreateUser(IUserRepository<User> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.ClubAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpPost("api/users")]
    [SwaggerOperation(
        Summary = "Creates a new User",
        Description = "Creates a new User",
        OperationId = "User.Create",
        Tags = new[] { "UsersEndpoints" })
    ]
    public override async Task<ActionResult>
        HandleAsync([FromBody]CreateUserCommand request,
            CancellationToken token = default)
    {
        var user = new User();
        _mapper.Map(request, user);
        await _repository.AddAsync(user, token);

        var result = _mapper.Map<CreateUserResult>(user);
        return Ok(result);
    }
}