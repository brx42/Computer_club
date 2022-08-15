using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Domain.Repositories.BaseClubRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.ProviderAction.Delete;

public class DeleteProvider : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult
{
    private readonly IBaseClubRepository<Provider> _service;

    public DeleteProvider(IBaseClubRepository<Provider> service)
    {
        _service = service;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpDelete("api/clubs/providers/{id}")]
    [SwaggerOperation(
        Summary = "Provider delete ",
        Description = "Provider delete",
        OperationId = "Provider.delete",
        Tags = new[] { "ProvidersEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(int id, CancellationToken token = default)
    {
        var provider = await _service.GetByIdAsync(id);
        if (provider == null) return NotFound();
        var result = _service.DeleteAsync(provider, token);
        return Ok(result);
    }
}