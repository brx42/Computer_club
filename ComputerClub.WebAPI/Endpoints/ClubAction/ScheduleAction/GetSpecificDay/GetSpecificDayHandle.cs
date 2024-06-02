using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.Domain.Services.ClubServices.ScheduleService;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.ScheduleAction.GetSpecificDay;

public class GetSpecificDayHandle : Endpoint<GetSpecificDayRequest, GetSpecificDayResponse>
{
    private readonly IMapper _mapper;
    private readonly IScheduleService<Schedule> _service;

    public GetSpecificDayHandle(IMapper mapper, IScheduleService<Schedule> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Get("club/schedule/specific-day");
        
        Summary(sum => { sum.Summary = "Schedule get specific day";});
        
        Options(opt => opt.WithTags("Schedule"));
    }

    public override async Task HandleAsync(GetSpecificDayRequest request, CancellationToken ct)
    {
        Schedule? findSchedule = await _service.GetTheScheduleOfASpecificDayAsync(request.Day, request.GameClubId);

        GetSpecificDayResponse response = _mapper.Map<GetSpecificDayResponse>(findSchedule);

        await SendOkAsync(response, ct);
    }
}