using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Domain.Repositories.BaseClubRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.EquipmentAction.Create;

public class CreateEquipment : EndpointBaseAsync
    .WithRequest<CreateEquipmentCommand>
    .WithActionResult<CreateEquipmentResult>
{
    private readonly IBaseClubRepository<Equipment> _service;
    private readonly IMapper _mapper;

    public CreateEquipment(IBaseClubRepository<Equipment> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpPost("api/clubs/places/device_sets/equipments")]
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