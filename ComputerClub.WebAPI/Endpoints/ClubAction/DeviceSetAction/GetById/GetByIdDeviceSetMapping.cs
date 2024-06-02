using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.DeviceSetAction.GetById;

public class GetByIdDeviceSetMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<DeviceSet, GetByIdDeviceSetResponse>();
    }
}