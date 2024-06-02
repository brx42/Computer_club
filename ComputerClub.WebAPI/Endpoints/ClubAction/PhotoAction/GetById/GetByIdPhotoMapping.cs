using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.PhotoAction.GetById;

public class GetByIdPhotoMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<Photo, GetByIdPhotoResponse>();
    }
}