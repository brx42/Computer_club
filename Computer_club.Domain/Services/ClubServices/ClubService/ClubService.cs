using Computer_club.Data.Entities.ClubEntities;
using Dadata;
using Microsoft.Extensions.Configuration;

namespace Computer_club.Domain.Services.ClubServices.ClubService;

public class ClubService : IClubService<GameClub>
{
    private readonly IConfiguration _configuration;

    public ClubService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<IEnumerable<string>?> FindAddressAsync(string address)
    {
        var addressApi = _configuration.GetSection("AddressAPI:APIToken");
        var api = new SuggestClientAsync(addressApi.Value);
        var result = await api.SuggestAddress(address,10);
        return result.suggestions.Select(x => x.value);
    }
}