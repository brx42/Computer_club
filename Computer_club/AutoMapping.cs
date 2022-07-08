using Computer_club.Endpoints.Entities.UserCRUD.Create;
using Computer_club.Endpoints.Entities.UserCRUD.Get;
using Computer_club.Endpoints.Entities.UserCRUD.Update;
using Computer_club.Models.UserModel;

namespace Computer_club;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<CreateUserCommand, User>();
        CreateMap<UpdateUserCommand, User>();

        CreateMap<User, CreateUserResult>();
        CreateMap<User, UpdateUserResult>();
        CreateMap<User, GetUserResult>();
    }
}