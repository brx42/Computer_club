using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.PhotoAction.Update;

public class UpdatePhotoHandle : Endpoint<UpdatePhotoRequest, UpdatePhotoResponse>
{
    private readonly IMapper _mapper;
    private readonly IBaseClubRepository<Photo> _service;

    public UpdatePhotoHandle(IMapper mapper, IBaseClubRepository<Photo> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Put("club/photo");

        Summary(sum => { sum.Summary = "Photo update"; });

        Options(opt => opt.WithTags("Photo"));

        Policies(Role.SuperAdminAndManager);
    }

    public override async Task HandleAsync(UpdatePhotoRequest request, CancellationToken ct)
    {
        Photo? findPhoto = await _service.GetByIdAsync(request.Id);

        if (findPhoto == null)
        {
            await SendErrorsAsync(404, ct);
        }

        _mapper.Map(request, findPhoto);

        await _service.UpdateAsync(findPhoto, ct);

        UpdatePhotoResponse response = _mapper.Map<UpdatePhotoResponse>(findPhoto);

        await SendOkAsync(response, ct);
    }
}