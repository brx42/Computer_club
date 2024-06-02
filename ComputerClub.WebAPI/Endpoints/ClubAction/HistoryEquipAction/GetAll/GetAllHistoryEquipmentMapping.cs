using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.HistoryEquipAction.GetAll;

public class GetAllHistoryEquipmentMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<HistoryEquip, GetAllHistoryEquipmentResponse>();
    }
}