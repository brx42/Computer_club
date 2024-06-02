using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.PlaceAction.GetAll;

public class GetAllPlaceHandle : Endpoint<GetAllPlaceRequest, List<GetAllPlaceResponse>>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<Place> _service;

    public GetAllPlaceHandle(IMapper mapper, IBaseClubRepository<Place> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Get("club/places");

        Summary(sum => { sum.Summary = "Places get all"; });
        
        Options(opt => opt.WithTags("Place"));
        
        Policies(Role.AllAdmins);
    }

    public override async Task HandleAsync(GetAllPlaceRequest request, CancellationToken ct)
    {
        List<Place> findPlace = await _service.GetAllAsync(request, ct);
        
        List<GetAllPlaceResponse> response = _mapper.Map<List<GetAllPlaceResponse>>(findPlace);

        await SendOkAsync(response, ct);
    }
}