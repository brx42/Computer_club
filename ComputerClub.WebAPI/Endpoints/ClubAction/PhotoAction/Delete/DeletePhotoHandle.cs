using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.PhotoAction.Delete;

public class DeletePhotoHandle : Endpoint<DeletePhotoRequest, DeletePhotoResponse>
{
    private readonly IBaseClubRepository<Photo> _service;

    public DeletePhotoHandle(IBaseClubRepository<Photo> service)
    {
        _service = service;
    }

    public override void Configure()
    {
        Delete("club/photo/{id}");

        Summary(sum => { sum.Summary = "Photo delete"; });
        
        Options(opt => opt.WithTags("Photo"));
        
        Policies(Role.SuperAdminAndManager);
    }

    public override async Task HandleAsync(DeletePhotoRequest request, CancellationToken ct)
    {
        Photo? findPhoto = await _service.GetByIdAsync(request.Id);

        if (findPhoto == null)
        {
            await SendErrorsAsync(404, ct);
        }
        
        await _service.DeleteAsync(findPhoto, ct);

        await SendOkAsync(new DeletePhotoResponse(), ct);
    }
}