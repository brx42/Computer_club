using Computer_club.Domain.Options;

namespace Computer_club.WebAPI.Endpoints.ClubAction.PlaceAction.GetAllFreePlacesEveryType;

public class GetAllFreePlacesEveryTypeCommand : IPagination
{
    public string NameSet { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}