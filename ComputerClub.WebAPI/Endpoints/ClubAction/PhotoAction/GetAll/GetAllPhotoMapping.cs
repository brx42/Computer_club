using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.PhotoAction.GetAll;

public class GetAllPhotoMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Photo, GetAllPhotoResponse>();
    }
}