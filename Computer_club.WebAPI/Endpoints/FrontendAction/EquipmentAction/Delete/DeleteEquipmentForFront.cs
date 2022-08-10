using Computer_club.Data.Models.ClubModels;
using Computer_club.Data.Models.UserModels;
using Computer_club.Services.Services.ClubServices.EquipmentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.EquipmentAction.Delete;

public class DeleteEquipmentForFront : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult
{
    private readonly IEquipmentService<Equipment> _service;

    public DeleteEquipmentForFront(IEquipmentService<Equipment> service)
    {
        _service = service;
    }

    [Authorize(Policy = Role.SuperAdmin)]
    [Authorize(Policy = Role.Manager)]
    [HttpDelete("clubs/places/device_sets/equipments/{id}")]
    [SwaggerOperation(
        Summary = "Equipment delete ",
        Description = "Equipment delete",
        OperationId = "Equipment.delete",
        Tags = new[] { "FrontEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(int id, CancellationToken token = default)
    {
        var find = await _service.GetByIdAsync(id);
        if (find == null) return NotFound();
        var result = _service.DeleteAsync(find, token);
        return Ok(result);
    }
}