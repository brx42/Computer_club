using Computer_club.Data.Models.ClubModels;
using Computer_club.WebAPI.Endpoints.ClubAction.HistoryEquipAction.Create;
using Computer_club.WebAPI.Endpoints.ClubAction.HistoryEquipAction.GetAll;
using Computer_club.WebAPI.Endpoints.ClubAction.HistoryEquipAction.GetById;
using Computer_club.WebAPI.Endpoints.ClubAction.HistoryEquipAction.Update;

namespace Computer_club.WebAPI.Mapping.MappingForBack;

public class HistoryEquipmentMapping : Profile
{
    public HistoryEquipmentMapping()
    {
        // Create
        CreateMap<CreateHistoryCommand, HistoryEquip>()
            .ForMember(dest => dest.DateOfWork, opt => opt.MapFrom(src => src.DateOfWork))
            .ForMember(dest => dest.TypeOfWork, opt => opt.MapFrom(src => src.TypeOfWork))
            .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.DeviceName))
            .ForMember(dest => dest.PriceOfWork, opt => opt.MapFrom(src => src.PriceOfWork))
            .ForMember(dest => dest.ReasonForWork, opt => opt.MapFrom(src => src.ReasonForWork))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));
        
        CreateMap<HistoryEquip, CreateHistoryResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.DateOfWork, opt => opt.MapFrom(src => src.DateOfWork))
            .ForMember(dest => dest.TypeOfWork, opt => opt.MapFrom(src => src.TypeOfWork))
            .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.DeviceName))
            .ForMember(dest => dest.PriceOfWork, opt => opt.MapFrom(src => src.PriceOfWork))
            .ForMember(dest => dest.ReasonForWork, opt => opt.MapFrom(src => src.ReasonForWork))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        
        // GetAll
        CreateMap<HistoryEquip, GetAllHistoriesResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.DateOfWork, opt => opt.MapFrom(src => src.DateOfWork))
            .ForMember(dest => dest.TypeOfWork, opt => opt.MapFrom(src => src.TypeOfWork))
            .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.DeviceName))
            .ForMember(dest => dest.PriceOfWork, opt => opt.MapFrom(src => src.PriceOfWork))
            .ForMember(dest => dest.ReasonForWork, opt => opt.MapFrom(src => src.ReasonForWork))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        
        // GetById
        CreateMap<HistoryEquip, GetByIdHistoryResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.DateOfWork, opt => opt.MapFrom(src => src.DateOfWork))
            .ForMember(dest => dest.TypeOfWork, opt => opt.MapFrom(src => src.TypeOfWork))
            .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.DeviceName))
            .ForMember(dest => dest.PriceOfWork, opt => opt.MapFrom(src => src.PriceOfWork))
            .ForMember(dest => dest.ReasonForWork, opt => opt.MapFrom(src => src.ReasonForWork))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        
        // Update
        CreateMap<UpdateHistoryCommand, HistoryEquip>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.DateOfWork, opt => opt.MapFrom(src => src.DateOfWork))
            .ForMember(dest => dest.TypeOfWork, opt => opt.MapFrom(src => src.TypeOfWork))
            .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.DeviceName))
            .ForMember(dest => dest.PriceOfWork, opt => opt.MapFrom(src => src.PriceOfWork))
            .ForMember(dest => dest.ReasonForWork, opt => opt.MapFrom(src => src.ReasonForWork))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));
        
        CreateMap<HistoryEquip, UpdateHistoryResult>()
            .ForMember(dest => dest.DateOfWork, opt => opt.MapFrom(src => src.DateOfWork))
            .ForMember(dest => dest.TypeOfWork, opt => opt.MapFrom(src => src.TypeOfWork))
            .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.DeviceName))
            .ForMember(dest => dest.PriceOfWork, opt => opt.MapFrom(src => src.PriceOfWork))
            .ForMember(dest => dest.ReasonForWork, opt => opt.MapFrom(src => src.ReasonForWork))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));
    }
}