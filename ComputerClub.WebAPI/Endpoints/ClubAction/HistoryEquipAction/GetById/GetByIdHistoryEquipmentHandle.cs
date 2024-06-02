using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.HistoryEquipAction.GetById;

public class GetByIdHistoryEquipmentHandle : Endpoint<GetByIdHistoryEquipmentRequest, GetByIdHistoryEquipmentResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<HistoryEquip> _service;

    public GetByIdHistoryEquipmentHandle(IMapper mapper, IBaseClubRepository<HistoryEquip> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Get("club/history-equipment/{id}");

        Summary(sum => { sum.Summary = "History equipment get"; });
        
        Options(opt => opt.WithTags("HistoryEquipment"));

        Policies(Role.SuperAdminAndManager);
    }

    public override async Task HandleAsync(GetByIdHistoryEquipmentRequest request, CancellationToken ct)
    {
        HistoryEquip? findHistoryEquip = await _service.GetByIdAsync(request.Id);
        
        GetByIdHistoryEquipmentResponse response = _mapper.Map<GetByIdHistoryEquipmentResponse>(findHistoryEquip);

        await SendOkAsync(response, ct);
    }
}