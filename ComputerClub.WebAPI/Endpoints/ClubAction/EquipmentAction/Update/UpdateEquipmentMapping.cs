using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.EquipmentAction.Update;

public class UpdateEquipmentMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<UpdateEquipmentRequest, Equipment>();

        config.ForType<Equipment, UpdateEquipmentResponse>();
    }
}