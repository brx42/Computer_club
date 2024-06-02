using AutoFixture;
using ComputerClub.DAL.Entities;
using ComputerClub.Domain.Repositories.UserRepository;
using ComputerClub.WebAPI.Endpoints.UserAction.Delete;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ComputerClub.Tests.UserEndpointsTests;

public class DeleteUserHandleTests
{
    private readonly Mock<IUserRepository<User>> _userMock;
    private readonly DeleteUserHandle _delete;

    public DeleteUserHandleTests()
    {
        _userMock = new Mock<IUserRepository<User>>();
        _delete = new DeleteUserHandle(_userMock.Object);
    }
    
    [Fact]
    public async Task DeleteAsync_ShouldReturn200OkStatus()
    {
        // Arrange
        User? user = new Fixture().Build<User>().Create();
        Guid id = new Guid("5d7bc5a3-4ffe-44b2-b2c6-818b220440d6");

        _userMock.Setup(s => s.GetByIdAsync(It.Is<Guid>(x => x == id))).ReturnsAsync(user);

        _userMock.Setup(s => s.DeleteAsync(It.Is<User>(x => x.Id == id)))
            .ReturnsAsync(user);

        // Act
        NoContentResult result = (NoContentResult)await _delete.HandleAsync(id);

        // Assert
        Assert.NotNull(result);
        result.StatusCode.Should().Be(204);
    }
    
    [Fact]
    public async Task DeleteAsync_ShouldReturn404NotFoundStatus()
    {
        // Arrange
        User user = new User();
        Guid id = new Guid();

        _userMock.Setup(s => s.GetByIdAsync(It.Is<Guid>(x => x == id))).ReturnsAsync(user);

        _userMock.Setup(s => s.DeleteAsync(It.Is<User>(x => x.Id == id)))
            .ReturnsAsync(user);

        // Act
        NoContentResult result = (NoContentResult)await _delete.HandleAsync(id);

        // Assert
        Assert.NotNull(result);
        result.StatusCode.Should().Be(204);
    }
}