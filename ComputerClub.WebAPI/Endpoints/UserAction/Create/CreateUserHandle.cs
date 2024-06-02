using ComputerClub.DAL.Entities;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.UserRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.UserAction.Create;

public class CreateUserHandle : Endpoint<CreateUserRequest, CreateUserResponse>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository<User> _repository;

    public CreateUserHandle(IMapper mapper, IUserRepository<User> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public override void Configure()
    {
        Post("user");
        
        Summary(sum => { sum.Summary = "Creates a new User";});
        
        Options(opt => opt.WithTags("User"));
        
        Policies(Role.SuperAdmin, Role.ClubAdmin, Role.Manager);
    }

    public override async Task HandleAsync(CreateUserRequest request, CancellationToken ct)
    {
        User user = _mapper.Map<User>(request);
        
        await _repository.AddAsync(user, ct);

        CreateUserResponse response = _mapper.Map<CreateUserResponse>(user);

        await SendOkAsync(response, ct);
    }
}