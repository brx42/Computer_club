using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Services.UserServices.AuthService;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.Account.Login;

public class LoginHandle : Endpoint<LoginRequest, LoginResponse>
{
    private readonly IMapper _mapper;
    private readonly IAuthService _authService;

    public LoginHandle(IMapper mapper, IAuthService authService)
    {
        _mapper = mapper;
        _authService = authService;
    }

    public override void Configure()
    {
        Post("account/login");
        
        Summary(sum => { sum.Summary = "Log in to the service";});
        
        Options(opt => opt.WithTags("Account"));
        
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginRequest request, CancellationToken ct)
    {
        Token? token = await _authService.Login(request);

        LoginResponse response = _mapper.Map<LoginResponse>(token);
        
        if (string.IsNullOrWhiteSpace(response.JwtToken))
        {
            await SendAsync(response, 400, ct);
        }

        await SendOkAsync(response, ct);
    }
}