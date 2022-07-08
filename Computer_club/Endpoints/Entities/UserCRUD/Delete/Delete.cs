using Computer_club.Data.Repository.UserRepository;
using Computer_club.Models.UserModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.Endpoints.Entities.UserCRUD.Delete;

public class Delete : EndpointBaseAsync
        .WithRequest<DeleteUserRequest>
        .WithActionResult
{
    private readonly IUserRepository<User> _repository;

    public Delete(IUserRepository<User> repository)
    {
        _repository = repository;
    }

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