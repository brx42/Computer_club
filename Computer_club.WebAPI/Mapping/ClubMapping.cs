using Computer_club.Data.Entities.ClubEntities;
using Computer_club.WebAPI.Endpoints.ClubAction.ClubAction.Update;

namespace Computer_club.WebAPI.Mapping;

public class ClubMapping : Profile
{
    public ClubMapping()
    {
        CreateMap<UpdateClubCommand, GameClub>()
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