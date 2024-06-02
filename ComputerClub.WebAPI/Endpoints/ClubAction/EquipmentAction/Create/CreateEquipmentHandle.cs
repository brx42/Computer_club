using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.EquipmentAction.Create;

public class CreateEquipmentHandle : Endpoint<CreateEquipmentRequest, CreateEquipmentResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<Equipment> _service;

    public CreateEquipmentHandle(IMapper mapper, IBaseClubRepository<Equipment> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Post("club/place/device-set/equipment");
        
        Summary(sum => { sum.Summary = "Equipment create";});
        
        Options(opt => opt.WithTags("Equipment"));
        
        Policies(Role.SuperAdminAndManager);
    }

    public override async Task HandleAsync(CreateEquipmentRequest request, CancellationToken ct)
    {
        Equipment equip = _mapper.Map<Equipment>(request);
        
        Equipment addedEquip = await _service.AddAsync(equip, ct);
        
        CreateEquipmentResponse response = _mapper.Map<CreateEquipmentResponse>(addedEquip);

        await SendOkAsync(response, ct);
    }
}