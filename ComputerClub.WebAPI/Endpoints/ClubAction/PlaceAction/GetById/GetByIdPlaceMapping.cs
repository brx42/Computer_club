using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.PlaceAction.GetById;

public class GetByIdPlaceMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Place, GetByIdPlaceResponse>();
    }
}