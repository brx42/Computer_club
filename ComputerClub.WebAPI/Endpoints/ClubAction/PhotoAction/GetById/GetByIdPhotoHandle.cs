using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.PhotoAction.GetById;

public class GetByIdPhotoHandle : Endpoint<GetByIdPhotoRequest, GetByIdPhotoResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<Photo> _service;

    public GetByIdPhotoHandle(IMapper mapper, IBaseClubRepository<Photo> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Get("club/photo/{id}");

        Summary(sum => { sum.Summary = "Photo get"; });
        
        Options(opt => opt.WithTags("Photo"));
        
        Policies(Role.AllAdmins);
    }

    public override async Task HandleAsync(GetByIdPhotoRequest request, CancellationToken ct)
    {
        Photo? findPhoto = await _service.GetByIdAsync(request.Id);
        
        GetByIdPhotoResponse response = _mapper.Map<GetByIdPhotoResponse>(findPhoto);

        await SendOkAsync(response, ct);
    }
}