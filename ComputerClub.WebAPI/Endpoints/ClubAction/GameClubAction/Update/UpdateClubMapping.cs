using ComputerClub.DAL.Entities;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.GameClubAction.Update;

public class UpdateClubMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<UpdateClubRequest, GameEntity>();

        config.ForType<GameEntity, UpdateClubResponse>();
    }
}