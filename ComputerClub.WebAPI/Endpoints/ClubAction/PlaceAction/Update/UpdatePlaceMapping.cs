using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.PlaceAction.Update;

public class UpdatePlaceMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<UpdatePlaceRequest, Place>();

        config.ForType<Place, UpdatePlaceResponse>();
    }
}