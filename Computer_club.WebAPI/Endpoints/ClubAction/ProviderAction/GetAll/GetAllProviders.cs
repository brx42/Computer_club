using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Domain.Options;
using Computer_club.Domain.Repositories.BaseClubRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.ProviderAction.GetAll;

public class GetAllProviders : EndpointBaseAsync
    .WithRequest<Pagination>
    .WithActionResult
{
    private readonly IBaseClubRepository<Provider> _service;
    private readonly IMapper _mapper;

    public GetAllProviders(IBaseClubRepository<Provider> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpGet("api/clubs/providers")]
    [SwaggerOperation(
        Summary = "Provider get all",
        Description = "Provider get all",
        OperationId = "Provider.GetAll",
        Tags = new[] { "ProvidersEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync([FromQuery]Pagination pagination, CancellationToken token = default)
    {
        var result = await _service.GetAllAsync(pagination, token);
        var map = _mapper.Map<List<GetAllProvidersResult>>(result);
        return Ok(map);
    }
}