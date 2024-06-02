using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.PlaceAction.GetAllSimple;

public class GetAllSimplePlaceMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Place, GetAllSimplePlaceResponse>();
    }
}