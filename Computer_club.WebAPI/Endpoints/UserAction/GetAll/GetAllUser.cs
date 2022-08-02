using Computer_club.Data.Entities.UserEntities;
using Computer_club.Services.Services.UserServices.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.UserAction.GetAll;

public class GetAllUser : EndpointBaseAsync
    .WithRequest<GetAllUserCommand>
    .WithActionResult<GetAllUserResult>
{
    private readonly IUserService<User> _repository;
    private readonly IMapper _mapper;

    public GetAllUser(IUserService<User> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet("api/user")]
    [SwaggerOperation(
        Summary = "Get a list of all Users",
        Description = "Get a list of all Users",
        OperationId = "User.GetAll",
        Tags = new[] { "UserEndpoints" })
    ]
    public override async Task<ActionResult<GetAllUserResult>> HandleAsync
        ([FromQuery] GetAllUserCommand request,CancellationToken token = default)
    {
        if (request.PerPage == 0)
            request.PerPage = 10;
        if (request.Page == 0)
            request.Page = 1;

        var result =
            (await _repository.GetAllAsync(request.PerPage, request.Page, token)).Select
            (x => _mapper.Map<GetAllUserResult>(x));
        return Ok(result);
    }
}