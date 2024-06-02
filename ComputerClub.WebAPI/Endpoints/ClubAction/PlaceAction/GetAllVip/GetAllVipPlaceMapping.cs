using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.PlaceAction.GetAllVip;

public class GetAllVipPlaceMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Place, GetAllVipPlaceResponse>();
    }
}