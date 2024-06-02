using ComputerClub.Domain.Services.UserServices.AuthService;
using FastEndpoints;

namespace ComputerClub.WebAPI.Endpoints.Account.Logout;

public class LogoutHandle : EndpointWithoutRequest
{
    private readonly IAuthService _authService;

    public LogoutHandle(IAuthService authService)
    {
        _authService = authService;
    }

    public override void Configure()
    {
        Get("account/logout");

        Summary(sum => { sum.Summary = "Log out"; });
        
        Options(opt => opt.WithTags("Account"));

        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await _authService.Logout();

        await SendOkAsync(ct);
    }
}