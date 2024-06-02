using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.DeviceSetAction.Update;

public class UpdateDeviceSetMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<UpdateDeviceSetRequest, DeviceSet>();

        config.ForType<DeviceSet, UpdateDeviceSetResponse>();
    }
}