using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.HistoryEquipAction.GetAll;

public class GetAllHistoryEquipmentHandle : Endpoint<GetAllHistoryEquipmentRequest, List<GetAllHistoryEquipmentResponse>>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<HistoryEquip> _service;

    public GetAllHistoryEquipmentHandle(IMapper mapper, IBaseClubRepository<HistoryEquip> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Get("club/history-equipments");

        Summary(sum => { sum.Summary = "History equipment get all"; });

        Options(opt => opt.WithTags("HistoryEquipment"));

        Policies(Role.SuperAdminAndManager);
    }

    public override async Task HandleAsync(GetAllHistoryEquipmentRequest request, CancellationToken ct)
    {
        List<HistoryEquip> findHistoriesEquips = await _service.GetAllAsync(request, ct);

        List<GetAllHistoryEquipmentResponse> response = _mapper.Map<List<GetAllHistoryEquipmentResponse>>(findHistoriesEquips);

        await SendOkAsync(response, ct);
    }
}