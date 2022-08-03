using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Services.ClubServices.ProviderService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.ProviderAction.Update;

public class UpdateProvider : EndpointBaseAsync
    .WithRequest<UpdateProviderCommand>
    .WithActionResult<UpdateProviderResult>
{
    private readonly IProviderService<Provider> _service;
    private readonly IMapper _mapper;

    public UpdateProvider(IProviderService<Provider> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPut("api/providers")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Provider update",
        Description = "Provider update",
        OperationId = "Provider.Update",
        Tags = new[] { "ProvidersEndpoints" })
    ]
    public override async Task<ActionResult<UpdateProviderResult>> HandleAsync
        ([FromBody]UpdateProviderCommand provider, CancellationToken token = default)
    {
        var find = await _service.GetByIdAsync(provider.Id);
        if (find == null) return NotFound();
        _mapper.Map(provider, find);
        await _service.UpdateAsync(find, token);
        var result = _mapper.Map<UpdateProviderResult>(find);
        return Ok(result);
    }
}