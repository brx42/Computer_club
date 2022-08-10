using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Services.Services.ClubServices.EquipmentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.EquipmentAction.Update;

public class UpdateEquipmentForFront : EndpointBaseAsync
    .WithRequest<UpdateEquipmentForFrontCommand>
    .WithActionResult<UpdateEquipmentForFrontResult>
{
    private readonly IEquipmentService<Equipment> _service;
    private readonly IMapper _mapper;

    public UpdateEquipmentForFront(IEquipmentService<Equipment> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpPut("clubs/places/device_sets/equipments")]
    [SwaggerOperation(
        Summary = "Equipment update",
        Description = "Equipment update",
        OperationId = "Equipment.Update",
        Tags = new[] { "FrontEndpoints" })
    ]
    public override async Task<ActionResult<UpdateEquipmentForFrontResult>> HandleAsync
        ([FromBody]UpdateEquipmentForFrontCommand request, CancellationToken token = default)
    {
        var find = await _service.GetByIdAsync(request.Id);
        if (find == null) return NotFound();
        _mapper.Map(request, find);
        await _service.UpdateAsync(find, token);
        var result = _mapper.Map<UpdateEquipmentForFrontResult>(find);
        return Ok(result);
    }
}