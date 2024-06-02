using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.EquipmentAction.Create;

public class CreateEquipmentMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<CreateEquipmentRequest, Equipment>();

        config.ForType<Equipment, CreateEquipmentResponse>();
    }
}