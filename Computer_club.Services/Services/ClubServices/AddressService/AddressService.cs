using Computer_club.Data.Data;
using Computer_club.Data.Models.Club;
using Dadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Computer_club.Services.Services.ClubServices.AddressService;

public class AddressService : IAddressService<AddressClub>
{
    private readonly IConfiguration _configuration;
    private readonly AppDbContext _context;

    public AddressService(IConfiguration configuration, AppDbContext context)
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


    public async Task<List<AddressClub>?> GetAllAsync(CancellationToken token)
    {
        return await _context.AddressClubs.ToListAsync(token);
    }

    public async Task<AddressClub?> GetByIdAsync(Guid id)
    {
        return await _context.AddressClubs.FindAsync(id);
    }

    public async Task<AddressClub?> AddAsync(AddressClub address)
    {
        await _context.AddressClubs.AddAsync(address);
        await _context.SaveChangesAsync();
        return address;
    }

    public async Task UpdateAsync(AddressClub address, CancellationToken token)
    {
        _context.AddressClubs.Update(address);
        await _context.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(AddressClub address)
    {
        _context.AddressClubs.Remove(address);
        await _context.SaveChangesAsync();
    }
}