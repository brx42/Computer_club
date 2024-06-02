using ComputerClub.DAL.Entities;
using ComputerClub.Domain.Repositories.UserRepository;
using ComputerClub.WebAPI.Endpoints.UserAction.Create;
using FastEndpoints;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ComputerClub.Tests.UserEndpointsTests;

public class CreateUserHandleTests
{
    private readonly CreateUserHandle _create;
    private readonly Mock<IUserRepository<User>> _userMock;
    private readonly Mock<IMapper> _mapMock;

    public CreateUserHandleTests()
    {
        _userMock = new Mock<IUserRepository<User>>();
        _mapMock = new Mock<IMapper>();
        _create = new CreateUserHandle(_userMock.Object, _mapMock.Object);
    }
    
    [Fact]
    public async Task CreateUserAsync_ShouldReturn200OkStatus()
    {
        // Arrange
        string email = "email@mail.emaile";
        CreateUserRequest request = new CreateUserRequest { Email = email };
        User user = new User
        {
            Email = email,
            FirstName = "FirstName",
            LastName = "LastName"
        };
        
        _mapMock.Setup(s => s.ConfigurationProvider);
        _userMock.Setup(s => s.AddAsync(It.Is<User>(x => x.Email == email), CancellationToken.None))
            .ReturnsAsync(user);
        
        // Act
        OkObjectResult result = (OkObjectResult)await _create.HandleAsync(request, CancellationToken.None);
        
        // Assert
        Assert.NotNull(result);
        result.StatusCode.Should().Be(200);
    }
}