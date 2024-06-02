using AutoFixture;
using ComputerClub.DAL.Entities;
using ComputerClub.Domain.Options;
using ComputerClub.Domain.Repositories.UserRepository;
using ComputerClub.WebAPI.Endpoints.UserAction.GetAll;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ComputerClub.Tests.UserEndpointsTests;

public class GetAllUserHandleTests
{
    private readonly GetAllUserHandle _all;
    private readonly Mock<IUserRepository<User>> _userMock;
    private readonly Mock<IMapper> _mapMock;

    public GetAllUserHandleTests()
    {
        _userMock = new Mock<IUserRepository<User>>();
        _mapMock = new Mock<IMapper>();
        _all = new GetAllUserHandle(_userMock.Object, _mapMock.Object);
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
        OkObjectResult result = (OkObjectResult)await _all.HandleAsync(command, CancellationToken.None);
        
        // Assert
        Assert.NotNull(result);
        result.StatusCode.Should().Be(200);
    }
}