using ComputerClub.DAL.Entities;
using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Services.ClubServices.ClubService;
using FastEndpoints;

namespace ComputerClub.WebAPI.Endpoints.ClubAction.GameClubAction.FindAddress;

public class FindAddressHandle : Endpoint<FindAddressRequest, IEnumerable<string>>
{
    private readonly IClubService<GameEntity> _address;

    public FindAddressHandle(IClubService<GameEntity> address)
    {
        _address = address;
    }

    public override void Configure()
    {
        Post("club/find-address");

        Summary(sum => { sum.Summary = "Club address search"; });
        
        Options(opt => opt.WithTags("Club"));
        
        Policies(Role.AllAdmins);
    }
    
    public override async Task HandleAsync(FindAddressRequest request, CancellationToken ct)
    {
        IEnumerable<string>? result = await _address.FindAddressAsync(request.Address);

        await SendOkAsync(result, ct);
    }
}