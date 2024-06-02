using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.Domain.Services.ClubServices.PlaceService;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.PlaceAction.GetAllFree;

public class GetAllFreePlacesForFront : Endpoint<GetAllFreePlaceRequest, List<GetAllFreePlaceResponse>>
{
    private readonly IMapper _mapper;
    private readonly IPlaceService<Place> _service;

    public GetAllFreePlacesForFront(IMapper mapper, IPlaceService<Place> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Get("club/places/free");

        Summary(sum => { sum.Summary = "Free places get all"; });
        
        Options(opt => opt.WithTags("Place"));
    }

    public override async Task HandleAsync(GetAllFreePlaceRequest request, CancellationToken ct)
    {
        List<Place> findFreePlaces = await _service.GetAllFreeSeatsAsync(request, ct);
        
        List<GetAllFreePlaceResponse> response = _mapper.Map<List<GetAllFreePlaceResponse>>(findFreePlaces);

        await SendOkAsync(response, ct);
    }
}