using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.ScheduleAction.GetAll;

public class GetAllScheduleHandle : Endpoint<GetAllScheduleRequest, List<GetAllScheduleResponse>>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<Schedule> _service;

    public GetAllScheduleHandle(IMapper mapper, IBaseClubRepository<Schedule> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Get("club/schedules");

        Summary(sum => { sum.Summary = "Schedule get all"; });

        Options(opt => opt.WithTags("Schedule"));
    }

    public override async Task HandleAsync(GetAllScheduleRequest request, CancellationToken ct)
    {
        List<Schedule> findSchedules = await _service.GetAllAsync(request, ct);

        List<GetAllScheduleResponse> response = _mapper.Map<List<GetAllScheduleResponse>>(findSchedules);

        await SendOkAsync(response, ct);
    }
}