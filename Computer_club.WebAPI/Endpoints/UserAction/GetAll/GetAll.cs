using Computer_club.Data.Entities.UserEntities;
using Computer_club.Services.Services.UserServices.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.UserAction.GetAll;

public class GetAll : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult
{
    private readonly IUserService<User> _repository;

    public GetAll(IUserService<User> repository)
    {
        _repository = repository;
    }
    
    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet("api/user")]
    [SwaggerOperation(
        Summary = "Get a list of all Users",
        Description = "Get a list of all Users",
        OperationId = "User.GetAll",
        Tags = new[] { "UserEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(CancellationToken token = default)
    {
        var result = await _repository.GetAllAsync(token);
        return Ok(result);
    }
}