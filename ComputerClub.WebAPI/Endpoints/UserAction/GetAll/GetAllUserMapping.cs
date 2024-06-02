using ComputerClub.DAL.Entities;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.UserAction.GetAll;

public class GetAllUserMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<User, GetAllUserResponse>();
    }
}