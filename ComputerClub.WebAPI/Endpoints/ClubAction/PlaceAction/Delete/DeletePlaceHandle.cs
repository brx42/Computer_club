using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.PlaceAction.Delete;

public class DeletePlaceHandle : Endpoint<DeletePlaceRequest, DeletePlaceResponse>
{
    private readonly IBaseClubRepository<Place> _service;

    public DeletePlaceHandle(IBaseClubRepository<Place> service)
    {
        _service = service;
    }

    public override void Configure()
    {
        Delete("club/place/{id}");

        Summary(sum => { sum.Summary = "Place delete"; });
        
        Options(opt => opt.WithTags("Place"));
        
        Policies(Role.SuperAdminAndManager);
    }

    public override async Task HandleAsync(DeletePlaceRequest request, CancellationToken ct)
    {
        Place? findPlace = await _service.GetByIdAsync(request.Id);

        if (findPlace == null)
        {
            await SendErrorsAsync(404, ct);
        }
        
        await _service.DeleteAsync(findPlace, ct);

        await SendOkAsync(new DeletePlaceResponse(), ct);
    }
}