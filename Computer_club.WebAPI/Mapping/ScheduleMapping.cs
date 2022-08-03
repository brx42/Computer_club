using Computer_club.Data.Models.ClubModels;
using Computer_club.WebAPI.Endpoints.ClubAction.ScheduleAction.Create;
using Computer_club.WebAPI.Endpoints.ClubAction.ScheduleAction.GetAll;
using Computer_club.WebAPI.Endpoints.ClubAction.ScheduleAction.GetById;
using Computer_club.WebAPI.Endpoints.ClubAction.ScheduleAction.Update;

namespace Computer_club.WebAPI.Mapping;

public class ScheduleMapping : Profile
{
    public ScheduleMapping()
    {
        // Create
        CreateMap<CreateScheduleCommand, Schedule>()
            .ForMember(dest => dest.StartOfWork, opt => opt.MapFrom(src => src.StartOfWork))
            .ForMember(dest => dest.EndOfWork, opt => opt.MapFrom(src => src.EndOfWork))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));
        
        CreateMap<Schedule, CreateScheduleResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.StartOfWork, opt => opt.MapFrom(src => src.StartOfWork))
            .ForMember(dest => dest.EndOfWork, opt => opt.MapFrom(src => src.EndOfWork))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        
        // GetAll
        CreateMap<Schedule, GetAllScheduleResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.StartOfWork, opt => opt.MapFrom(src => src.StartOfWork))
            .ForMember(dest => dest.EndOfWork, opt => opt.MapFrom(src => src.EndOfWork))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        
        // GetById
        CreateMap<Schedule, GetByIdScheduleResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.StartOfWork, opt => opt.MapFrom(src => src.StartOfWork))
            .ForMember(dest => dest.EndOfWork, opt => opt.MapFrom(src => src.EndOfWork))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        
        // Update
        CreateMap<UpdateScheduleCommand, Schedule>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.StartOfWork, opt => opt.MapFrom(src => src.StartOfWork))
            .ForMember(dest => dest.EndOfWork, opt => opt.MapFrom(src => src.EndOfWork))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        CreateMap<Schedule, UpdateScheduleResult>()
            .ForMember(dest => dest.StartOfWork, opt => opt.MapFrom(src => src.StartOfWork))
            .ForMember(dest => dest.EndOfWork, opt => opt.MapFrom(src => src.EndOfWork))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));
    }
}