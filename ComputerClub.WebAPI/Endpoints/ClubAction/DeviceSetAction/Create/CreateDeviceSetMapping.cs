using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.DeviceSetAction.Create;

public class CreateDeviceSetMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<CreateDeviceSetRequest, DeviceSet>();

        config.ForType<DeviceSet, CreateDeviceSetResponse>();
    }
}