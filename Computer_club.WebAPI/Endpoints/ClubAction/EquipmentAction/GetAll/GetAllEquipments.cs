using Computer_club.Data.Models.ClubModels;
using Computer_club.Domain.Options;
using Computer_club.Domain.Repositories.BaseClubRepository;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.EquipmentAction.GetAll;

public class GetAllEquipments : EndpointBaseAsync
    .WithRequest<Pagination>
    .WithActionResult
{
    private readonly IBaseClubRepository<Equipment> _service;
    private readonly IMapper _mapper;

    public GetAllEquipments(IBaseClubRepository<Equipment> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("api/clubs/places/device_sets/equipments")]
    [SwaggerOperation(
        Summary = "Equipment get all",
        Description = "Equipment get all",
        OperationId = "Equipment.GetAll",
        Tags = new[] { "EquipmentsEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync([FromQuery]Pagination pagination, CancellationToken token = default)
    {
        var result = await _service.GetAllAsync(pagination, token);
        var map = _mapper.Map<List<GetAllEquipmentsResult>>(result);
        return Ok(map);
    }
}