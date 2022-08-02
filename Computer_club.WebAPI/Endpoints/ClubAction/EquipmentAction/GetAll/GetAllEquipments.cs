﻿using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Services.ClubServices.EquipmentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Computer_club.WebAPI.Endpoints.ClubAction.EquipmentAction.GetAll;

public class GetAllEquipments : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult
{
    private readonly IEquipmentService<Equipment> _service;
    private readonly IMapper _mapper;

    public GetAllEquipments(IEquipmentService<Equipment> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("api/club/place/device_set/equipment")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [SwaggerOperation(
        Summary = "Equipment get all",
        Description = "Equipment get all",
        OperationId = "Equipment.GetAll",
        Tags = new[] { "EquipmentEndpoints" })
    ]
    public override async Task<ActionResult> HandleAsync(CancellationToken token = default)
    {
        var result = await _service.GetAllAsync(token);
        var map = _mapper.Map<List<GetAllEquipmentsResult>>(result);
        return Ok(map);
    }
}