using Computer_club.Data.Database;
using Computer_club.Data.Entities.ClubEntities;
using Dadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Computer_club.Services.Services.ClubServices.ClubService;

public class ClubService : IClubService<GameClub>
{
    private readonly IConfiguration _configuration;
    private readonly AppDbContext _context;

    public ClubService(IConfiguration configuration, AppDbContext context)
    {
        _configuration = configuration;
        _context = context;
    }

    public async Task<IEnumerable<string>?> FindAddressAsync(string address)
    {
        var addressApi = _configuration.GetSection("AddressAPI:APIToken");
        var api = new SuggestClientAsync(addressApi.Value);
        var result = await api.SuggestAddress(address,10);
        return result.suggestions.Select(x => x.value);
    }


    public async Task<List<GameClub>?> GetAllAsync(CancellationToken token)
    {
        return await _context.GameClubs.ToListAsync(token);
    }

    public async Task<GameClub?> GetByIdAsync(int id)
    {
        return await _context.GameClubs.FindAsync(id);
    }

    public async Task<GameClub?> AddAsync(GameClub club)
    {
        await _context.GameClubs.AddAsync(club);
        await _context.SaveChangesAsync();
        return club;
    }

    public async Task UpdateAsync(GameClub club, CancellationToken token)
    {
        _context.GameClubs.Update(club);
        await _context.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(GameClub club)
    {
        _context.GameClubs.Remove(club);
        await _context.SaveChangesAsync();
    }
}