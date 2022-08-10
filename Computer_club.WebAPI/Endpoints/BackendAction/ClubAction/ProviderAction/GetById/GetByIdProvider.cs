using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Services.Services.ClubServices.ProviderService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.BackendAction.ClubAction.ProviderAction.GetById;

public class GetByIdProvider : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult<GetByIdProviderResult>
{
    private readonly IProviderService<Provider> _service;
    private readonly IMapper _mapper;

    public GetByIdProvider(IProviderService<Provider> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpGet("api/clubs/providers/{id}")]
    [SwaggerOperation(
        Summary = "Provider get",
        Description = "Provider get",
        OperationId = "Provider.GetById",
        Tags = new[] { "ProvidersEndpoints" })
    ]
    public override async Task<ActionResult<GetByIdProviderResult>> HandleAsync(int id, CancellationToken token = default)
    {
        var provider = await _service.GetByIdAsync(id);
        var result = _mapper.Map<GetByIdProviderResult>(provider);
        return Ok(result);
    }
}