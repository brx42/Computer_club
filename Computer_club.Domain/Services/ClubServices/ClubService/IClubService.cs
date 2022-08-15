namespace Computer_club.Domain.Services.ClubServices.ClubService;

public interface IClubService<T>
{
    Task<IEnumerable<string>?> FindAddressAsync(string entity);
}