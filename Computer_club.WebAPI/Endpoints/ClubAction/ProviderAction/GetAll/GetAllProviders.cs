using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Services.ClubServices.ProviderService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.ProviderAction.GetAll;

public class GetAllProviders : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult
{
    private readonly IProviderService<Provider> _service;
    private readonly IMapper _mapper;

    public GetAllProviders(IProviderService<Provider> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("api/provider")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Provider get all",
        Description = "Provider get all",
        OperationId = "Provider.GetAll",
        Tags = new[] { "ProviderEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(CancellationToken token = default)
    {
        var result = await _service.GetAllAsync(token);
        var map = _mapper.Map<List<GetAllProvidersResult>>(result);
        return Ok(map);
    }
}