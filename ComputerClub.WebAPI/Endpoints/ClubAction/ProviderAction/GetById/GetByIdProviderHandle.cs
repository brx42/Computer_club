using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.ProviderAction.GetById;

public class GetByIdProviderHandle : Endpoint<GetByIdProviderRequest, GetByIdProviderResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<Provider> _service;

    public GetByIdProviderHandle(IMapper mapper, IBaseClubRepository<Provider> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Get("club/provider/{id}");

        Summary(sum => { sum.Summary = "Provider get"; });

        Options(opt => opt.WithTags("Provider"));

        Policies(Role.SuperAdminAndManager);
    }

    public override async Task HandleAsync(GetByIdProviderRequest request, CancellationToken ct)
    {
        Provider? findProvider = await _service.GetByIdAsync(request.Id);

        GetByIdProviderResponse response = _mapper.Map<GetByIdProviderResponse>(findProvider);

        await SendOkAsync(response, ct);
    }
}