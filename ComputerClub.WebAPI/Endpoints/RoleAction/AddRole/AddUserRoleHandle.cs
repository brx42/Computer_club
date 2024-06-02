using ComputerClub.DAL.Models.UserModels;
using ComputerClub.Domain.Services.UserServices.RoleService;
using FastEndpoints;
using Microsoft.AspNetCore.Identity;

namespace ComputerClub.WebAPI.Endpoints.RoleAction.AddRole;

public class AddUserRoleHandle : Endpoint<AddUserRoleRequest, bool>
{
    private readonly IRoleService _roleService;

    public AddUserRoleHandle(IRoleService service)
    {
        _roleService = service;
    }

    public override void Configure()
    {
        Post("api/role");
        
        Summary(sum => sum.Summary = "Add user role");
        
        Options(opt => opt.WithTags("Role"));
        
        Policies(Role.SuperAdmin);
    }

    public override async Task HandleAsync(AddUserRoleRequest request, CancellationToken ct)
    {
        IdentityResult? result = await _roleService.AddUserRoleAsync(request.UserId, request.Role);

        if (result == null)
        {
            await SendAsync(result.Succeeded, 400, ct);
        }

        await SendOkAsync(result.Succeeded, ct);
    }
}