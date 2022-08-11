using Computer_club.Data.Models.ClubModels;
using Computer_club.WebAPI.Endpoints.FrontendAction.HistoryEquipAction.Create;
using Computer_club.WebAPI.Endpoints.FrontendAction.HistoryEquipAction.GetAll;
using Computer_club.WebAPI.Endpoints.FrontendAction.HistoryEquipAction.GetAllForThePeriod;
using Computer_club.WebAPI.Endpoints.FrontendAction.HistoryEquipAction.Update;

namespace Computer_club.WebAPI.Mapping.MappingForFront;

public class HistoryEquipmentMappingForFront : Profile
{
    public HistoryEquipmentMappingForFront()
    {
        // Create
        CreateMap<CreateHistoryForFrontCommand, HistoryEquip>()
            .ForMember(dest => dest.DateOfWork, opt => opt.MapFrom(src => src.DateOfWork))
            .ForMember(dest => dest.TypeOfWork, opt => opt.MapFrom(src => src.TypeOfWork))
            .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.DeviceName))
            .ForMember(dest => dest.PriceOfWork, opt => opt.MapFrom(src => src.PriceOfWork))
            .ForMember(dest => dest.ReasonForWork, opt => opt.MapFrom(src => src.ReasonForWork))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));
        
        CreateMap<HistoryEquip, CreateHistoryForFrontResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.DateOfWork, opt => opt.MapFrom(src => src.DateOfWork))
            .ForMember(dest => dest.TypeOfWork, opt => opt.MapFrom(src => src.TypeOfWork))
            .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.DeviceName))
            .ForMember(dest => dest.PriceOfWork, opt => opt.MapFrom(src => src.PriceOfWork))
            .ForMember(dest => dest.ReasonForWork, opt => opt.MapFrom(src => src.ReasonForWork))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));
        
        
        // GetAll
        CreateMap<HistoryEquip, GetAllHistoriesForFrontResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.DateOfWork, opt => opt.MapFrom(src => src.DateOfWork))
            .ForMember(dest => dest.TypeOfWork, opt => opt.MapFrom(src => src.TypeOfWork))
            .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.DeviceName))
            .ForMember(dest => dest.PriceOfWork, opt => opt.MapFrom(src => src.PriceOfWork))
            .ForMember(dest => dest.ReasonForWork, opt => opt.MapFrom(src => src.ReasonForWork))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));
        
        
        // GetAllOnTime
        CreateMap<HistoryEquip, GetAllHistoriesForThePeriodForFrontResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.DateOfWork, opt => opt.MapFrom(src => src.DateOfWork))
            .ForMember(dest => dest.TypeOfWork, opt => opt.MapFrom(src => src.TypeOfWork))
            .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.DeviceName))
            .ForMember(dest => dest.PriceOfWork, opt => opt.MapFrom(src => src.PriceOfWork))
            .ForMember(dest => dest.ReasonForWork, opt => opt.MapFrom(src => src.ReasonForWork))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));
        

        // Update
        CreateMap<UpdateHistoryForFrontCommand, HistoryEquip>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.DateOfWork, opt => opt.MapFrom(src => src.DateOfWork))
            .ForMember(dest => dest.TypeOfWork, opt => opt.MapFrom(src => src.TypeOfWork))
            .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.DeviceName))
            .ForMember(dest => dest.PriceOfWork, opt => opt.MapFrom(src => src.PriceOfWork))
            .ForMember(dest => dest.ReasonForWork, opt => opt.MapFrom(src => src.ReasonForWork))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));
        
        CreateMap<HistoryEquip, UpdateHistoryForFrontResult>()
            .ForMember(dest => dest.DateOfWork, opt => opt.MapFrom(src => src.DateOfWork))
            .ForMember(dest => dest.TypeOfWork, opt => opt.MapFrom(src => src.TypeOfWork))
            .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.DeviceName))
            .ForMember(dest => dest.PriceOfWork, opt => opt.MapFrom(src => src.PriceOfWork))
            .ForMember(dest => dest.ReasonForWork, opt => opt.MapFrom(src => src.ReasonForWork))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));
    }
}