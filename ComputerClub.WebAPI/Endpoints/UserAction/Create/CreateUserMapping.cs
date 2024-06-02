using ComputerClub.DAL.Entities;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.UserAction.Create;

public class CreateUserMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<CreateUserRequest, User>();

        config.ForType<User, CreateUserResponse>();
    }
}