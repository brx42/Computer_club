using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.HistoryEquipAction.Update;

public class UpdateHistoryEquipmentMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<UpdateHistoryEquipmentRequest, HistoryEquip>();

        config.ForType<HistoryEquip, UpdateHistoryEquipmentResponse>();
    }
}