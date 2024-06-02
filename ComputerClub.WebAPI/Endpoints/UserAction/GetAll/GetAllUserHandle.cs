using ComputerClub.DAL.Entities;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.UserRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.UserAction.GetAll;

public class GetAllUserHandle : Endpoint<GetAllUserRequest, List<GetAllUserResponse>>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository<User> _service;

    public GetAllUserHandle(IMapper mapper, IUserRepository<User> service)
    {
        _mapper = mapper;
        _service = service;
    }

    public override void Configure()
    {
        Get("users");
        
        Summary(sum => { sum.Summary = "Get a list of all Users";});
        
        Options(opt => opt.WithTags("User"));

        Policies(Role.SuperAdmin, Role.ClubAdmin, Role.Manager);
    }

    public override async Task HandleAsync(GetAllUserRequest request,CancellationToken ct)
    {
        List<User> findUsers = await _service.GetAllAsync(request, ct);

        List<GetAllUserResponse> response = _mapper.Map<List<GetAllUserResponse>>(findUsers);

        await SendOkAsync(response, ct);
    }
}