using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using Microsoft.AspNetCore.Mvc;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.DeviceSetAction.GetAll;

public class GetAllDeviceSetHandle : Endpoint<GetAllDeviceSetRequest, List<GetAllDeviceSetResponse>>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<DeviceSet> _service;

    public GetAllDeviceSetHandle(IMapper mapper, IBaseClubRepository<DeviceSet> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Get("club/place/device-sets");
        
        Summary(sum =>
        {
            sum.Summary = "Device set get all";
        });

        Options(opt => opt.WithTags("DeviceSet"));
        
        Policies(Role.AllAdmins);
    }

    public override async Task HandleAsync([FromQuery]GetAllDeviceSetRequest request, CancellationToken ct)
    {
        List<DeviceSet> result = await _service.GetAllAsync(request, ct);
        
        List<GetAllDeviceSetResponse> response = _mapper.Map<List<GetAllDeviceSetResponse>>(result);

        await SendOkAsync(response, ct);
    }
}