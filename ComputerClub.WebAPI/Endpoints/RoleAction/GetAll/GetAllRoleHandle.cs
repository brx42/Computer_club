using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Services.UserServices.RoleService;
using FastEndpoints;
using Microsoft.AspNetCore.Identity;

namespace ComputerClub.WebAPI.Endpoints.RoleAction.GetAll;

public class GetAllRoleHandle : EndpointWithoutRequest<List<IdentityRole<Guid>>>
{
    private readonly IRoleService _service;

    public GetAllRoleHandle(IRoleService service)
    {
        _service = service;
    }

    public override void Configure()
    {
        Get("api/roles");
        
        Summary(sum => { sum.Summary = "Get a list of all Roles";});
        
        Options(opt => opt.WithTags("Role"));

        Policies(Role.SuperAdmin);
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        List<IdentityRole<Guid>> response = await _service.GetAllAsync(ct);

        await SendOkAsync(response, ct);
    }
}