using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Services.ClubServices.EquipmentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.EquipmentAction.GetById;

public class GetByIdEquipment : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult<GetByIdEquipmentResult>
{
    private readonly IEquipmentService<Equipment> _service;
    private readonly IMapper _mapper;

    public GetByIdEquipment(IEquipmentService<Equipment> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("api/clubs/places/device_sets/equipments/{id}")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Equipment get",
        Description = "Equipment get",
        OperationId = "Equipment.GetById",
        Tags = new[] { "EquipmentsEndpoints" })
    ]
    public override async Task<ActionResult<GetByIdEquipmentResult>> HandleAsync(int id, CancellationToken token = default)
    {
        var result = await _service.GetByIdAsync(id);
        var map = _mapper.Map<GetByIdEquipmentResult>(result);
        return Ok(map);
    }
}