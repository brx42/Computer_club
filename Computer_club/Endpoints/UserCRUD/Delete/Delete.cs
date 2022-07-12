using Computer_club.Domain.Entities.User;
using Computer_club.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.Endpoints.UserCRUD.Delete;

public class Delete : EndpointBaseAsync
        .WithRequest<DeleteUserRequest>
        .WithActionResult
{
    private readonly IUserRepository<UserModel> _repository;

    public Delete(IUserRepository<UserModel> repository)
    {
        _repository = repository;
    }

    [Authorize]
    [HttpDelete("user/delete")]
    [SwaggerOperation(
        Summary = "Deletes a User",
        Description = "Deletes a User",
        OperationId = "User.Delete",
        Tags = new[] { "UserEndpoints" })
    ]
    public override async Task<ActionResult> 
    HandleAsync(DeleteUserRequest request, CancellationToken token = default)
    {
        var user = await _repository.GetByIdAsync(request.Id, token);

        if (user == null) return NotFound(request.Id);

        await _repository.DeleteAsync(user, token);
        return NoContent();
    }
}