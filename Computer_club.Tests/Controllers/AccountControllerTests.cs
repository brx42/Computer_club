using Computer_club.Data.DTO.Auth;
using Computer_club.Services.UserServices.AuthService;
using Computer_club.WebAPI.Controllers;

namespace Computer_club.Tests.Controllers;

public class AccountControllerTests
{
    private readonly IAuthService _authService;

    public AccountControllerTests(IAuthService authService)
    {
        _authService = authService;
    }

    [Fact]
    public async Task Registration()
    {
        AccountController controller = new AccountController(_authService);
        var result = await controller.Registration(new RegistrationDTO());
        Assert.NotNull(result);
    }

    [Fact]
    public void Login()
    {
        AccountController controller = new AccountController(_authService);
        var result = controller.Login(new LoginDTO());
        Assert.NotNull(result);
    }

    [Fact]
    public void RefreshToken()
    {
        AccountController controller = new AccountController(_authService);
        var result = controller.RefreshToken(string.Empty);
        Assert.NotNull(result);
    }

    [Fact]
    public void Logout()
    {
        AccountController controller = new AccountController(_authService);
        var result = controller.Logout();
        Assert.NotNull(result);
    }
}