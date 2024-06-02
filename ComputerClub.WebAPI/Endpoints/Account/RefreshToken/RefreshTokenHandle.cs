using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Services.UserServices.AuthService;
using FastEndpoints;
using IMapper = MapsterMapper.IMapper;

namespace ComputerClub.WebAPI.Endpoints.Account.RefreshToken;

public class RefreshTokenHandle : Endpoint<RefreshTokenRequest, RefreshTokenResponse>
{
    private readonly IMapper _mapper;
    private readonly IAuthService _authService;

    public RefreshTokenHandle(IMapper mapper, IAuthService authService)
    {
        _mapper = mapper;
        _authService = authService;
    }

    public override void Configure()
    {
        Post("account/refresh-token");
        
        Summary(sum => { sum.Summary = "Token update";});
        
        Options(opt => opt.WithTags("Account"));
        
        AllowAnonymous();
    }

    public override async Task HandleAsync(RefreshTokenRequest request, CancellationToken ct)
    {
        Token token = await _authService.RefreshToken(request.Token);

        RefreshTokenResponse response = _mapper.Map<RefreshTokenResponse>(token);

        if (string.IsNullOrWhiteSpace(response.JwtToken))
        {
            await SendAsync(response, 400, ct);
        }

        await SendOkAsync(response, ct);
    }
}