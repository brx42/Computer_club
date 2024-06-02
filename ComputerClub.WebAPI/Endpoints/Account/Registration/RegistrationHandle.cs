using ComputerClub.DAL.Entities;
using ComputerClub.Domain.Services.UserServices.AuthService;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.Account.Registration;

public class RegistrationHandle : Endpoint<RegistrationRequest>
{
    private readonly IMapper _mapper;
    private readonly IAuthService _authService;

    public RegistrationHandle(IMapper mapper, IAuthService authService)
    {
        _authService = authService;
        _mapper = mapper;
    }

    public override void Configure()
    {
        Post("account/registration");

        Summary(sum => { sum.Summary = "Registers a new account"; });

        Options(opt => opt.WithTags("Account"));

        AllowAnonymous();
    }

    public override async Task HandleAsync(RegistrationRequest request, CancellationToken ct)
    {
        User user = _mapper.Map<User>(request);

        bool response = await _authService.Registration(user);

        if (response)
        {
            await SendErrorsAsync(400, ct);
        }

        await SendOkAsync(ct);
    }
}