using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.PlaceAction.GetById;

public class GetByIdPlaceHandle : Endpoint<GetByIdPlaceRequest, GetByIdPlaceResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<Place> _service;

    public GetByIdPlaceHandle(IMapper mapper, IBaseClubRepository<Place> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Get("club/place/{id}");

        Summary(sum => { sum.Summary = "Place get"; });
        
        Options(opt => opt.WithTags("Place"));
    }

    public override async Task HandleAsync(GetByIdPlaceRequest request, CancellationToken ct)
    {
        Place? findPlace = await _service.GetByIdAsync(request.Id);
        
        GetByIdPlaceResponse response = _mapper.Map<GetByIdPlaceResponse>(findPlace);

        await SendOkAsync(response, ct);
    }
}