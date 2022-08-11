using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Services.ClubServices.EquipmentService;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.EquipmentAction.GetAll;

public class GetAllEquipmentsForFront : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult
{
    private readonly IEquipmentService<Equipment> _service;
    private readonly IMapper _mapper;

    public GetAllEquipmentsForFront(IEquipmentService<Equipment> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("clubs/places/device_sets/equipments")]
    [SwaggerOperation(
        Summary = "Equipment get all",
        Description = "Equipment get all",
        OperationId = "Equipment.GetAll",
        Tags = new[] { "FrontEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(CancellationToken token = default)
    {
        var result = await _service.GetAllAsync(token);
        var map = _mapper.Map<List<GetAllEquipmentsForFrontResult>>(result);
        return Ok(map);
    }
}