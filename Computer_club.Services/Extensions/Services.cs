using Computer_club.Data.Entities.ClubEntities;
using Computer_club.Data.Entities.UserEntities;
using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Services.ClubServices.ClubService;
using Computer_club.Services.Services.ClubServices.HistoryEquipmentService;
using Computer_club.Services.Services.ClubServices.PhotoService;
using Computer_club.Services.Services.ClubServices.ProviderService;
using Computer_club.Services.Services.UserServices.AuthService;
using Computer_club.Services.Services.UserServices.RoleService;
using Computer_club.Services.Services.UserServices.TokenService;
using Computer_club.Services.Services.UserServices.UserService;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Computer_club.Services.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection service)
    {
        service.AddScoped<ITokenGenerator, TokenGenerator>();
        service.AddScoped<IAuthService, AuthService>();
        service.AddScoped<IUserService<User>, UserService>();
        service.AddScoped<IRoleService<IdentityRole<Guid>>, RoleService>();
        service.AddScoped<IClubService<GameClub>, ClubService>();
        service.AddScoped<IProviderService<Provider>, ProviderService>();
        service.AddScoped<IHistoryEquipService<HistoryEquip>, HistoryEquipService>();
        service.AddScoped<IPhotoService<Photo>, PhotoService>();

        return service;
    }
}