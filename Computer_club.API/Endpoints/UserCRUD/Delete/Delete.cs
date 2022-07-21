﻿using Computer_club.Domain.Entities;
using Computer_club.Domain.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.Endpoints.UserCRUD.Delete;

public class Delete : EndpointBaseAsync
        .WithRequest<Guid>
        .WithActionResult
{
    private readonly IUserRepository<User> _repository;

    public Delete(IUserRepository<User> repository)
    {
        _repository = repository;
    }
    
    [HttpDelete("api/{id}")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Deletes a User",
        Description = "Deletes a User",
        OperationId = "User.Delete",
        Tags = new[] { "UserEndpoints" })
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