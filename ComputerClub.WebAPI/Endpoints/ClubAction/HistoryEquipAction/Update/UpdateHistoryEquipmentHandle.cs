using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.HistoryEquipAction.Update;

public class UpdateHistoryEquipmentHandle : Endpoint<UpdateHistoryEquipmentRequest, UpdateHistoryEquipmentResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<HistoryEquip> _service;

    public UpdateHistoryEquipmentHandle(IMapper mapper, IBaseClubRepository<HistoryEquip> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Put("club/history-equipment");

        Summary(sum => { sum.Summary = "History equipment update"; });

        Options(opt => opt.WithTags("HistoryEquipment"));

        Policies(Role.SuperAdminAndManager);
    }

    public override async Task HandleAsync(UpdateHistoryEquipmentRequest request, CancellationToken ct)
    {
        HistoryEquip? findHistoryEquipment = await _service.GetByIdAsync(request.Id);

        if (findHistoryEquipment == null)
        {
            await SendErrorsAsync(404, ct);
        }

        _mapper.Map(request, findHistoryEquipment);

        await _service.UpdateAsync(findHistoryEquipment, ct);

        UpdateHistoryEquipmentResponse response = _mapper.Map<UpdateHistoryEquipmentResponse>(findHistoryEquipment);

        await SendOkAsync(response, ct);
    }
}