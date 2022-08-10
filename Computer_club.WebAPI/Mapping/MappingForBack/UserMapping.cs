using Computer_club.Data.Entities.UserEntities;
using Computer_club.WebAPI.Endpoints.BackendAction.UserAction.Create;
using Computer_club.WebAPI.Endpoints.BackendAction.UserAction.GetAll;
using Computer_club.WebAPI.Endpoints.BackendAction.UserAction.GetById;
using Computer_club.WebAPI.Endpoints.BackendAction.UserAction.Update;

namespace Computer_club.WebAPI.Mapping.MappingForBack;

public class UserMapping : Profile
{
    public UserMapping()
    {
        // Create
        CreateMap<CreateUserCommand, User>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Login))
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));
        
        CreateMap<User, CreateUserResult>()
            .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash));

        
        // GetAll
        CreateMap<User, GetAllUsersResult>();
        
        
        // GetById
        CreateMap<User, GetByIdUserResult>()
            .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash));

        
        // Update
        CreateMap<UpdateUserCommand, User>();

        CreateMap<User, UpdateUserResult>()
            .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash)); 
    }
}