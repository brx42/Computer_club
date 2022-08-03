using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Services.ClubServices.EquipmentService;
using Computer_club.WebAPI.Endpoints.ClubAction.DeviceSetAction.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.EquipmentAction.Create;

public class CreateEquipment : EndpointBaseAsync
    .WithRequest<CreateEquipmentCommand>
    .WithActionResult<CreateEquipmentResult>
{
    private readonly IEquipmentService<Equipment> _service;
    private readonly IMapper _mapper;

    public CreateEquipment(IEquipmentService<Equipment> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost("api/clubs/places/device_sets/equipments")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Equipment create",
        Description = "Equipment create",
        OperationId = "Equipment.Create",
        Tags = new[] { "EquipmentsEndpoints" })
    ]
    public override async Task<ActionResult<CreateEquipmentResult>> HandleAsync
        ([FromBody]CreateEquipmentCommand request, CancellationToken token = default)
    {
        var equip = _mapper.Map<Equipment>(request);
        var result = await _service.AddAsync(equip, token);
        var map = _mapper.Map<CreateEquipmentResult>(result);
        return Created("", map);
    }
}