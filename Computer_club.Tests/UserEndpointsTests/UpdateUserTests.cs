using AutoFixture;
using AutoMapper;
using Computer_club.Data.Entities;
using Computer_club.Domain.Repositories.UserRepository;
using Computer_club.WebAPI.Endpoints.UserAction.Update;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Computer_club.Tests.UserEndpointsTests;

public class UpdateUserTests
{
    private readonly UpdateUser _update;
    private readonly Mock<IUserRepository<User>> _userMock;
    private readonly Mock<IMapper> _mapMock;

    public UpdateUserTests()
    {
        _userMock = new Mock<IUserRepository<User>>();
        _mapMock = new Mock<IMapper>();
        _update = new UpdateUser(_userMock.Object, _mapMock.Object);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturn200OkStatus()
    {
        // Arrange
        var id = new Guid("98ded8da-0c7d-4a95-8acd-80360cd9ddd9");
        User user = new Fixture().Build<User>().Create();
        var updateCommand = new UpdateUserCommand
        {
            Id = id,
            FirstName = "FirstName",
            LastName = "LastName",
            Email = "Email"
        };
        
        _mapMock.Setup(s => s.ConfigurationProvider);

        _userMock.Setup(s => s.GetByIdAsync(It.Is<Guid>(x => x == id)))
            .ReturnsAsync(user);

        _userMock.Setup(s => s.UpdateAsync(It.Is<User>(x => x.Id == updateCommand.Id), CancellationToken.None))
            .ReturnsAsync(user);
        
        // Act
        var result = (OkObjectResult)await _update.HandleAsync(updateCommand);

        // Assert
        Assert.NotNull(result);
        result.StatusCode.Should().Be(200);
    }
    
    
    [Fact]
    public async Task UpdateAsync_ShouldReturn404NotFoundStatus()
    {
        // Arrange
        var updateCommand = new UpdateUserCommand();
        var user = new User();
        _mapMock.Setup(s => s.ConfigurationProvider);
        _userMock.Setup(s => s.UpdateAsync(user, CancellationToken.None))
            .ReturnsAsync(user);
        
        // Act
        var result = (NotFoundResult)await _update.HandleAsync(updateCommand, CancellationToken.None);
        
        // Assert
        Assert.NotNull(result);
        result.StatusCode.Should().Be(404);
    }
}