using Computer_club.Data.Models.ClubModels;
using Computer_club.WebAPI.Endpoints.ClubAction.PlaceAction.Create;
using Computer_club.WebAPI.Endpoints.ClubAction.PlaceAction.GetAll;
using Computer_club.WebAPI.Endpoints.ClubAction.PlaceAction.GetAllBusy;
using Computer_club.WebAPI.Endpoints.ClubAction.PlaceAction.GetAllFree;
using Computer_club.WebAPI.Endpoints.ClubAction.PlaceAction.GetAllFreePlacesEveryType;
using Computer_club.WebAPI.Endpoints.ClubAction.PlaceAction.GetAllSimple;
using Computer_club.WebAPI.Endpoints.ClubAction.PlaceAction.GetAllVip;
using Computer_club.WebAPI.Endpoints.ClubAction.PlaceAction.GetById;
using Computer_club.WebAPI.Endpoints.ClubAction.PlaceAction.Update;

namespace Computer_club.WebAPI.Mapping;

public class PlaceMapping : Profile
{
    public PlaceMapping()
    {
        // Create
        CreateMap<CreatePlaceCommand, Place>()
            .ForMember(dest => dest.IsVip, opt => opt.MapFrom(src => src.IsVip))
            .ForMember(dest => dest.IsFree, opt => opt.MapFrom(src => src.IsFree))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));
        
        CreateMap<Place, CreatePlaceResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.IsVip, opt => opt.MapFrom(src => src.IsVip))
            .ForMember(dest => dest.IsFree, opt => opt.MapFrom(src => src.IsFree))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        
        // GetAll
        CreateMap<Place, GetAllPlacesResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.IsVip, opt => opt.MapFrom(src => src.IsVip))
            .ForMember(dest => dest.IsFree, opt => opt.MapFrom(src => src.IsFree))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        
        // GetAllBusy
        CreateMap<Place, GetAllBusyPlacesResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.IsVip, opt => opt.MapFrom(src => src.IsVip))
            .ForMember(dest => dest.IsFree, opt => opt.MapFrom(src => src.IsFree))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        
        // GetAllFree
        CreateMap<Place, GetAllFreePlacesResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.IsVip, opt => opt.MapFrom(src => src.IsVip))
            .ForMember(dest => dest.IsFree, opt => opt.MapFrom(src => src.IsFree))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        
        // GetAllSimple
        CreateMap<Place, GetAllSimplePlacesResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.IsVip, opt => opt.MapFrom(src => src.IsVip))
            .ForMember(dest => dest.IsFree, opt => opt.MapFrom(src => src.IsFree))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        
        // GetAllVip
        CreateMap<Place, GetAllVipPlacesResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.IsVip, opt => opt.MapFrom(src => src.IsVip))
            .ForMember(dest => dest.IsFree, opt => opt.MapFrom(src => src.IsFree))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));
        
        
        // GetAllFreePlacesEveryType
        CreateMap<Place, PlaceNotReal>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId))
            .ForMember(dest => dest.IsFree, opt => opt.MapFrom(src => src.IsFree))
            .ForMember(dest => dest.IsVip, opt => opt.MapFrom(src => src.IsVip));
        
        
        // GetById
        CreateMap<Place, GetByIdPlaceResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.IsVip, opt => opt.MapFrom(src => src.IsVip))
            .ForMember(dest => dest.IsFree, opt => opt.MapFrom(src => src.IsFree))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        
        // Update
        CreateMap<UpdatePlaceCommand, Place>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.IsVip, opt => opt.MapFrom(src => src.IsVip))
            .ForMember(dest => dest.IsFree, opt => opt.MapFrom(src => src.IsFree))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        CreateMap<Place, UpdatePlaceResult>()
            .ForMember(dest => dest.IsVip, opt => opt.MapFrom(src => src.IsVip))
            .ForMember(dest => dest.IsFree, opt => opt.MapFrom(src => src.IsFree))
            .ForMember(dest => dest.DeviceSetId, opt => opt.MapFrom(src => src.DeviceSetId))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));
    }
}