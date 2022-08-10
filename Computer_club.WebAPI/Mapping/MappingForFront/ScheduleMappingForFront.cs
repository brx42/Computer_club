using Computer_club.Data.Models.ClubModels;
using Computer_club.WebAPI.Endpoints.FrontendAction.ScheduleAction.Create;
using Computer_club.WebAPI.Endpoints.FrontendAction.ScheduleAction.Update;

namespace Computer_club.WebAPI.Mapping.MappingForFront;

public class ScheduleMappingForFront : Profile
{
    public ScheduleMappingForFront()
    {
        // Create
        CreateMap<CreateScheduleForFrontCommand, Schedule>()
            .ForMember(dest => dest.StartOfWork, opt => opt.MapFrom(src => src.StartOfWork))
            .ForMember(dest => dest.EndOfWork, opt => opt.MapFrom(src => src.EndOfWork))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));
        
        CreateMap<Schedule, CreateScheduleForFrontResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.StartOfWork, opt => opt.MapFrom(src => src.StartOfWork))
            .ForMember(dest => dest.EndOfWork, opt => opt.MapFrom(src => src.EndOfWork))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        
        // Update
        CreateMap<UpdateScheduleForFrontCommand, Schedule>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.StartOfWork, opt => opt.MapFrom(src => src.StartOfWork))
            .ForMember(dest => dest.EndOfWork, opt => opt.MapFrom(src => src.EndOfWork))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        CreateMap<Schedule, UpdateScheduleForFrontResult>()
            .ForMember(dest => dest.StartOfWork, opt => opt.MapFrom(src => src.StartOfWork))
            .ForMember(dest => dest.EndOfWork, opt => opt.MapFrom(src => src.EndOfWork))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));
    }
}