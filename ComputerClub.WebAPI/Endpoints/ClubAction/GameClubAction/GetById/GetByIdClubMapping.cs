using ComputerClub.DAL.Entities;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.GameClubAction.GetById;

public class GetByIdClubMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<GameEntity, GetByIdClubResponse>();
    }
}