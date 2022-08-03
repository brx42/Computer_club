using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Services.ClubServices.EquipmentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.EquipmentAction.Update;

public class UpdateEquipment : EndpointBaseAsync
    .WithRequest<UpdateEquipmentCommand>
    .WithActionResult<UpdateEquipmentResult>
{
    private readonly IEquipmentService<Equipment> _service;
    private readonly IMapper _mapper;

    public UpdateEquipment(IEquipmentService<Equipment> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPut("api/clubs/places/device_sets/equipments")]
    [Authorize(AuthenticationSchemes = "Bearer")]
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