using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.PlaceAction.GetAllFreePlaceEveryType;

public class GetAllFreePlaceEveryTypeMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Place, PlaceNotReal>();
    }
}