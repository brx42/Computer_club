namespace Computer_club.Services.Services.ClubServices.AddressService;

public interface IAddressService<T>
{
    Task<IEnumerable<string>?> FindAddressAsync(string entity);
    Task<List<T>?> GetAllAsync(CancellationToken token);
    Task<T?> GetByIdAsync(Guid id);
    Task<T?> AddAsync(T entity);
    Task UpdateAsync(T entity, CancellationToken token);
    Task DeleteAsync(T entity);
}