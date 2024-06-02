using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.HistoryEquipAction.GetById;

public class GetByIdHistoryEquipmentMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<HistoryEquip, GetByIdHistoryEquipmentResponse>();
    }
}