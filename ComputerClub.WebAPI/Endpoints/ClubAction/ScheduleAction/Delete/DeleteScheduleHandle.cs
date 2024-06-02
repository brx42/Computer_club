using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.ScheduleAction.Delete;

public class DeleteScheduleHandle : Endpoint<DeleteScheduleRequest, DeleteScheduleResponse>
{
    private readonly IBaseClubRepository<Schedule> _service;

    public DeleteScheduleHandle(IBaseClubRepository<Schedule> service)
    {
        _service = service;
    }

    public override void Configure()
    {
        Delete("club/schedule/{id}");

        Summary(sum => { sum.Summary = "Schedule delete"; });

        Options(opt => opt.WithTags("Schedule"));

        Policies(Role.SuperAdminAndManager);
    }

    public override async Task HandleAsync(DeleteScheduleRequest request, CancellationToken ct)
    {
        Schedule? findSchedule = await _service.GetByIdAsync(request.Id);

        if (findSchedule == null)
        {
            await SendErrorsAsync(404, ct);
        }

        await _service.DeleteAsync(findSchedule, ct);

        await SendOkAsync(new DeleteScheduleResponse(), ct);
    }
}