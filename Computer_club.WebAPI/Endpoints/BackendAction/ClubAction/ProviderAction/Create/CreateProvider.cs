using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Services.Services.ClubServices.ProviderService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.BackendAction.ClubAction.ProviderAction.Create;

public class CreateProvider : EndpointBaseAsync
    .WithRequest<CreateProviderCommand>
    .WithActionResult<CreateProviderResult>
{
    private readonly IProviderService<Provider> _service;
    private readonly IMapper _mapper;

    public CreateProvider(IProviderService<Provider> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpPost("api/clubs/providers")]
    [SwaggerOperation(
        Summary = "Provider create",
        Description = "Provider create",
        OperationId = "Provider.Create",
        Tags = new[] { "ProvidersEndpoints" })
    ]
    public override async Task<ActionResult<CreateProviderResult>> HandleAsync
        ([FromBody]CreateProviderCommand request, CancellationToken token = default)
    {
        var provider = _mapper.Map<Provider>(request);
        var result = await _service.AddAsync(provider, token);
        var map = _mapper.Map<CreateProviderResult>(result);
        return Created("", map);
    }
}