using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.ProviderAction.GetAll;

public class GetAllProviderHandle : Endpoint<GetAllProviderRequest, List<GetAllProviderResponse>>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<Provider> _service;

    public GetAllProviderHandle(IMapper mapper, IBaseClubRepository<Provider> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Get("club/providers");

        Summary(sum => { sum.Summary = "Provider get all"; });

        Options(opt => opt.WithTags("Provider"));

        Policies(Role.SuperAdminAndManager);
    }

    public override async Task HandleAsync(GetAllProviderRequest request, CancellationToken ct)
    {
        List<Provider> findProviders = await _service.GetAllAsync(request, ct);

        List<GetAllProviderResponse> response = _mapper.Map<List<GetAllProviderResponse>>(findProviders);

        await SendOkAsync(response, ct);
    }
}