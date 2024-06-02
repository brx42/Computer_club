using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.ProviderAction.Update;

public class UpdateProviderHandle : Endpoint<UpdateProviderRequest, UpdateProviderResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<Provider> _service;

    public UpdateProviderHandle(IMapper mapper, IBaseClubRepository<Provider> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Put("club/provider");

        Summary(sum => { sum.Summary = "Provider update"; });

        Options(opt => opt.WithTags("Provider"));

        Policies(Role.SuperAdminAndManager);
    }

    public override async Task HandleAsync(UpdateProviderRequest request, CancellationToken ct)
    {
        Provider? findProvider = await _service.GetByIdAsync(request.Id);

        if (findProvider == null)
        {
            await SendErrorsAsync(404, ct);
        }

        _mapper.Map(request, findProvider);

        await _service.UpdateAsync(findProvider, ct);

        UpdateProviderResponse response = _mapper.Map<UpdateProviderResponse>(findProvider);

        await SendOkAsync(response, ct);
    }
}