using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.Domain.Services.ClubServices.PlaceService;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.PlaceAction.GetAllSimple;

public class GetAllSimplePlaceHandle : Endpoint<GetAllSimplePlaceRequest, List<GetAllSimplePlaceResponse>>
{
    private readonly IMapper _mapper;
    private readonly IPlaceService<Place> _service;

    public GetAllSimplePlaceHandle(IMapper mapper, IPlaceService<Place> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Get("club/places/simple");

        Summary(sum => { sum.Summary = "Simple places get all"; });
        
        Options(opt => opt.WithTags("Place"));
    }

    public override async Task HandleAsync(GetAllSimplePlaceRequest request, CancellationToken ct)
    {
        List<Place> findSimpleSeats = await _service.GetAllSimpleSeatsAsync(request, ct);
        
        List<GetAllSimplePlaceResponse> response = _mapper.Map<List<GetAllSimplePlaceResponse>>(findSimpleSeats);

        await SendOkAsync(response, ct);
    }
}