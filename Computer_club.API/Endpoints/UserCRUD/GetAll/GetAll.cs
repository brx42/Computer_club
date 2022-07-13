using Computer_club.Domain.Data.Entities;
using Computer_club.Domain.Data.Entities.User;
using Computer_club.Domain.Services;
using Computer_club.Domain.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.Endpoints.UserCRUD.GetAll;

public class GetAll : EndpointBaseAsync
        .WithoutRequest
        .WithActionResult
{
    private readonly IUserRepository<UserModel> _repository;

    public GetAll(IUserRepository<UserModel> repository)
    {
        _repository = repository;
    }
    
    [Authorize]
    [HttpGet("user/get_all")]
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