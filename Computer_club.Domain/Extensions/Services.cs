using Computer_club.Data.Database;
using Computer_club.Data.Entities;
using Computer_club.Data.Models.ClubModels;
using Computer_club.Domain.Options;
using Computer_club.Domain.Repositories.BaseClubRepository;
using Computer_club.Domain.Repositories.UserRepository;
using Computer_club.Domain.Services.ClubServices.ClubService;
using Computer_club.Domain.Services.ClubServices.DeviceSetService;
using Computer_club.Domain.Services.ClubServices.HistoryEquipmentService;
using Computer_club.Domain.Services.ClubServices.PlaceService;
using Computer_club.Domain.Services.ClubServices.ScheduleService;
using Computer_club.Domain.Services.UserServices.AuthService;
using Computer_club.Domain.Services.UserServices.RoleService;
using Computer_club.Domain.Services.UserServices.TokenService;
using Microsoft.Extensions.DependencyInjection;

namespace Computer_club.Domain.Extensions;

public static class Services
{
    public static IServiceCollection AddServices(this IServiceCollection service)
    {
        service.AddScoped(typeof(IBaseClubRepository<DeviceSet>), typeof(BaseClubRepository<DeviceSet, AppDbContext>));
        service.AddScoped(typeof(IBaseClubRepository<Equipment>), typeof(BaseClubRepository<Equipment, AppDbContext>));
        service.AddScoped(typeof(IBaseClubRepository<GameClub>), typeof(BaseClubRepository<GameClub, AppDbContext>));
        service.AddScoped(typeof(IBaseClubRepository<HistoryEquip>), typeof(BaseClubRepository<HistoryEquip, AppDbContext>));
        service.AddScoped(typeof(IBaseClubRepository<Photo>), typeof(BaseClubRepository<Photo, AppDbContext>));
        service.AddScoped(typeof(IBaseClubRepository<Place>), typeof(BaseClubRepository<Place, AppDbContext>));
        service.AddScoped(typeof(IBaseClubRepository<Provider>), typeof(BaseClubRepository<Provider, AppDbContext>));
        service.AddScoped(typeof(IBaseClubRepository<Schedule>), typeof(BaseClubRepository<Schedule, AppDbContext>));
        service.AddScoped<ITokenGenerator, TokenGenerator>();
        service.AddScoped<IAuthService, AuthService>();
        service.AddScoped<IUserRepository<User>, UserRepository>();
        service.AddScoped<IRoleService, RoleService>();
        service.AddScoped<IClubService<GameClub>, ClubService>();
        service.AddScoped<IHistoryEquipService<HistoryEquip>, HistoryEquipService>();
        service.AddScoped<IPlaceService<Place>, PlaceService>();
        service.AddScoped<IDeviceSetService, DeviceSetService>();
        service.AddScoped<IScheduleService<Schedule>, ScheduleService>();
        service.AddTransient<ProjectSeed>();


        return service;
    }
}