using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.EquipmentAction.Delete;

public class DeleteEquipmentHandle : Endpoint<DeleteEquipmentRequest, DeleteEquipmentResponse>
{
    private readonly IBaseClubRepository<Equipment> _service;

    public DeleteEquipmentHandle(IBaseClubRepository<Equipment> service)
    {
        _service = service;
    }

    public override void Configure()
    {
        Delete("club/place/device-set/equipment/{id}");
        
        Summary(sum => { sum.Summary = "Equipment delete";});
        
        Options(opt => opt.WithTags("Equipment"));
        
        Policies(Role.SuperAdminAndManager);
    }

    public override async Task HandleAsync(DeleteEquipmentRequest request, CancellationToken ct)
    {
        Equipment? findEquipment = await _service.GetByIdAsync(request.Id);

        if (findEquipment == null)
        {
            await SendErrorsAsync(404, ct);
        }
        
        await _service.DeleteAsync(findEquipment, ct);

        await SendOkAsync(new DeleteEquipmentResponse(), ct);
    }
}