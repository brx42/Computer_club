using Computer_club.Data.Entities.UserEntities;
using Computer_club.Data.Models.UserModels;
using Computer_club.Services.Services.UserServices.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.BackendAction.UserAction.Create;

public class CreateUser : EndpointBaseAsync
    .WithRequest<CreateUserCommand>
    .WithActionResult
{
    private readonly IUserService<User> _repository;
    private readonly IMapper _mapper;


    public CreateUser(IUserService<User> repository, IMapper mapper)
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