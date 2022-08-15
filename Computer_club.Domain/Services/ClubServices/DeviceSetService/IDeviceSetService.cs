using Computer_club.Data.Models.ClubModels;

namespace Computer_club.Domain.Services.ClubServices.DeviceSetService;

public interface IDeviceSetService
{
     Task<DeviceSet?> GetDeviceSetForFreePlaces(string name);
}