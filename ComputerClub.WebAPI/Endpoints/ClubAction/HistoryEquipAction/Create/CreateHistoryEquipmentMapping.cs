using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.HistoryEquipAction.Create;

public class CreateHistoryEquipmentMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<CreateHistoryEquipmentRequest, HistoryEquip>();

        config.ForType<HistoryEquip, CreateHistoryEquipmentResponse>();
    }
}