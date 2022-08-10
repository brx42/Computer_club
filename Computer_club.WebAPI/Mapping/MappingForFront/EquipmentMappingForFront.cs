using Computer_club.Data.Models.ClubModels;
using Computer_club.WebAPI.Endpoints.FrontendAction.EquipmentAction.Create;
using Computer_club.WebAPI.Endpoints.FrontendAction.EquipmentAction.Update;

namespace Computer_club.WebAPI.Mapping.MappingForFront;

public class EquipmentMappingForFront : Profile
{
    public EquipmentMappingForFront()
    {
        // Create
        CreateMap<CreateEquipmentForFrontCommand, Equipment>()
            .ForMember(dest => dest.DeviceType, opt => opt.MapFrom(src => src.DeviceType))
            .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.DeviceName))
            .ForMember(dest => dest.DevicePicturePath, opt => opt.MapFrom(src => src.DevicePicturePath))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId));
        
        CreateMap<Equipment, CreateEquipmentForFrontResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.DeviceType, opt => opt.MapFrom(src => src.DeviceType))
            .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.DeviceName))
            .ForMember(dest => dest.DevicePicturePath, opt => opt.MapFrom(src => src.DevicePicturePath))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId));

        
        // Update
        CreateMap<UpdateEquipmentForFrontCommand, Equipment>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.DeviceType, opt => opt.MapFrom(src => src.DeviceType))
            .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.DeviceName))
            .ForMember(dest => dest.DevicePicturePath, opt => opt.MapFrom(src => src.DevicePicturePath))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId));

        CreateMap<Equipment, UpdateEquipmentForFrontResult>()
            .ForMember(dest => dest.DeviceType, opt => opt.MapFrom(src => src.DeviceType))
            .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.DeviceName))
            .ForMember(dest => dest.DevicePicturePath, opt => opt.MapFrom(src => src.DevicePicturePath))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId));
    }
}