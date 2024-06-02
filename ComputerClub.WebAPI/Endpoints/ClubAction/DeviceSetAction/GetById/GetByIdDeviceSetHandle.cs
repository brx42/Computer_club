using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.DeviceSetAction.GetById;

public class GetByIdDeviceSetHandle : Endpoint<GetByIdDeviceSetRequest, GetByIdDeviceSetResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<DeviceSet> _service;

    public GetByIdDeviceSetHandle(IMapper mapper, IBaseClubRepository<DeviceSet> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Get("api/club/place/device-set/{id}");

        Summary(sum => { sum.Summary = "Device set get by id"; });

        Options(opt => opt.WithTags("DeviceSet"));

        Policies(Role.AllAdmins);
    }

    public override async Task HandleAsync(GetByIdDeviceSetRequest request, CancellationToken ct)
    {
        DeviceSet? result = await _service.GetByIdAsync(request.Id);
        
        GetByIdDeviceSetResponse response = _mapper.Map<GetByIdDeviceSetResponse>(result);

        await SendOkAsync(response, ct);
    }
}