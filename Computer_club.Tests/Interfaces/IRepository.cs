using Computer_club.Tests.Models;

namespace Computer_club.Tests.Interfaces;

public interface IRepository
{
    Task<IEnumerable<User>> GetAll();
    User Get(Guid id);
    Task Create(User user);
}