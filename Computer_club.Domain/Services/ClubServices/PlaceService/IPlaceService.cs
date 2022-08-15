using Computer_club.Domain.Options;

namespace Computer_club.Domain.Services.ClubServices.PlaceService;

public interface IPlaceService<T>
{
    Task<List<T>> GetAllFreeSeatsAsync(Pagination pagination, CancellationToken token);
    Task<List<T>> GetAllBusySeatsAsync(Pagination pagination, CancellationToken token);
    Task<List<T>> GetAllVipSeatsAsync(Pagination pagination, CancellationToken token);
    Task<List<T>> GetAllSimpleSeatsAsync(Pagination pagination, CancellationToken token);
    Task<List<T>> GetAllFreePlacesForTypeAsync(Pagination pagination, string name);
}