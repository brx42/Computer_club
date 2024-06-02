using ComputerClub.DAL.Database;
using ComputerClub.DAL.Entities;
using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.Domain.Options;
using ComputerClub.Domain.Repositories.BaseClubRepository;
using ComputerClub.Domain.Repositories.UserRepository;
using ComputerClub.Domain.Services.ClubServices.ClubService;
using ComputerClub.Domain.Services.ClubServices.DeviceSetService;
using ComputerClub.Domain.Services.ClubServices.HistoryEquipmentService;
using ComputerClub.Domain.Services.ClubServices.PlaceService;
using ComputerClub.Domain.Services.ClubServices.ScheduleService;
using ComputerClub.Domain.Services.UserServices.AuthService;
using ComputerClub.Domain.Services.UserServices.RoleService;
using ComputerClub.Domain.Services.UserServices.TokenService;

namespace ComputerClub.WebAPI.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddServices(this IServiceCollection service)
    {
        service.AddScoped(typeof(IBaseClubRepository<DeviceSet>), typeof(BaseClubRepository<DeviceSet, ApplicationDbContext>));
        service.AddScoped(typeof(IBaseClubRepository<Equipment>), typeof(BaseClubRepository<Equipment, ApplicationDbContext>));
        service.AddScoped(typeof(IBaseClubRepository<GameEntity>), typeof(BaseClubRepository<GameEntity, ApplicationDbContext>));
        service.AddScoped(typeof(IBaseClubRepository<HistoryEquip>), typeof(BaseClubRepository<HistoryEquip, ApplicationDbContext>));
        service.AddScoped(typeof(IBaseClubRepository<Photo>), typeof(BaseClubRepository<Photo, ApplicationDbContext>));
        service.AddScoped(typeof(IBaseClubRepository<Place>), typeof(BaseClubRepository<Place, ApplicationDbContext>));
        service.AddScoped(typeof(IBaseClubRepository<Provider>), typeof(BaseClubRepository<Provider, ApplicationDbContext>));
        service.AddScoped(typeof(IBaseClubRepository<Schedule>), typeof(BaseClubRepository<Schedule, ApplicationDbContext>));
        service.AddScoped<ITokenGenerator, TokenGenerator>();
        service.AddTransient<IAuthService, AuthService>();
        service.AddTransient<IUserRepository<User>, UserRepository>();
        service.AddTransient<IRoleService, RoleService>();
        service.AddScoped<IClubService<GameEntity>, ClubService>();
        service.AddScoped<IHistoryEquipService<HistoryEquip>, HistoryEquipService>();
        service.AddScoped<IPlaceService<Place>, PlaceService>();
        service.AddScoped<IDeviceSetService, DeviceSetService>();
        service.AddScoped<IScheduleService<Schedule>, ScheduleService>();
        service.AddTransient<ProjectSeed>();

        return service;
    }
}