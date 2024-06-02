using ComputerClub.DAL.Entities;
using Mapster;

namespace ComputerClub.WebAPI.Endpoints.UserAction.GetById;

public class GetByIdUserMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<User, GetByIdUserResponse>();
    }
}