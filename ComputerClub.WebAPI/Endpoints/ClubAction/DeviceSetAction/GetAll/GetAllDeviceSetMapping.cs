using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.DeviceSetAction.GetAll;

public class GetAllDeviceSetMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<DeviceSet, GetAllDeviceSetResponse>();
    }
}