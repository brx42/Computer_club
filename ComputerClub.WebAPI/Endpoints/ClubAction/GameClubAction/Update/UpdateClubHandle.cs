using ComputerClub.DAL.Entities;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.GameClubAction.Update;

public class UpdateClubHandle : Endpoint<UpdateClubRequest, UpdateClubResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<GameEntity> _service;

    public UpdateClubHandle(IMapper mapper, IBaseClubRepository<GameEntity> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Put("club");

        Summary(sum => { sum.Summary = "Club update"; });

        Options(opt => opt.WithTags("Club"));

        Policies(Role.SuperAdminAndManager);
    }

    public override async Task HandleAsync(UpdateClubRequest request, CancellationToken ct)
    {
        GameEntity? findClub = await _service.GetByIdAsync(request.Id);

        if (findClub == null)
        {
            await SendErrorsAsync(404, ct);
        }

        _mapper.Map(request, findClub);

        await _service.UpdateAsync(findClub, ct);

        UpdateClubResponse response = _mapper.Map<UpdateClubResponse>(findClub);

        await SendOkAsync(response, ct);
    }
}