using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.DeviceSetAction.Delete;

public class DeleteDeviceSetHandle : Endpoint<DeleteDeviceSetRequest, DeleteDeviceSetResponse>
{
    private readonly IBaseClubRepository<DeviceSet> _service;

    public DeleteDeviceSetHandle(IBaseClubRepository<DeviceSet> service)
    {
        _service = service;
    }

    public override void Configure()
    {
        Delete("club/place/device-set/{id}");
        
        Summary(sum =>
        {
            sum.Summary = "Device set delete";
        });
        
        Options(opt => opt.WithTags("DeviceSet"));
        
        Policies(Role.SuperAdminAndManager);
    }

    public override async Task HandleAsync(DeleteDeviceSetRequest request, CancellationToken ct)
    {
        DeviceSet? find = await _service.GetByIdAsync(request.Id);
        
        if (find == null)
        {
            await SendErrorsAsync(404, ct);
        }
        
        await _service.DeleteAsync(find, ct);

        await SendOkAsync(new DeleteDeviceSetResponse(), ct);
    }
}