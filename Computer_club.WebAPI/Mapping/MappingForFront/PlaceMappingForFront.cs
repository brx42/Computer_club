using Computer_club.Data.Models.ClubModels;
using Computer_club.WebAPI.Endpoints.FrontendAction.PlaceAction.Create;
using Computer_club.WebAPI.Endpoints.FrontendAction.PlaceAction.Update;

namespace Computer_club.WebAPI.Mapping.MappingForFront;

public class PlaceMappingForFront : Profile
{
    public PlaceMappingForFront()
    {
        // Create
        CreateMap<CreatePlaceForFrontCommand, Place>()
            .ForMember(dest => dest.IsVip, opt => opt.MapFrom(src => src.IsVip))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));
        
        CreateMap<Place, CreatePlaceForFrontResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.IsVip, opt => opt.MapFrom(src => src.IsVip))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        
        // Update
        CreateMap<UpdatePlaceForFrontCommand, Place>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.IsVip, opt => opt.MapFrom(src => src.IsVip))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        CreateMap<Place, UpdatePlaceForFrontResult>()
            .ForMember(dest => dest.IsVip, opt => opt.MapFrom(src => src.IsVip))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));
    }
}