﻿using Computer_club.Data.Models.ClubModels;
using Computer_club.WebAPI.Endpoints.BackendAction.ClubAction.PlaceAction.Create;
using Computer_club.WebAPI.Endpoints.BackendAction.ClubAction.PlaceAction.GetAll;
using Computer_club.WebAPI.Endpoints.BackendAction.ClubAction.PlaceAction.GetById;
using Computer_club.WebAPI.Endpoints.BackendAction.ClubAction.PlaceAction.Update;

namespace Computer_club.WebAPI.Mapping.MappingForBack;

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