using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Services.UserServices.RoleService;
using FastEndpoints;
using Microsoft.AspNetCore.Identity;

namespace ComputerClub.WebAPI.Endpoints.RoleAction.AddManager;

public class AddManagerHandle : EndpointWithoutRequest<bool>
{
    private readonly IRoleService _service;

    public AddManagerHandle(IRoleService service)
    {
        _service = service;
    }

    public override void Configure()
    {
        Post("role/manager/{userId}");

        Summary(sum => { sum.Summary = "Add user role manager"; });
        
        Options(opt => opt.WithTags("Role"));
        
        Policies(Role.SuperAdmin);
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        Guid userId = Query<Guid>("userId");
        
        IdentityResult? result = await _service.AddManagerAsync(userId);

        if (result == null)
        {
            await SendAsync(result.Succeeded, 400, ct);
        }

        await SendOkAsync(result.Succeeded, ct);
    }
}