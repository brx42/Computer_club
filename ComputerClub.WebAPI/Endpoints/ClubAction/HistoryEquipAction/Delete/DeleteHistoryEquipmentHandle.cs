using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.HistoryEquipAction.Delete;

public class DeleteHistoryEquipmentHandle : Endpoint<DeleteHistoryEquipmentRequest, DeleteHistoryEquipmentResponse>
{
    private readonly IBaseClubRepository<HistoryEquip> _service;

    public DeleteHistoryEquipmentHandle(IBaseClubRepository<HistoryEquip> service)
    {
        _service = service;
    }

    public override void Configure()
    {
        Delete("club/history-equipment/{id}");

        Summary(sum => { sum.Summary = "History equipment delete"; });

        Options(opt => opt.WithTags("HistoryEquipment"));

        Policies(Role.SuperAdminAndManager);
    }

    public override async Task HandleAsync(DeleteHistoryEquipmentRequest request, CancellationToken ct)
    {
        HistoryEquip? findHistoryEquipment = await _service.GetByIdAsync(request.Id);

        if (findHistoryEquipment == null)
        {
            await SendErrorsAsync(404, ct);
        }

        await _service.DeleteAsync(findHistoryEquipment, ct);

        await SendOkAsync(new DeleteHistoryEquipmentResponse(), ct);
    }
}