using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.ScheduleAction.GetById;

public class GetByIdScheduleHandle : Endpoint<GetByIdScheduleRequest, GetByIdScheduleResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<Schedule> _service;

    public GetByIdScheduleHandle(IMapper mapper, IBaseClubRepository<Schedule> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Get("club/schedule/{id}");

        Summary(sum => { sum.Summary = "Schedule get"; });

        Options(opt => opt.WithTags("Schedule"));
    }

    public override async Task HandleAsync(GetByIdScheduleRequest request, CancellationToken ct)
    {
        Schedule? findSchedule = await _service.GetByIdAsync(request.Id);

        GetByIdScheduleResponse response = _mapper.Map<GetByIdScheduleResponse>(findSchedule);

        await SendOkAsync(response, ct);
    }
}