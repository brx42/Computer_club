using ComputerClub.DAL.Entities;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Repositories.UserRepository;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.UserAction.GetById;

public class GetByIdUserHandle : EndpointWithoutRequest<GetByIdUserResponse>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository<User> _repository;

    public GetByIdUserHandle(IMapper mapper, IUserRepository<User> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public override void Configure()
    {
        Get("user/{userId}");

        Summary(sum => { sum.Summary = "Gets a single User"; });

        Options(opt => opt.WithTags("User"));

        Policies(Role.SuperAdmin, Role.ClubAdmin, Role.Manager);
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        Guid userId = Query<Guid>("userId");

        User? user = await _repository.GetByIdAsync(userId);

        if (user == null)
        {
            await SendErrorsAsync(404, ct);
        }

        GetByIdUserResponse response = _mapper.Map<GetByIdUserResponse>(user);

        await SendOkAsync(response, ct);
    }
}