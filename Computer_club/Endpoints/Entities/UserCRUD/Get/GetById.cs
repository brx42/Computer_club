using Computer_club.Data.Repository.UserRepository;
using Computer_club.Models.UserModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.Endpoints.Entities.UserCRUD.Get;

public class GetById : EndpointBaseAsync
        .WithRequest<Guid>
        .WithActionResult<GetUserResult>
{
    private readonly IUserRepository<User> _repository;
    private readonly IMapper _mapper;

    public GetById(IUserRepository<User> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet("user/get/{id}")]
    [SwaggerOperation(
        Summary = "Gets a single User",
        Description = "Gets a single User by Id",
        OperationId = "User.GetById",
        Tags = new[] { "UserEndpoints" })
    ]
    public override async Task<ActionResult<GetUserResult>>
        HandleAsync(Guid id, CancellationToken token = default)
    {
        var user = await _repository.GetByIdAsync(id, token);
        if (user == null) return NotFound();
        var result = _mapper.Map<GetUserResult>(user);
        return Ok(result);
    }   
}