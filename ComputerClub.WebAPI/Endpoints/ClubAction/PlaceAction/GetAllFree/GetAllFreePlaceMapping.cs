using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.PlaceAction.GetAllFree;

public class GetAllFreePlaceMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Place, GetAllFreePlaceResponse>();
    }
}