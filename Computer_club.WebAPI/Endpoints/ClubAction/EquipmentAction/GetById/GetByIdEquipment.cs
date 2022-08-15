using Computer_club.Data.Models.ClubModels;
using Computer_club.Domain.Repositories.BaseClubRepository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.EquipmentAction.GetById;

public class GetByIdEquipment : EndpointBaseAsync
    .WithRequest<int>
    .WithActionResult<GetByIdEquipmentResult>
{
    private readonly IBaseClubRepository<Equipment> _service;
    private readonly IMapper _mapper;

    public GetByIdEquipment(IBaseClubRepository<Equipment> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("api/clubs/places/device_sets/equipments/{id}")]
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