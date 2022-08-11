using AutoFixture;
using AutoMapper;
using Computer_club.Data.Entities.UserEntities;
using Computer_club.Services.Options;
using Computer_club.Services.Services.UserServices.UserService;
using Computer_club.WebAPI.Endpoints.BackendAction.UserAction.GetAll;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Computer_club.Tests.UserEndpointsTests;

public class GetAllUsersTests
{
    private readonly GetAllUsers _all;
    private readonly Mock<IUserService<User>> _userMock;
    private readonly Mock<IMapper> _mapMock;

    public GetAllUsersTests()
    {
        _userMock = new Mock<IUserService<User>>();
        _mapMock = new Mock<IMapper>();
        _all = new GetAllUsers(_userMock.Object, _mapMock.Object);
    }
    
    [Fact]
    public async Task GetAllAsync_ShouldReturn200OkStatus()
    {
        // Arrange
        int count = 10;
        int page = 1;
        int size = 10;

        Pagination command = new() { PageNumber = page, PageSize = size };
        List<User> users = new Fixture()
            .Build<User>()
            .CreateMany(count)
            .ToList();
        
        _mapMock.Setup(s => s.ConfigurationProvider);
        
        _userMock.Setup(s => s.GetAllAsync(command, CancellationToken.None))
            .ReturnsAsync(users);
        
        //Act
        var result = (OkObjectResult)await _all.HandleAsync(command, CancellationToken.None);
        
        // Assert
        Assert.NotNull(result);
        result.StatusCode.Should().Be(200);
    }
}