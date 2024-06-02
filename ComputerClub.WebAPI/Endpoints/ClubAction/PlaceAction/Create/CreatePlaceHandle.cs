using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.PlaceAction.Create;

public class CreatePlaceHandle : Endpoint<CreatePlaceRequest, CreatePlaceResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<Place> _service;

    public CreatePlaceHandle(IMapper mapper, IBaseClubRepository<Place> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Post("club/place");

        Summary(sum => { sum.Summary = "Place create"; });

        Options(opt => opt.WithTags("Place"));

        Policies(Role.SuperAdminAndManager);
    }

    public override async Task HandleAsync(CreatePlaceRequest request, CancellationToken ct)
    {
        Place place = _mapper.Map<Place>(request);

        Place addedPlace = await _service.AddAsync(place, ct);

        CreatePlaceResponse response = _mapper.Map<CreatePlaceResponse>(addedPlace);

        await SendOkAsync(response, ct);
    }
}