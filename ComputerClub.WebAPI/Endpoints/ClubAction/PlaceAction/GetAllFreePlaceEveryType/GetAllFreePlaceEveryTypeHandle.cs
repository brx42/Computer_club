using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.Domain.Options;
using ComputerClub.Domain.Services.ClubServices.PlaceService;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.PlaceAction.GetAllFreePlaceEveryType;

public class GetAllFreePlaceEveryTypeHandle : Endpoint<GetAllFreePlaceEveryTypeRequest, GetAllFreePlaceEveryTypeResponse>
{
    private readonly IMapper _mapper;
    private readonly IPlaceService<Place> _place;

    public GetAllFreePlaceEveryTypeHandle(IMapper mapper, IPlaceService<Place> place)
    {
        _mapper = mapper;
        _place = place;
    }

    public override void Configure()
    {
        Get("club/places/free/every-type");

        Summary(sum => { sum.Summary = "Free places every type get all"; });
        
        Options(opt => opt.WithTags("Place"));
    }

    public override async Task HandleAsync(GetAllFreePlaceEveryTypeRequest request, CancellationToken ct)
    {
        GetAllFreePlaceEveryTypeResponse response = new();
        
        Pagination pagination = new(request.PageNumber, request.PageSize);
        
        List<Place> freePlace = await _place.GetAllFreePlacesForTypeAsync(pagination, request.NameSet);
        
        List<PlaceNotReal> placeNotReals = _mapper.Map<List<PlaceNotReal>>(freePlace);

        response.DeviceSet = request.NameSet;
        response.Places = placeNotReals;

        await SendOkAsync(response, ct);
    }
}