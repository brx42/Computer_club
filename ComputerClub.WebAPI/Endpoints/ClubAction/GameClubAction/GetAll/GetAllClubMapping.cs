using ComputerClub.DAL.Entities;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.GameClubAction.GetAll;

public class GetAllClubMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<GameEntity, GetAllClubResponse>();
    }
}