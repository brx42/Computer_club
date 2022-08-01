using Computer_club.Data.Entities.UserEntities;
using Computer_club.WebAPI.Endpoints.RoleAction.Get;
using Computer_club.WebAPI.Endpoints.UserAction.Create;
using Computer_club.WebAPI.Endpoints.UserAction.Get;
using Computer_club.WebAPI.Endpoints.UserAction.Update;
using Microsoft.AspNetCore.Identity;

namespace Computer_club.WebAPI.Mapping;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<CreateUserCommand, User>().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Login))
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));

        
        CreateMap<UpdateUserCommand, User>();

        
        CreateMap<User, CreateUserResult>().ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash));

        
        CreateMap<User, GetByIdUserResult>().ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash));

        
        CreateMap<User, UpdateUserResult>().ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash));
    }
}