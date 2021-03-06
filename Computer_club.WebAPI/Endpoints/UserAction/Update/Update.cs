using Computer_club.Data.Entities.User;
using Computer_club.Services.UserServices.UserRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.UserAction.Update;

public class Update : EndpointBaseAsync
    .WithRequest<UpdateUserCommand>
    .WithActionResult<UpdateUserResult>
{
    private readonly IUserRepository<User> _repository;
    private readonly IMapper _mapper;

    public Update(IUserRepository<User> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
        
    [HttpPut("api/user")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Updates a User",
        Description = "Updates a User",
        OperationId = "User.Update",
        Tags = new[] { "UserEndpoints" })
    ]
    public override async Task<ActionResult<UpdateUserResult>> HandleAsync
    ([FromBody]UpdateUserCommand request,
        CancellationToken token = default)
    {
        var user = await _repository.GetByIdAsync(request.Id);
        if (user == null) return NotFound();
        _mapper.Map(request, user);
        await _repository.UpdateAsync(user, token);
        var result = _mapper.Map<UpdateUserResult>(user);
        return Ok(result);
    }
}