using Computer_club.Data.Entities.Club;
using Computer_club.Data.Models.Club;
using Computer_club.WebAPI.Endpoints.ClubAction.AddressAction.FindAddress;
using Computer_club.WebAPI.Endpoints.ClubAction.AddressAction.Update;
using Dadata.Model;

namespace Computer_club.WebAPI.Mapping;

public class ClubMapping : Profile
{
    public ClubMapping()
    {
        // Address
        CreateMap<UpdateAddressCommand, AddressClub>().
            ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address)).
            ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

        CreateMap<AddressClub, UpdateAddressResult>()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));

    }
}