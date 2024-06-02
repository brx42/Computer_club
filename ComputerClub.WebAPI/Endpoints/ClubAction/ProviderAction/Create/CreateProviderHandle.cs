using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.ProviderAction.Create;

public class CreateProviderHandle : Endpoint<CreateProviderRequest, CreateProviderResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<Provider> _service;

    public CreateProviderHandle(IMapper mapper, IBaseClubRepository<Provider> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Post("club/provider");

        Summary(sum => { sum.Summary = "Provider create"; });

        Options(opt => opt.WithTags("Provider"));

        Policies(Role.SuperAdminAndManager);
    }

    public override async Task HandleAsync(CreateProviderRequest request, CancellationToken ct)
    {
        Provider provider = _mapper.Map<Provider>(request);

        Provider addedProvider = await _service.AddAsync(provider, ct);

        CreateProviderResponse response = _mapper.Map<CreateProviderResponse>(addedProvider);

        await SendOkAsync(response, ct);
    }
}