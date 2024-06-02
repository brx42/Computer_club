namespace ComputerClub.Domain.Services.ClubServices.ClubService;

public interface IClubService<T>
{
    Task<IEnumerable<string>?> FindAddressAsync(string entity);
}