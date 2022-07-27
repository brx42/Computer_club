using Computer_club.WebAPI.Endpoints.RoleAction.Get;
using Microsoft.AspNetCore.Identity;

namespace Computer_club.WebAPI.Mapping;

public class RoleMapping : Profile
{
    public RoleMapping()
    {
        CreateMap<IdentityRole<Guid>, GetByIdRoleResult>().
            ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).
            ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).
            ForMember(dest => dest.ConcurrencyStamp, opt => opt.MapFrom(src => src.ConcurrencyStamp)).
            ForMember(dest => dest.NormalizedName, opt => opt.MapFrom(src => src.NormalizedName));
    }
}