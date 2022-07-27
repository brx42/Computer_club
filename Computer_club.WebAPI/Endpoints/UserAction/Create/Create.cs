using Computer_club.Data.Entities.User;
using Computer_club.Services.Services.UserServices.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.UserAction.Create;

public class Create : EndpointBaseAsync
    .WithRequest<CreateUserCommand>
    .WithActionResult
{
    private readonly IUserService<User> _repository;
    private readonly IMapper _mapper;


    public Create(IUserService<User> repository, IMapper mapper)
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
        var user = new User();
        _mapper.Map(request, user);
        await _repository.AddAsync(user, token);

        var result = _mapper.Map<CreateUserResult>(user);
        return Ok(result);
    }
}