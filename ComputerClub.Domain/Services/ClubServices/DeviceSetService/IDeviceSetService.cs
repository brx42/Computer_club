using ComputerClub.DAL.Models.ClubModels;

namespace ComputerClub.Domain.Services.ClubServices.DeviceSetService;

public interface IDeviceSetService
{
     Task<DeviceSet?> GetDeviceSetForFreePlaces(string name);
}