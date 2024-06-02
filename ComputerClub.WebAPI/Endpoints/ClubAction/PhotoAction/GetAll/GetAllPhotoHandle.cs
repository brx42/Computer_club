using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.PhotoAction.GetAll;

public class GetAllPhotoHandle : Endpoint<GetAllPhotoRequest, List<GetAllPhotoResponse>>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<Photo> _service;

    public GetAllPhotoHandle(IMapper mapper, IBaseClubRepository<Photo> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Get("club/photos");

        Summary(sum => { sum.Summary = "Photo get all"; });
        
        Options(opt => opt.WithTags("Photo"));
        
        Policies(Role.AllAdmins);
    }
    
    public override async Task HandleAsync(GetAllPhotoRequest request, CancellationToken ct)
    {
        List<Photo> findPhotos = await _service.GetAllAsync(request, ct);
        
        List<GetAllPhotoResponse> response = _mapper.Map<List<GetAllPhotoResponse>>(findPhotos);

        await SendOkAsync(response, ct);
    }
}