using AutoFixture;
using ComputerClub.DAL.Entities;
using ComputerClub.Domain.Repositories.UserRepository;
using ComputerClub.WebAPI.Endpoints.UserAction.Update;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ComputerClub.Tests.UserEndpointsTests;

public class UpdateUserHandleTests
{
    private readonly UpdateUserHandle _update;
    private readonly Mock<IUserRepository<User>> _userMock;
    private readonly Mock<IMapper> _mapMock;

    public UpdateUserHandleTests()
    {
        _userMock = new Mock<IUserRepository<User>>();
        _mapMock = new Mock<IMapper>();
        _update = new UpdateUserHandle(_userMock.Object, _mapMock.Object);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturn200OkStatus()
    {
        // Arrange
        Guid id = new Guid("98ded8da-0c7d-4a95-8acd-80360cd9ddd9");
        User user = new Fixture().Build<User>().Create();
        UpdateUserRequest updateRequest = new UpdateUserRequest
        {
            Id = id,
            FirstName = "FirstName",
            LastName = "LastName",
            Email = "Email"
        };
        
        _mapMock.Setup(s => s.ConfigurationProvider);

        _userMock.Setup(s => s.GetByIdAsync(It.Is<Guid>(x => x == id)))
            .ReturnsAsync(user);

        _userMock.Setup(s => s.UpdateAsync(It.Is<User>(x => x.Id == updateRequest.Id), CancellationToken.None))
            .ReturnsAsync(user);
        
        // Act
        OkObjectResult result = (OkObjectResult)await _update.HandleAsync(updateRequest);

        // Assert
        Assert.NotNull(result);
        result.StatusCode.Should().Be(200);
    }
    
    
    [Fact]
    public async Task UpdateAsync_ShouldReturn404NotFoundStatus()
    {
        // Arrange
        UpdateUserRequest updateRequest = new UpdateUserRequest();
        User user = new User();
        _mapMock.Setup(s => s.ConfigurationProvider);
        _userMock.Setup(s => s.UpdateAsync(user, CancellationToken.None))
            .ReturnsAsync(user);
        
        // Act
        NotFoundResult result = (NotFoundResult)await _update.HandleAsync(updateRequest, CancellationToken.None);
        
        // Assert
        Assert.NotNull(result);
        result.StatusCode.Should().Be(404);
    }
}