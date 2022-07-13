using Computer_club.Domain.Data.Entities;
using Computer_club.Domain.Data.Entities.User;
using Computer_club.Domain.Services;
using Computer_club.Domain.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.Endpoints.UserCRUD.Create;

public class Create : EndpointBaseAsync
        .WithRequest<CreateUserCommand>
        .WithActionResult<CreateUserResult>
{
    private readonly IUserRepository<UserModel> _repository;
    private readonly IMapper _mapper;


    public Create(IUserRepository<UserModel> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [Authorize]
    [HttpPost("user/create")]
    [SwaggerOperation(
        Summary = "Creates a new User",
        Description = "Creates a new User",
        OperationId = "User.Create",
        Tags = new[] { "UserEndpoints" })
    ]
    public override async Task<ActionResult<CreateUserResult>>
        HandleAsync([FromBody]CreateUserCommand request,
                    CancellationToken token = default)
    {
        var user = new UserModel();
        _mapper.Map(request, user);
        await _repository.AddAsync(user, token);

        var result = _mapper.Map<CreateUserResult>(user);
        return Ok(result);
    }
}