using Computer_club.Data.Entities.ClubEntities;
using Computer_club.Data.Entities.UserEntities;
using Computer_club.Data.Models.ClubModels;
using Computer_club.Services.Services.ClubServices.ClubService;
using Computer_club.Services.Services.ClubServices.DeviceSetService;
using Computer_club.Services.Services.ClubServices.EquipmentService;
using Computer_club.Services.Services.ClubServices.HistoryEquipmentService;
using Computer_club.Services.Services.ClubServices.PhotoService;
using Computer_club.Services.Services.ClubServices.PlaceService;
using Computer_club.Services.Services.ClubServices.ProviderService;
using Computer_club.Services.Services.ClubServices.ScheduleService;
using Computer_club.Services.Services.UserServices.AuthService;
using Computer_club.Services.Services.UserServices.RoleService;
using Computer_club.Services.Services.UserServices.TokenService;
using Computer_club.Services.Services.UserServices.UserService;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Computer_club.Services.Extensions;

public static class Services
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
        service.AddScoped<IScheduleService<Schedule>, ScheduleService>();
        service.AddScoped<IPhotoService<Photo>, PhotoService>();
        service.AddScoped<IPlaceService<Place>, PlaceService>();
        service.AddScoped<IDeviceSetService<DeviceSet>, DeviceSetService>();
        service.AddScoped<IEquipmentService<Equipment>, EquipmentService>();

        return service;
    }
}