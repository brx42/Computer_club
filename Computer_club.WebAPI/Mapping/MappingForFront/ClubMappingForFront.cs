using Computer_club.Data.Entities.ClubEntities;
using Computer_club.WebAPI.Endpoints.FrontendAction.ClubAction.Create;

namespace Computer_club.WebAPI.Mapping.MappingForFront;

public class ClubMappingForFront : Profile
{
    public ClubMappingForFront()
    {
        // Create
        CreateMap<CreateClubForFrontCommand, GameClub>()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ContractNumber, opt => opt.MapFrom(src => src.ContractNumber))
            .ForMember(dest => dest.DigitizedDocument, opt => opt.MapFrom(src => src.DigitizedDocument))
            .ForMember(dest => dest.IsOwned, opt => opt.MapFrom(src => src.IsOwned));
        
        CreateMap<GameClub, CreateClubForFrontResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ContractNumber, opt => opt.MapFrom(src => src.ContractNumber))
            .ForMember(dest => dest.DigitizedDocument, opt => opt.MapFrom(src => src.DigitizedDocument))
            .ForMember(dest => dest.IsOwned, opt => opt.MapFrom(src => src.IsOwned));
    }
}