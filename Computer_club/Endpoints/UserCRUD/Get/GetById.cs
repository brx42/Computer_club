﻿using Computer_club.Domain.Entities.User;
using Computer_club.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.Endpoints.UserCRUD.Get;

public class GetById : EndpointBaseAsync
        .WithRequest<Guid>
        .WithActionResult<GetUserResult>
{
    private readonly IUserRepository<UserModel> _repository;
    private readonly IMapper _mapper;

    public GetById(IUserRepository<UserModel> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [Authorize]
    [HttpGet("user/get/{id}")]
    [SwaggerOperation(
        Summary = "Gets a single User",
        Description = "Gets a single User by Id",
        OperationId = "User.GetById",
        Tags = new[] { "UserEndpoints" })
    ]
    public override async Task<ActionResult<GetUserResult>>
        HandleAsync(Guid id, CancellationToken token = default)
    {
        var user = await _repository.GetByIdAsync(id, token);
        if (user == null) return NotFound();
        var result = _mapper.Map<GetUserResult>(user);
        return Ok(result);
    }   
}