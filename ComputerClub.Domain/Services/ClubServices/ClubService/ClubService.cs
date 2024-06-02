using ComputerClub.DAL.Entities;
using Dadata;
using Dadata.Model;
using Microsoft.Extensions.Configuration;

namespace ComputerClub.Domain.Services.ClubServices.ClubService;

public class ClubService : IClubService<GameEntity>
{
    private readonly IConfiguration _configuration;

    public ClubService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<IEnumerable<string>?> FindAddressAsync(string address)
    {
        IConfigurationSection addressApi = _configuration.GetSection("AddressAPI:APIToken");
        SuggestClientAsync api = new SuggestClientAsync(addressApi.Value);
        SuggestResponse<Address>? result = await api.SuggestAddress(address,10);
        return result.suggestions.Select(x => x.value);
    }
}