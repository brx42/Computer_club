using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Services.Services.ClubServices.EquipmentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.EquipmentAction.Create;

public class CreateEquipmentForFront : EndpointBaseAsync
    .WithRequest<CreateEquipmentForFrontCommand>
    .WithActionResult<CreateEquipmentForFrontResult>
{
    private readonly IEquipmentService<Equipment> _service;
    private readonly IMapper _mapper;

    public CreateEquipmentForFront(IEquipmentService<Equipment> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpPost("clubs/places/device_sets/equipments")]
    [SwaggerOperation(
        Summary = "Equipment create",
        Description = "Equipment create",
        OperationId = "Equipment.Create",
        Tags = new[] { "FrontEndpoints" })
    ]
    public override async Task<ActionResult<CreateEquipmentForFrontResult>> HandleAsync
        ([FromBody]CreateEquipmentForFrontCommand request, CancellationToken token = default)
    {
        var equip = _mapper.Map<Equipment>(request);
        var result = await _service.AddAsync(equip, token);
        var map = _mapper.Map<CreateEquipmentForFrontResult>(result);
        return Created("", map);
    }
}