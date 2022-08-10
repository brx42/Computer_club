using Computer_club.WebAPI.Endpoints.BackendAction.RoleAction.AddRole;

namespace Computer_club.WebAPI.Mapping.MappingForBack;

public class RoleMapping : Profile
{
    public RoleMapping()
    {
        CreateMap<AddUserRoleCommand, AddUserRoleResult>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));
    }
}