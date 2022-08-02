using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Services.ClubServices.ProviderService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.ProviderAction.Delete;

public class DeleteProvider : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult
{
    private readonly IProviderService<Provider> _service;

    public DeleteProvider(IProviderService<Provider> service)
    {
        _service = service;
    }

    [HttpDelete("api/provider/{id}")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Provider delete ",
        Description = "Provider delete",
        OperationId = "Provider.delete",
        Tags = new[] { "ProviderEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(int id, CancellationToken token = default)
    {
        var provider = await _service.GetByIdAsync(id);
        if (provider == null) return NotFound();
        var result = _service.DeleteAsync(provider, token);
        return Ok(result);
    }
}