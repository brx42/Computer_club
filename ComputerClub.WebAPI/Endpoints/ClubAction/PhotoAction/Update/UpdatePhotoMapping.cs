using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.PhotoAction.Update;

public class UpdatePhotoMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<UpdatePhotoRequest, Photo>();

        config.ForType<Photo, UpdatePhotoResponse>();
    }
}