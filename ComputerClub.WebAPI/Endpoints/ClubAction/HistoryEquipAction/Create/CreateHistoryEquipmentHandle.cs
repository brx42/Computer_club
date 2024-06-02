using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.HistoryEquipAction.Create;

public class CreateHistoryEquipmentHandle : Endpoint<CreateHistoryEquipmentRequest, CreateHistoryEquipmentResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<HistoryEquip> _service;

    public CreateHistoryEquipmentHandle(IMapper mapper, IBaseClubRepository<HistoryEquip> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Post("club/history-equipment");

        Summary(sum => { sum.Summary = "History equipment create"; });

        Options(opt => opt.WithTags("HistoryEquipment"));

        Policies(Role.SuperAdminAndManager);
    }

    public override async Task HandleAsync(CreateHistoryEquipmentRequest request, CancellationToken ct)
    {
        HistoryEquip history = _mapper.Map<HistoryEquip>(request);

        HistoryEquip addedHistoryEquip = await _service.AddAsync(history, ct);
        
        CreateHistoryEquipmentResponse response = _mapper.Map<CreateHistoryEquipmentResponse>(addedHistoryEquip);

        await SendOkAsync(response, ct);
    }
}