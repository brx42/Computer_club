using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.EquipmentAction.GetAll;

public class GetAllEquipmentMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Equipment, GetAllEquipmentResponse>();
    }
}