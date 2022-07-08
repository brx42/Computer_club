using Computer_club.Data.Repository.UserRepository;
using Computer_club.Models.UserModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.Endpoints.Entities.UserCRUD.Create;

public class Create : EndpointBaseAsync
        .WithRequest<CreateUserCommand>
        .WithActionResult<CreateUserResult>
{
    private readonly IUserRepository<User> _repository;
    private readonly IMapper _mapper;


    public Create(IUserRepository<User> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

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
        var user = new User();
        _mapper.Map(request, user);
        await _repository.AddAsync(user, token);

        var result = _mapper.Map<CreateUserResult>(user);
        return Ok(result);
    }
}