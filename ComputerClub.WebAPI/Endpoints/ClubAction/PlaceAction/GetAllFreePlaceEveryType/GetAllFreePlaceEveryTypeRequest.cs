using ComputerClub.Domain.Options;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.PlaceAction.GetAllFreePlaceEveryType;

public class GetAllFreePlaceEveryTypeRequest : IPagination
{
    public string NameSet { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}