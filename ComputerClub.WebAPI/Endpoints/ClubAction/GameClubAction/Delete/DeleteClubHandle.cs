using ComputerClub.DAL.Entities;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.GameClubAction.Delete;

public class DeleteClubHandle : Endpoint<DeleteClubRequest, DeleteClubResponse>
{
    private readonly IBaseClubRepository<GameEntity> _service;

    public DeleteClubHandle(IBaseClubRepository<GameEntity> service)
    {
        _service = service;
    }

    public override void Configure()
    {
        Delete("club/{id}");

        Summary(sum => { sum.Summary = "Club delete"; });
        
        Options(opt => opt.WithTags("Club"));
        
        Policies(Role.SuperAdminAndManager);
    }
    
    public override async Task HandleAsync(DeleteClubRequest request, CancellationToken ct)
    {
        GameEntity? findClub = await _service.GetByIdAsync(request.Id);

        if (findClub == null)
        {
            await SendErrorsAsync(404, ct);
        }
        
        await _service.DeleteAsync(findClub, ct);

        await SendOkAsync(new DeleteClubResponse(), ct);
    }
}