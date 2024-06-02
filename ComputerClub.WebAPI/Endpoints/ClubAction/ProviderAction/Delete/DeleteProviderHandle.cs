using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.ProviderAction.Delete;

public class DeleteProviderHandle : Endpoint<DeleteProviderRequest, DeleteProviderResponse>
{
    private readonly IBaseClubRepository<Provider> _service;

    public DeleteProviderHandle(IBaseClubRepository<Provider> service)
    {
        _service = service;
    }

    public override void Configure()
    {
        Delete("club/provider/{id}");

        Summary(sum => { sum.Summary = "Provider delete"; });

        Options(opt => opt.WithTags("Provider"));

        Policies(Role.SuperAdminAndManager);
    }

    public override async Task HandleAsync(DeleteProviderRequest request, CancellationToken ct)
    {
        Provider? findProvider = await _service.GetByIdAsync(request.Id);

        if (findProvider == null)
        {
            await SendErrorsAsync(404, ct);
        }

        await _service.DeleteAsync(findProvider, ct);

        await SendOkAsync(new DeleteProviderResponse(), ct);
    }
}