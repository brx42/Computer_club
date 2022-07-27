using Computer_club.Data.DTO.Auth;
using Computer_club.Data.Entities.User;
using Computer_club.WebAPI.Endpoints.RoleAction.Get;
using Computer_club.WebAPI.Endpoints.UserAction.Create;
using Computer_club.WebAPI.Endpoints.UserAction.Get;
using Computer_club.WebAPI.Endpoints.UserAction.Update;
using Microsoft.AspNetCore.Identity;

namespace Computer_club.WebAPI.Mapping;

public class UserMapper : Profile
{
    public UserMapper()
    {
        // User endpoints
        CreateMap<CreateUserCommand, User>().
            ForMember(dest => dest.UserName,opt => opt.MapFrom(src => src.Login)).
            ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));
        
        CreateMap<UpdateUserCommand, User>();

        CreateMap<User, CreateUserResult>().
            ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.UserName)).
            ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash));
        
        CreateMap<User, GetByIdUserResult>().
            ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.UserName)).
            ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash));
        
        CreateMap<User, UpdateUserResult>().
            ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.UserName)).
            ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash));


        
        // Role endpoints
        CreateMap<IdentityRole<Guid>, GetByIdRoleResult>().
            ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).
            ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).
            ForMember(dest => dest.ConcurrencyStamp, opt => opt.MapFrom(src => src.ConcurrencyStamp)).
            ForMember(dest => dest.NormalizedName, opt => opt.MapFrom(src => src.NormalizedName));
        
        
        
        // Account controller
        CreateMap<RegistrationDTO, User>().
            ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Login)).
            ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));
    }
}