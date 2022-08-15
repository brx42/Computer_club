using Computer_club.Data.Models.ClubModels;
using Computer_club.WebAPI.Endpoints.ClubAction.EquipmentAction.Create;
using Computer_club.WebAPI.Endpoints.ClubAction.EquipmentAction.GetAll;
using Computer_club.WebAPI.Endpoints.ClubAction.EquipmentAction.GetById;
using Computer_club.WebAPI.Endpoints.ClubAction.EquipmentAction.Update;

namespace Computer_club.WebAPI.Mapping.MappingForBack;

public class EquipmentMapping : Profile
{
    public EquipmentMapping()
    {
        // Create
        CreateMap<CreateEquipmentCommand, Equipment>()
            .ForMember(dest => dest.DeviceType, opt => opt.MapFrom(src => src.DeviceType))
            .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.DeviceName))
            .ForMember(dest => dest.DevicePicturePath, opt => opt.MapFrom(src => src.DevicePicturePath))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId));
        
        CreateMap<Equipment, CreateEquipmentResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.DeviceType, opt => opt.MapFrom(src => src.DeviceType))
            .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.DeviceName))
            .ForMember(dest => dest.DevicePicturePath, opt => opt.MapFrom(src => src.DevicePicturePath))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId));

        
        // GetAll
        CreateMap<Equipment, GetAllEquipmentsResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.DeviceType, opt => opt.MapFrom(src => src.DeviceType))
            .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.DeviceName))
            .ForMember(dest => dest.DevicePicturePath, opt => opt.MapFrom(src => src.DevicePicturePath))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId));

        
        // GetById
        CreateMap<Equipment, GetByIdEquipmentResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.DeviceType, opt => opt.MapFrom(src => src.DeviceType))
            .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.DeviceName))
            .ForMember(dest => dest.DevicePicturePath, opt => opt.MapFrom(src => src.DevicePicturePath))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId));

        
        // Update
        CreateMap<UpdateEquipmentCommand, Equipment>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.DeviceType, opt => opt.MapFrom(src => src.DeviceType))
            .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.DeviceName))
            .ForMember(dest => dest.DevicePicturePath, opt => opt.MapFrom(src => src.DevicePicturePath))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId));

        CreateMap<Equipment, UpdateEquipmentResult>()
            .ForMember(dest => dest.DeviceType, opt => opt.MapFrom(src => src.DeviceType))
            .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.DeviceName))
            .ForMember(dest => dest.DevicePicturePath, opt => opt.MapFrom(src => src.DevicePicturePath))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId));
    }
}