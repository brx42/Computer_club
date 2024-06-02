using ComputerClub.DAL.Entities;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.GameClubAction.Create;

public class CreateClubHandle : Endpoint<CreateClubRequest, CreateClubResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<GameEntity> _service;

    public CreateClubHandle(IMapper mapper, IBaseClubRepository<GameEntity> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Post("club");

        Summary(sum => { sum.Summary = "Club create"; });
        
        Options(opt => opt.WithTags("Club"));
        
        Policies(Role.SuperAdminAndManager);
    }
    
    public override async Task HandleAsync(CreateClubRequest request, CancellationToken ct)
    {
        GameEntity gameClub = _mapper.Map<GameEntity>(request);
        
        GameEntity addedClub = await _service.AddAsync(gameClub, ct);
        
        CreateClubResponse response = _mapper.Map<CreateClubResponse>(addedClub);

        await SendOkAsync(response, ct);
    }
}