using Computer_club.Data.Models.ClubModels;
using Computer_club.WebAPI.Endpoints.ClubAction.DeviceSetAction.Create;
using Computer_club.WebAPI.Endpoints.ClubAction.DeviceSetAction.GetAll;
using Computer_club.WebAPI.Endpoints.ClubAction.DeviceSetAction.GetById;
using Computer_club.WebAPI.Endpoints.ClubAction.DeviceSetAction.Update;

namespace Computer_club.WebAPI.Mapping;

public class DeviceSetMapping : Profile
{
    public DeviceSetMapping()
    {
        // Create
        CreateMap<CreateSetCommand, DeviceSet>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

        CreateMap<DeviceSet, CreateSetResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        
        
        // GetAll
        CreateMap<DeviceSet, GetAllSetsResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        
        
        //GetById
        CreateMap<DeviceSet, GetByIdSetResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        
        
        //Update
        CreateMap<UpdateSetCommand, DeviceSet>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

        CreateMap<DeviceSet, UpdateSetResult>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}