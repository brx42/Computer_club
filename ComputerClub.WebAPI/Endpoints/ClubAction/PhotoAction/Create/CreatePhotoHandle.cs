using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.PhotoAction.Create;

public class CreatePhotoHandle : Endpoint<CreatePhotoRequest, CreatePhotoResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<Photo> _service;

    public CreatePhotoHandle(IMapper mapper, IBaseClubRepository<Photo> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Post("club/photo");

        Summary(sum => { sum.Summary = "Photo create"; });

        Options(opt => opt.WithTags("Photo"));

        Policies(Role.SuperAdminAndManager);
    }

    public override async Task HandleAsync(CreatePhotoRequest request, CancellationToken ct)
    {
        Photo photo = _mapper.Map<Photo>(request);

        Photo addedPhoto = await _service.AddAsync(photo, ct);

        CreatePhotoResponse response = _mapper.Map<CreatePhotoResponse>(addedPhoto);

        await SendOkAsync(response, ct);
    }
}