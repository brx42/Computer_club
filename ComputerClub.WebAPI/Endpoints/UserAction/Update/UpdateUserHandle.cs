using ComputerClub.DAL.Entities;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.UserRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.UserAction.Update;

public class UpdateUserHandle : Endpoint<UpdateUserRequest, UpdateUserResponse>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository<User> _service;

    public UpdateUserHandle(IMapper mapper, IUserRepository<User> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Put("user");

        Summary(sum => { sum.Summary = "Updates a User"; });
        
        Options(opt => opt.WithTags("User"));

        Policies(Role.SuperAdmin, Role.ClubAdmin, Role.Manager);
    }

    public override async Task HandleAsync(UpdateUserRequest request, CancellationToken ct)
    {
        User? user = await _service.GetByIdAsync(request.Id);

        if (user == null)
        {
            await SendErrorsAsync(404, ct);
        }
        
        _mapper.Map(request, user);
        
        await _service.UpdateAsync(user, ct);
        
        UpdateUserResponse response = _mapper.Map<UpdateUserResponse>(user);

        await SendOkAsync(response, ct);
    }
}