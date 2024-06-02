using ComputerClub.DAL.Entities;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.GameClubAction.Create;

public class CreateClubMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<CreateClubRequest, GameEntity>();

        config.ForType<GameEntity, CreateClubResponse>();
    }
}