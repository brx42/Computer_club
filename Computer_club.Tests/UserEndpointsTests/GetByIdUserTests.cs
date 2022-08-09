using AutoFixture;
using AutoMapper;
using Computer_club.Data.Entities.UserEntities;
using Computer_club.Services.Services.UserServices.UserService;
using Computer_club.WebAPI.Endpoints.UserAction.GetById;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Computer_club.Tests.UserEndpointsTests;

public class GetByIdUserTests
{
    private readonly GetByIdUser _byId;
    private readonly Mock<IUserService<User>> _userMock;
    private readonly Mock<IMapper> _mapMock;

    public GetByIdUserTests()
    {
        _userMock = new Mock<IUserService<User>>();
        _mapMock = new Mock<IMapper>();
        _byId = new GetByIdUser(_userMock.Object, _mapMock.Object);
    }
    
    [Fact]
    public async Task GetByIdAsync_ShouldReturn200OkStatus()
    {
        // Arrange
        var id = new Guid("a802a567-690c-460e-aa7a-45a39d18f618");
        User user = new Fixture().Build<User>().Create();
        
        
        _mapMock.Setup(s => s.ConfigurationProvider);
        _userMock.Setup(s => s.GetByIdAsync(It.Is<Guid>(x => x == id)))
            .ReturnsAsync(user);
        
        // Act
        var result = (OkObjectResult)await _byId.HandleAsync(id, CancellationToken.None);
        
        // Assert
        Assert.NotNull(result);
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturn404NotFoundStatus()
    {
        // Arrange
        _mapMock.Setup(s => s.ConfigurationProvider);
        _userMock.Setup(s => s.GetByIdAsync(new Guid()))
            .ReturnsAsync(GetByIdNull);
        
        // Act
        var result = (NotFoundResult)await _byId.HandleAsync(new Guid(), CancellationToken.None);
        
        // Assert
        Assert.NotNull(result);
        result.StatusCode.Should().Be(404);
        _userMock.Verify(_ => _.GetByIdAsync(new Guid()), Times.Exactly(1));
    }
    private User GetByIdNull()
    {
        return null;
    }
}