using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.PlaceAction.Update;

public class UpdatePlaceHandle : Endpoint<UpdatePlaceRequest, UpdatePlaceResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<Place> _service;

    public UpdatePlaceHandle(IMapper mapper, IBaseClubRepository<Place> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Put("club/place");

        Summary(sum => { sum.Summary = "Place update"; });
        
        Options(opt => opt.WithTags("Place"));
    }

    public override async Task HandleAsync(UpdatePlaceRequest request, CancellationToken ct)
    {
        Place? findPlace = await _service.GetByIdAsync(request.Id);

        if (findPlace == null)
        {
            await SendErrorsAsync(404, ct);
        }
        
        _mapper.Map(request, findPlace);
        
        await _service.UpdateAsync(findPlace, ct);
        
        UpdatePlaceResponse response = _mapper.Map<UpdatePlaceResponse>(findPlace);

        await SendOkAsync(response, ct);
    }
}