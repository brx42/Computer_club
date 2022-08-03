using Computer_club.Data.Entities.UserEntities;
using Computer_club.Data.Models.User;
using Computer_club.Services.Services.UserServices.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.UserAction.Delete;

public class DeleteUser : EndpointBaseAsync
    .WithRequest<Guid>
    .WithActionResult
{
    private readonly IUserService<User> _repository;

    public DeleteUser(IUserService<User> repository)
    {
        _repository = repository;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.ClubAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpDelete("api/users/{id}")]
    [SwaggerOperation(
        Summary = "Deletes a User",
        Description = "Deletes a User",
        OperationId = "User.Delete",
        Tags = new[] { "UsersEndpoints" })
    ]
    public override async Task<ActionResult>
        HandleAsync(Guid id, CancellationToken token = default)
    {
        var user = await _repository.GetByIdAsync(id);

        if (user == null) return NotFound(id);

        await _repository.DeleteAsync(user);
        return NoContent();
    }
}