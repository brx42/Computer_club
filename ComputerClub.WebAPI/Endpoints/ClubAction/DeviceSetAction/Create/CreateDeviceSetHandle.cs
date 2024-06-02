using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.DeviceSetAction.Create;

public class CreateDeviceSetHandle : Endpoint<CreateDeviceSetRequest, CreateDeviceSetResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<DeviceSet> _service;

    public CreateDeviceSetHandle(IMapper mapper, IBaseClubRepository<DeviceSet> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Post("club/place/device-set");

        Summary(sum =>
        {
            sum.Summary = "Device set create";
        });
        
        Options(opt => opt.WithTags("DeviceSet"));
        
        Policies(Role.SuperAdminAndManager);
    }

    public override async Task<CreateDeviceSetResponse> ExecuteAsync(CreateDeviceSetRequest request, CancellationToken ct)
    {
        DeviceSet set = _mapper.Map<DeviceSet>(request);
        DeviceSet result = await _service.AddAsync(set, ct);
        CreateDeviceSetResponse response = _mapper.Map<CreateDeviceSetResponse>(result);
        return response;
    }
}