﻿using Computer_club.Data.Entities;
using Computer_club.WebAPI.Endpoints.ClubAction.GameClubAction.Create;
using Computer_club.WebAPI.Endpoints.ClubAction.GameClubAction.GetAll;
using Computer_club.WebAPI.Endpoints.ClubAction.GameClubAction.GetById;
using Computer_club.WebAPI.Endpoints.ClubAction.GameClubAction.Update;

namespace Computer_club.WebAPI.Mapping;

public class ClubMapping : Profile
{
    public ClubMapping()
    {
        // Create
        CreateMap<CreateClubCommand, GameClub>()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ContractNumber, opt => opt.MapFrom(src => src.ContractNumber))
            .ForMember(dest => dest.DigitizedDocument, opt => opt.MapFrom(src => src.DigitizedDocument))
            .ForMember(dest => dest.IsOwned, opt => opt.MapFrom(src => src.IsOwned));
        
        CreateMap<GameClub, CreateClubResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ContractNumber, opt => opt.MapFrom(src => src.ContractNumber))
            .ForMember(dest => dest.DigitizedDocument, opt => opt.MapFrom(src => src.DigitizedDocument))
            .ForMember(dest => dest.IsOwned, opt => opt.MapFrom(src => src.IsOwned));
        
        
        // GetAll
        CreateMap<GameClub, GetAllClubsResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ContractNumber, opt => opt.MapFrom(src => src.ContractNumber))
            .ForMember(dest => dest.DigitizedDocument, opt => opt.MapFrom(src => src.DigitizedDocument))
            .ForMember(dest => dest.IsOwned, opt => opt.MapFrom(src => src.IsOwned));

        
        // GetById
        CreateMap<GameClub, GetByIdClubResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ContractNumber, opt => opt.MapFrom(src => src.ContractNumber))
            .ForMember(dest => dest.DigitizedDocument, opt => opt.MapFrom(src => src.DigitizedDocument))
            .ForMember(dest => dest.IsOwned, opt => opt.MapFrom(src => src.IsOwned));

        
        // Update
        CreateMap<UpdateClubCommand, GameClub>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.IsOwned, opt => opt.MapFrom(src => src.IsOwned))
            .ForMember(dest => dest.ContractNumber, opt => opt.MapFrom(src => src.ContractNumber))
            .ForMember(dest => dest.DigitizedDocument, opt => opt.MapFrom(src => src.DigitizedDocument));
        
        CreateMap<GameClub, UpdateClubResult>()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.IsOwned, opt => opt.MapFrom(src => src.IsOwned))
            .ForMember(dest => dest.ContractNumber, opt => opt.MapFrom(src => src.ContractNumber))
            .ForMember(dest => dest.DigitizedDocument, opt => opt.MapFrom(src => src.DigitizedDocument));
    }
}