using Computer_club.Data.Repository.UserRepository;
using Computer_club.Models.UserModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.Endpoints.Entities.UserCRUD.GetAll;

public class GetAll : EndpointBaseAsync
        .WithoutRequest
        .WithActionResult
{
    private readonly IUserRepository<User> _repository;

    public GetAll(IUserRepository<User> repository)
    {
        _repository = repository;
    }
    

    [HttpGet("user/get_all")]
    [SwaggerOperation(
        Summary = "Get a list of all Users",
        Description = "Get a list of all Users",
        OperationId = "User.GetAll",
        Tags = new[] { "UserEndpoints" })
    ]
    public override async Task<ActionResult>
                            HandleAsync(CancellationToken token = default)
    {
        var result = await _repository.GetAllAsync(token);
        return Ok(result);
    }
}