using Computer_club.Domain.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Computer_club.Domain.Entities;

namespace Computer_club.Endpoints.UserAction.Create;

public class Create : EndpointBaseAsync
        .WithRequest<CreateUserCommand>
        .WithActionResult
{
    private readonly IUserRepository<User> _repository;
    private readonly IMapper _mapper;


    public Create(IUserRepository<User> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost("api/user")]
    [SwaggerOperation(
        Summary = "Creates a new User",
        Description = "Creates a new User",
        OperationId = "User.Create",
        Tags = new[] { "UserEndpoints" })
    ]
    public override async Task<ActionResult>
        HandleAsync([FromBody]CreateUserCommand request,
                    CancellationToken token = default)
    {
        var user = new Domain.Entities.User();
        _mapper.Map(request, user);
        await _repository.AddAsync(user, token);

        var result = _mapper.Map<CreateUserResult>(user);
        return Ok(result);
    }
}