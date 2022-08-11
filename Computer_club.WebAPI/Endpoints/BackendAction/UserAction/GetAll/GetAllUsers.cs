using Computer_club.Data.Entities.UserEntities;
using Computer_club.Data.Models.UserModels;
using Computer_club.Services.Options;
using Computer_club.Services.Services.UserServices.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.BackendAction.UserAction.GetAll;

public class GetAllUsers : EndpointBaseAsync
    .WithRequest<Pagination>
    .WithActionResult
{
    private readonly IUserService<User> _service;
    private readonly IMapper _mapper;

    public GetAllUsers(IUserService<User> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    
    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.ClubAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpGet("api/users")]
    [SwaggerOperation(
        Summary = "Get a list of all Users",
        Description = "Get a list of all Users",
        OperationId = "User.GetAll",
        Tags = new[] { "UsersEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync
        ([FromQuery] Pagination request,CancellationToken token = default)
    {
        var result =
            (await _service.GetAllAsync(request, token)).Select
            (x => _mapper.Map<User>(x));
        return Ok(result);
    }
}