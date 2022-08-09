using Computer_club.WebAPI.Endpoints.RoleAction.AddRole;

namespace Computer_club.WebAPI.Mapping;

public class RoleMapping : Profile
{
    public RoleMapping()
    {
        CreateMap<AddRoleCommand, AddRoleResult>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));
    }
}