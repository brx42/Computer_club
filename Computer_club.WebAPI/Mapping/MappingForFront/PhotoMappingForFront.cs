using Computer_club.Data.Models.ClubModels;
using Computer_club.WebAPI.Endpoints.FrontendAction.PhotoAction.Create;
using Computer_club.WebAPI.Endpoints.FrontendAction.PhotoAction.Update;

namespace Computer_club.WebAPI.Mapping.MappingForFront;

public class PhotoMappingForFront : Profile
{
    public PhotoMappingForFront()
    {
        // Create
        CreateMap<CreatePhotoForFrontCommand, Photo>()
            .ForMember(dest => dest.FilePath, opt => opt.MapFrom(src => src.FilePath))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        CreateMap<Photo, CreatePhotoForFrontResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FilePath, opt => opt.MapFrom(src => src.FilePath))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        
        // Update
        CreateMap<UpdatePhotoForFrontCommand, Photo>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FilePath, opt => opt.MapFrom(src => src.FilePath))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));

        CreateMap<Photo, UpdatePhotoForFrontResult>()
            .ForMember(dest => dest.FilePath, opt => opt.MapFrom(src => src.FilePath))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.GameClubId, opt => opt.MapFrom(src => src.GameClubId));
    }
}