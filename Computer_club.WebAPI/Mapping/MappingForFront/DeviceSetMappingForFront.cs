using Computer_club.Data.Models.ClubModels;
using Computer_club.WebAPI.Endpoints.FrontendAction.DeviceSetAction.Create;
using Computer_club.WebAPI.Endpoints.FrontendAction.DeviceSetAction.Update;

namespace Computer_club.WebAPI.Mapping.MappingForFront;

public class DeviceSetMappingForFront : Profile
{
    public DeviceSetMappingForFront()
    {
        // Create
        CreateMap<CreateSetForFrontCommand, DeviceSet>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

        CreateMap<DeviceSet, CreateSetForFrontResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        
        
        //Update
        CreateMap<UpdateSetForFrontCommand, DeviceSet>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

        CreateMap<DeviceSet, UpdateSetForFrontResult>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}