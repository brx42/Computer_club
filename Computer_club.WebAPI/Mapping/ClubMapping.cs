using Computer_club.Data.Entities.Club;
using Computer_club.WebAPI.Endpoints.ClubAction.ClubAction.Update;

namespace Computer_club.WebAPI.Mapping;

public class ClubMapping : Profile
{
    public ClubMapping()
    {
        // Club
        CreateMap<UpdateClubCommand, Club>()
            .ForMember(dest => dest.AddressClub, opt => opt.MapFrom(src => src.AddressClub))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.IsRented, opt => opt.MapFrom(src => src.IsRented))
            .ForMember(dest => dest.IsProperty, opt => opt.MapFrom(src => src.IsProperty))
            .ForMember(dest => dest.ContractNumber, opt => opt.MapFrom(src => src.ContractNumber))
            .ForMember(dest => dest.DigitizedDocument, opt => opt.MapFrom(src => src.DigitizedDoc))
            .ForMember(dest => dest.PhotoGallery, opt => opt.MapFrom(src => src.PhotoGallery))
            .ForMember(dest => dest.EquipmentClub, opt => opt.MapFrom(src => src.EquipmentClub))
            .ForMember(dest => dest.Provider, opt => opt.MapFrom(src => src.Provider))
            .ForMember(dest => dest.HistoryRepairEquipment, opt => opt.MapFrom(src => src.HistoryRepairEquipment))
            .ForMember(dest => dest.Schedule, opt => opt.MapFrom(src => src.Schedule));


        CreateMap<Club, UpdateClubResult>()
            .ForMember(dest => dest.AddressClub, opt => opt.MapFrom(src => src.AddressClub))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.IsRented, opt => opt.MapFrom(src => src.IsRented))
            .ForMember(dest => dest.IsProperty, opt => opt.MapFrom(src => src.IsProperty))
            .ForMember(dest => dest.ContractNumber, opt => opt.MapFrom(src => src.ContractNumber))
            .ForMember(dest => dest.DigitizedDoc, opt => opt.MapFrom(src => src.DigitizedDocument))
            .ForMember(dest => dest.PhotoGallery, opt => opt.MapFrom(src => src.PhotoGallery))
            .ForMember(dest => dest.EquipmentClub, opt => opt.MapFrom(src => src.EquipmentClub))
            .ForMember(dest => dest.Provider, opt => opt.MapFrom(src => src.Provider))
            .ForMember(dest => dest.HistoryRepairEquipment, opt => opt.MapFrom(src => src.HistoryRepairEquipment))
            .ForMember(dest => dest.Schedule, opt => opt.MapFrom(src => src.Schedule)); ;
    }
}