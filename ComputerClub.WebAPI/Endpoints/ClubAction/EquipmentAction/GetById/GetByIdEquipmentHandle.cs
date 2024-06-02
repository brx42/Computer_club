using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.EquipmentAction.GetById;

public class GetByIdEquipmentHandle : Endpoint<GetByIdEquipmentRequest, GetByIdEquipmentResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<Equipment> _service;

    public GetByIdEquipmentHandle(IMapper mapper, IBaseClubRepository<Equipment> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Get("club/place/device-set/equipment/{id}");

        Summary(sum => { sum.Summary = "Equipment get"; });

        Options(opt => opt.WithTags("Equipment"));

        Policies(Role.AllAdmins);
    }

    public override async Task HandleAsync(GetByIdEquipmentRequest request, CancellationToken ct)
    {
        Equipment? findEquipment = await _service.GetByIdAsync(request.Id);

        if (findEquipment != null)
        {
            await SendErrorsAsync(404, ct);
        }

        GetByIdEquipmentResponse response = _mapper.Map<GetByIdEquipmentResponse>(findEquipment);

        await SendOkAsync(response, ct);
    }
}