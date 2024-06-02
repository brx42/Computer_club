using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.Domain.Services.ClubServices.PlaceService;
using ComputerClub.WebAPI.Endpoints.ClubAction.PlaceAction.GetAll;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.PlaceAction.GetAllBusy;

public class GetAllBusyPlaces : Endpoint<GetAllPlaceRequest, List<GetAllBusyPlaceResponse>>
{
    private readonly IMapper _mapper;
    private readonly IPlaceService<Place> _place;

    public GetAllBusyPlaces(IMapper mapper, IPlaceService<Place> place)
    {
        _mapper = mapper;
        _place = place;
    }

    public override void Configure()
    {
        Get("club/places/busy");

        Summary(sum => { sum.Summary = "Busy places get all"; });
        
        Options(opt => opt.WithTags("Place"));
    }

    public override async Task HandleAsync(GetAllPlaceRequest request, CancellationToken ct)
    {
        List<Place> findBusyPlaces = await _place.GetAllBusySeatsAsync(request, ct);
        
        List<GetAllBusyPlaceResponse> response = _mapper.Map<List<GetAllBusyPlaceResponse>>(findBusyPlaces);

        await SendOkAsync(response, ct);
    }
}