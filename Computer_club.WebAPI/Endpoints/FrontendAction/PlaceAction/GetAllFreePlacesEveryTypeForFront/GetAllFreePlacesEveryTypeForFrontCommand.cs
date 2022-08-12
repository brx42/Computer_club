using Computer_club.Services.Options;

namespace Computer_club.WebAPI.Endpoints.FrontendAction.PlaceAction.GetAllFreePlacesEveryTypeForFront;

public class GetAllFreePlacesEveryTypeForFrontCommand : IPagination
{
    public string NameSet { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}