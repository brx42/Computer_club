using ComputerClub.DAL.Entities;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.GameClubAction.GetAll;

public class GetAllClubHandle : Endpoint<GetAllClubRequest, List<GetAllClubResponse>>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<GameEntity> _service;

    public GetAllClubHandle(IMapper mapper, IBaseClubRepository<GameEntity> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Get("clubs");

        Summary(sum => { sum.Summary = "Club get all"; });

        Options(opt => opt.WithTags("Club"));

        Policies(Role.AllAdmins);
    }

    public override async Task HandleAsync(GetAllClubRequest request, CancellationToken ct)
    {
        List<GameEntity> findClubs = await _service.GetAllAsync(request, ct);

        List<GetAllClubResponse> response = _mapper.Map<List<GetAllClubResponse>>(findClubs);

        await SendOkAsync(response, ct);
    }
}