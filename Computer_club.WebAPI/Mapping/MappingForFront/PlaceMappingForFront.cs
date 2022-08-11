using Computer_club.Data.Models.ClubModels;
using Computer_club.WebAPI.Endpoints.FrontendAction.PlaceAction.Create;
using Computer_club.WebAPI.Endpoints.FrontendAction.PlaceAction.GetAll;
using Computer_club.WebAPI.Endpoints.FrontendAction.PlaceAction.GetAllBusy;
using Computer_club.WebAPI.Endpoints.FrontendAction.PlaceAction.GetAllFree;
using Computer_club.WebAPI.Endpoints.FrontendAction.PlaceAction.GetAllSimple;
using Computer_club.WebAPI.Endpoints.FrontendAction.PlaceAction.GetAllVip;
using Computer_club.WebAPI.Endpoints.FrontendAction.PlaceAction.GetById;
using Computer_club.WebAPI.Endpoints.FrontendAction.PlaceAction.Update;

namespace Computer_club.WebAPI.Mapping.MappingForFront;

public class PlaceMappingForFront : Profile
{
    public PlaceMappingForFront()
    {
        // Create
        CreateMap<CreatePlaceForFrontCommand, Place>()
            .ForMember(dest => dest.IsVip, opt => opt.MapFrom(src => src.IsVip))
            .ForMember(dest => dest.IsFree, opt => opt.MapFrom(src => src.IsFree))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));
        
        CreateMap<Place, CreatePlaceForFrontResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.IsVip, opt => opt.MapFrom(src => src.IsVip))
            .ForMember(dest => dest.IsFree, opt => opt.MapFrom(src => src.IsFree))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));
        
        
        // GetAll
        CreateMap<Place, GetAllPlacesForFrontResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.IsVip, opt => opt.MapFrom(src => src.IsVip))
            .ForMember(dest => dest.IsFree, opt => opt.MapFrom(src => src.IsFree))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        
        // GetAllBusy
        CreateMap<Place, GetAllBusyPlacesForFrontResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.IsVip, opt => opt.MapFrom(src => src.IsVip))
            .ForMember(dest => dest.IsFree, opt => opt.MapFrom(src => src.IsFree))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        
        // GetAllFree
        CreateMap<Place, GetAllFreePlacesForFrontResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.IsVip, opt => opt.MapFrom(src => src.IsVip))
            .ForMember(dest => dest.IsFree, opt => opt.MapFrom(src => src.IsFree))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        
        // GetAllSimple
        CreateMap<Place, GetAllSimplePlacesForFrontResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.IsVip, opt => opt.MapFrom(src => src.IsVip))
            .ForMember(dest => dest.IsFree, opt => opt.MapFrom(src => src.IsFree))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        
        // GetAllVip
        CreateMap<Place, GetAllVipPlacesForFrontResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.IsVip, opt => opt.MapFrom(src => src.IsVip))
            .ForMember(dest => dest.IsFree, opt => opt.MapFrom(src => src.IsFree))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        
        // GetById
        CreateMap<Place, GetByIdPlaceForFrontResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.IsVip, opt => opt.MapFrom(src => src.IsVip))
            .ForMember(dest => dest.IsFree, opt => opt.MapFrom(src => src.IsFree))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        
        // Update
        CreateMap<UpdatePlaceForFrontCommand, Place>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.IsVip, opt => opt.MapFrom(src => src.IsVip))
            .ForMember(dest => dest.IsFree, opt => opt.MapFrom(src => src.IsFree))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        CreateMap<Place, UpdatePlaceForFrontResult>()
            .ForMember(dest => dest.IsVip, opt => opt.MapFrom(src => src.IsVip))
            .ForMember(dest => dest.IsFree, opt => opt.MapFrom(src => src.IsFree))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));
    }
}