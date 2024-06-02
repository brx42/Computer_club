using ComputerClub.DAL.Models.ClubModels;
using ComputerClub.WebAPI.Endpoints.ClubAction.PlaceAction.GetAll;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.PlaceAction.GetAllBusy;

public class GetAllBusyPlaceMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Place, GetAllPlaceResponse>();
    }
}