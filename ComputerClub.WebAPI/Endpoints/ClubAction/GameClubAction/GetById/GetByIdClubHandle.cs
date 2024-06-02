using ComputerClub.DAL.Entities;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.GameClubAction.GetById;

public class GetByIdClubHandle : Endpoint<GetByIdClubRequest, GetByIdClubResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<GameEntity> _service;

    public GetByIdClubHandle(IMapper mapper, IBaseClubRepository<GameEntity> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Get("club/{id}");

        Summary(sum => { sum.Summary = "Club get"; });
        
        Options(opt => opt.WithTags("Club"));

        Policies(Role.SuperAdminAndManager);
    }

    public override async Task HandleAsync(GetByIdClubRequest request, CancellationToken ct)
    {
        GameEntity? findClub = await _service.GetByIdAsync(request.Id);
        
        GetByIdClubResponse response = _mapper.Map<GetByIdClubResponse>(findClub);

        await SendOkAsync(response, ct);
    }
}