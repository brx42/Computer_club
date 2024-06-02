using ComputerClub.DAL.Models.ClubModels;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.PhotoAction.Create;

public class CreatePhotoMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<CreatePhotoRequest, Photo>();

        config.ForType<Photo, CreatePhotoResponse>();
    }
}