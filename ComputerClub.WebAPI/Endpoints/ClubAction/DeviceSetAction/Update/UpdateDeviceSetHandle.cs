using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.DeviceSetAction.Update;

public class UpdateDeviceSetHandle : Endpoint<UpdateDeviceSetRequest, UpdateDeviceSetResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<DeviceSet> _service;

    public UpdateDeviceSetHandle(IMapper mapper, IBaseClubRepository<DeviceSet> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Put("club/place/device-set");

        Summary(sum => { sum.Summary = "Device set update"; });
        
        Options(opt => opt.WithTags("DeviceSet"));
        
        Policies(Role.SuperAdminAndManager);
    }

    public override async Task HandleAsync(UpdateDeviceSetRequest request, CancellationToken ct)
    {
        DeviceSet? findDeviceSet = await _service.GetByIdAsync(request.Id);

        if (findDeviceSet == null)
        {
            await SendErrorsAsync(404, ct);
        }
        
        _mapper.Map(request, findDeviceSet);
        
        await _service.UpdateAsync(findDeviceSet, ct);
        
        UpdateDeviceSetResponse response = _mapper.Map<UpdateDeviceSetResponse>(findDeviceSet);

        await SendOkAsync(response, ct);
    }
}