using Computer_club.Data.Entities.UserEntities;
using Computer_club.Services.Services.UserServices.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.UserAction.Get;

public class GetById : EndpointBaseAsync
    .WithRequest<Guid>
    .WithActionResult<GetByIdUserResult>
{
    private readonly IUserService<User> _repository;
    private readonly IMapper _mapper;

    public GetById(IUserService<User> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }


    [HttpGet("api/user/{id:guid}")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Gets a single User",
        Description = "Gets a single User by Id",
        OperationId = "User.GetById",
        Tags = new[] { "UserEndpoints" })
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