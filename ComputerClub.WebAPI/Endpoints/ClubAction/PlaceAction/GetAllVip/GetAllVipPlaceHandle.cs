using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.Domain.Services.ClubServices.PlaceService;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.PlaceAction.GetAllVip;

public class GetAllVipPlaceHandle : Endpoint<GetAllVipPlaceRequest, List<GetAllVipPlaceResponse>>
{
    private readonly IMapper _mapper;
    private readonly IPlaceService<Place> _service;

    public GetAllVipPlaceHandle(IMapper mapper, IPlaceService<Place> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Get("club/places/vip");

        Summary(sum => { sum.Summary = "Vip places get all"; });
        
        Options(opt => opt.WithTags("Place"));
    }

    public override async Task HandleAsync(GetAllVipPlaceRequest request, CancellationToken ct)
    {
        List<Place> findVipSeats = await _service.GetAllVipSeatsAsync(request, ct);
        
        List<GetAllVipPlaceResponse> response = _mapper.Map<List<GetAllVipPlaceResponse>>(findVipSeats);

        await SendOkAsync(response, ct);
    }
}