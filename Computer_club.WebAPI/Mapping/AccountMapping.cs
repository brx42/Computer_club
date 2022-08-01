using Computer_club.Data.Entities.UserEntities;
using Computer_club.Data.Models.User;
using Computer_club.Data.Models.UserModels;

namespace Computer_club.WebAPI.Mapping;

public class AccountMapping : Profile
{
    public AccountMapping()
    {
        CreateMap<RegistrationDTO, User>().
            ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Login)).
            ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));
    }
}