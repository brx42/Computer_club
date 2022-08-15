using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Domain.Repositories.BaseClubRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.EquipmentAction.Update;

public class UpdateEquipment : EndpointBaseAsync
    .WithRequest<UpdateEquipmentCommand>
    .WithActionResult<UpdateEquipmentResult>
{
    private readonly IBaseClubRepository<Equipment> _service;
    private readonly IMapper _mapper;

    public UpdateEquipment(IBaseClubRepository<Equipment> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpPut("api/clubs/places/device_sets/equipments")]
    [SwaggerOperation(
        Summary = "Equipment update",
        Description = "Equipment update",
        OperationId = "Equipment.Update",
        Tags = new[] { "EquipmentsEndpoints" })
    ]
    public override async Task<ActionResult<UpdateEquipmentResult>> HandleAsync
        ([FromBody]UpdateEquipmentCommand request, CancellationToken token = default)
    {
        var find = await _service.GetByIdAsync(request.Id);
        if (find == null) return NotFound();
        _mapper.Map(request, find);
        await _service.UpdateAsync(find, token);
        var result = _mapper.Map<UpdateEquipmentResult>(find);
        return Ok(result);
    }
}