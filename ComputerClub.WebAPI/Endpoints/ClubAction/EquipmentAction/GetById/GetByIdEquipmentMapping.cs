using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.EquipmentAction.GetById;

public class GetByIdEquipmentMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Equipment, GetByIdEquipmentResponse>();
    }
}