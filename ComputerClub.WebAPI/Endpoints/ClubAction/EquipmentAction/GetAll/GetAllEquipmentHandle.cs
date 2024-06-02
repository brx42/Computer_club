using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.EquipmentAction.GetAll;

public class GetAllEquipmentHandle : Endpoint<GetAllEquipmentRequest, List<GetAllEquipmentResponse>>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<Equipment> _service;

    public GetAllEquipmentHandle(IMapper mapper, IBaseClubRepository<Equipment> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Get("club/place/device-set/equipments");

        Summary(sum => { sum.Summary = "Equipment"; });
        
        Options(opt => opt.WithTags("Equipment"));
        
        Policies(Role.AllAdmins);
    }

    public override async Task HandleAsync(GetAllEquipmentRequest request, CancellationToken ct)
    {
        List<Equipment> findEquipments = await _service.GetAllAsync(request, ct);
        
        List<GetAllEquipmentResponse> response = _mapper.Map<List<GetAllEquipmentResponse>>(findEquipments);

        await SendOkAsync(response, ct);
    }
}