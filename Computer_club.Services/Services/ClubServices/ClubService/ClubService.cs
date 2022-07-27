using Computer_club.Data.Database;
using Computer_club.Data.Entities.Club;
using Dadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Computer_club.Services.Services.ClubServices.ClubService;

public class ClubService : IClubService<Club>
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
        var token = addressApi;
        var api = new SuggestClientAsync(token.Value);
        var result = await api.SuggestAddress(address,10);
        return result.suggestions.Select(x => x.value);
    }


    public async Task<List<Club>?> GetAllAsync(CancellationToken token)
    {
        return await _context.Clubs.ToListAsync(token);
    }

    public async Task<Club?> GetByIdAsync(Guid id)
    {
        return await _context.Clubs.FindAsync(id);
    }

    public async Task<Club?> AddAsync(Club club)
    {
        await _context.Clubs.AddAsync(club);
        await _context.SaveChangesAsync();
        return club;
    }

    public async Task UpdateAsync(Club club, CancellationToken token)
    {
        _context.Clubs.Update(club);
        await _context.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(Club club)
    {
        _context.Clubs.Remove(club);
        await _context.SaveChangesAsync();
    }
}