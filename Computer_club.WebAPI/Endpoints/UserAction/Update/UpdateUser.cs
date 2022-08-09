using Computer_club.Data.Entities.UserEntities;
using Computer_club.Data.Models.User;
using Computer_club.Services.Services.UserServices.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.UserAction.Update;

public class UpdateUser : EndpointBaseAsync
    .WithRequest<UpdateUserCommand>
    .WithActionResult
{
    private readonly IUserService<User> _service;
    private readonly IMapper _mapper;

    public UpdateUser(IUserService<User> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
        
    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.ClubAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpPut("api/users")]
    [SwaggerOperation(
        Summary = "Updates a User",
        Description = "Updates a User",
        OperationId = "User.Update",
        Tags = new[] { "UsersEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync
    ([FromBody]UpdateUserCommand request,
        CancellationToken token = default)
    {
        var user = await _service.GetByIdAsync(request.Id);
        if (user == null) return NotFound();
        _mapper.Map(request, user);
        await _service.UpdateAsync(user, token);
        var result = _mapper.Map<UpdateUserResult>(user);
        return Ok(result);
    }
}