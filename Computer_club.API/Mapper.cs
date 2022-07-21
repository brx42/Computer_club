using Computer_club.Domain.Entities;
using Computer_club.Endpoints.UserCRUD.Create;
using Computer_club.Endpoints.UserCRUD.Get;
using Computer_club.Endpoints.UserCRUD.Update;

namespace Computer_club;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<CreateUserCommand, User>().
            ForMember(dest => dest.UserName, opt
            => opt.MapFrom(src => src.Login)).
            ForMember(dest => dest.PasswordHash, opt
            => opt.MapFrom(src => src.Password));
        
        CreateMap<UpdateUserCommand, User>();

        CreateMap<User, CreateUserResult>().
            ForMember(dest => dest.Login, opt 
            => opt.MapFrom(src => src.UserName)).
            ForMember(dest => dest.Password, opt 
            => opt.MapFrom(src => src.PasswordHash));
        
        CreateMap<User, GetByIdUserResult>().
            ForMember(dest => dest.Login, opt
            => opt.MapFrom(src => src.UserName)).
            ForMember(dest => dest.Password, opt 
            => opt.MapFrom(src => src.PasswordHash));
        
        CreateMap<User, UpdateUserResult>().
            ForMember(dest => dest.Login, opt
            => opt.MapFrom(src => src.UserName)).
            ForMember(dest => dest.Password, opt
            => opt.MapFrom(src => src.PasswordHash));
    }
}