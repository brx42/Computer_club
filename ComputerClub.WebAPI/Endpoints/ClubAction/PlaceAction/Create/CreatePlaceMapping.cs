using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.PlaceAction.Create;

public class CreatePlaceMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<CreatePlaceRequest, Place>();

        config.ForType<Place, CreatePlaceResponse>();
    }
}