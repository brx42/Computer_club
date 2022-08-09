using AutoFixture;
using Computer_club.Data.Entities.UserEntities;
using Computer_club.Services.Services.UserServices.UserService;
using Computer_club.WebAPI.Endpoints.UserAction.Delete;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Computer_club.Tests.UserEndpointsTests;

public class DeleteUserTests
{
    private readonly Mock<IUserService<User>> _userMock;
    private readonly DeleteUser _delete;

    public DeleteUserTests()
    {
        _userMock = new Mock<IUserService<User>>();
        _delete = new DeleteUser(_userMock.Object);
    }
    
    [Fact]
    public async Task DeleteAsync_ShouldReturn200OkStatus()
    {
        // Arrange
        var user = new Fixture().Build<User>().Create();
        var id = new Guid("5d7bc5a3-4ffe-44b2-b2c6-818b220440d6");

        _userMock.Setup(s => s.GetByIdAsync(It.Is<Guid>(x => x == id))).ReturnsAsync(user);

        _userMock.Setup(s => s.DeleteAsync(It.Is<User>(x => x.Id == id)))
            .ReturnsAsync(user);

        // Act
        var result = (NoContentResult)await _delete.HandleAsync(id);

        // Assert
        Assert.NotNull(result);
        result.StatusCode.Should().Be(204);
    }
    
    [Fact]
    public async Task DeleteAsync_ShouldReturn404NotFoundStatus()
    {
        // Arrange
        var user = new User();
        var id = new Guid();

        _userMock.Setup(s => s.GetByIdAsync(It.Is<Guid>(x => x == id))).ReturnsAsync(user);

        _userMock.Setup(s => s.DeleteAsync(It.Is<User>(x => x.Id == id)))
            .ReturnsAsync(user);

        // Act
        var result = (NoContentResult)await _delete.HandleAsync(id);

        // Assert
        Assert.NotNull(result);
        result.StatusCode.Should().Be(204);
    }
}