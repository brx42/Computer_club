using Computer_club.Domain.DTO;
using Computer_club.Domain.Entities;
using Computer_club.Endpoints.UserAction.Create;
using Computer_club.Endpoints.UserAction.Get;
using Computer_club.Endpoints.UserAction.Update;

namespace Computer_club;

public class MainMapper : Profile
{
    public MainMapper()
    {
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



        CreateMap<RegistrationDTO, User>().
            ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Login)).
            ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));
        
    }
}