using Computer_club.Data.Models.ClubModels;
using Computer_club.WebAPI.Endpoints.ClubAction.ProviderAction.Create;
using Computer_club.WebAPI.Endpoints.ClubAction.ProviderAction.GetAll;
using Computer_club.WebAPI.Endpoints.ClubAction.ProviderAction.GetById;
using Computer_club.WebAPI.Endpoints.ClubAction.ProviderAction.Update;

namespace Computer_club.WebAPI.Mapping.MappingForBack;

public class ProviderMapping : Profile
{
    public ProviderMapping()
    {
        // Create
        CreateMap<CreateProviderCommand, Provider>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Speed, opt => opt.MapFrom(src => src.Speed))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.IsStaticIP, opt => opt.MapFrom(src => src.IsStaticIP))
            .ForMember(dest => dest.ContractNumber, opt => opt.MapFrom(src => src.ContractNumber))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        CreateMap<Provider, CreateProviderResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Speed, opt => opt.MapFrom(src => src.Speed))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.IsStaticIP, opt => opt.MapFrom(src => src.IsStaticIP))
            .ForMember(dest => dest.ContractNumber, opt => opt.MapFrom(src => src.ContractNumber))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));
        
        
        // GetAll
        CreateMap<Provider, GetAllProvidersResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Speed, opt => opt.MapFrom(src => src.Speed))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.IsStaticIP, opt => opt.MapFrom(src => src.IsStaticIP))
            .ForMember(dest => dest.ContractNumber, opt => opt.MapFrom(src => src.ContractNumber))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        
        // GetById
        CreateMap<Provider, GetByIdProviderResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Speed, opt => opt.MapFrom(src => src.Speed))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.IsStaticIP, opt => opt.MapFrom(src => src.IsStaticIP))
            .ForMember(dest => dest.ContractNumber, opt => opt.MapFrom(src => src.ContractNumber))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));
        
        
        // Update
        CreateMap<UpdateProviderCommand, Provider>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Speed, opt => opt.MapFrom(src => src.Speed))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.IsStaticIP, opt => opt.MapFrom(src => src.IsStaticIP))
            .ForMember(dest => dest.ContractNumber, opt => opt.MapFrom(src => src.ContractNumber))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        CreateMap<Provider, UpdateProviderResult>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Speed, opt => opt.MapFrom(src => src.Speed))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.IsStaticIP, opt => opt.MapFrom(src => src.IsStaticIP))
            .ForMember(dest => dest.ContractNumber, opt => opt.MapFrom(src => src.ContractNumber))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));
    }
}