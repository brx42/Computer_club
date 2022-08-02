using AutoMapper;
using Computer_club.Services.Services.UserServices.RoleService;
using Computer_club.WebAPI.Endpoints.RoleAction.Create;
using Computer_club.WebAPI.Endpoints.RoleAction.Delete;
using Computer_club.WebAPI.Endpoints.RoleAction.Get;
using Computer_club.WebAPI.Endpoints.RoleAction.GetAll;
using Microsoft.AspNetCore.Identity;

namespace Computer_club.Tests.Controllers;

public class RoleEndpointsTests
{
    private readonly IRoleService<IdentityRole<Guid>> _service;
    private readonly IMapper _mapper;

    [Fact]
    public void Create()
    {
        var create = new CreateRole(_service);
        var result = create.HandleAsync(string.Empty);
        Assert.NotNull(result);
    }

    [Fact]
    public void Delete()
    {
        var delete = new DeleteRole(_service);
        var result = delete.HandleAsync(new IdentityRole<Guid>());
        Assert.NotNull(result);
    }

    [Fact]
    public void Get()
    {
        var get = new GetByIdRole(_service, _mapper);
        var result = get.HandleAsync(new Guid());
        Assert.NotNull(result);
    }

    [Fact]
    public void GetAll()
    {
        var getAll = new GetAllRoles(_service);
        var result = getAll.HandleAsync();
        Assert.NotNull(result);
    }
}