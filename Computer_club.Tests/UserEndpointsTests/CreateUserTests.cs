﻿using AutoMapper;
using Computer_club.Data.Entities;
using Computer_club.Domain.Repositories.UserRepository;
using Computer_club.WebAPI.Endpoints.UserAction.Create;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Computer_club.Tests.UserEndpointsTests;

public class CreateUserTests
{
    private readonly CreateUser _create;
    private readonly Mock<IUserRepository<User>> _userMock;
    private readonly Mock<IMapper> _mapMock;

    public CreateUserTests()
    {
        _userMock = new Mock<IUserRepository<User>>();
        _mapMock = new Mock<IMapper>();
        _create = new CreateUser(_userMock.Object, _mapMock.Object);
    }
    
    [Fact]
    public async Task CreateUserAsync_ShouldReturn200OkStatus()
    {
        // Arrange
        string email = "email@mail.emaile";
        var command = new CreateUserCommand { Email = email };
        var user = new User
        {
            Email = email,
            FirstName = "FirstName",
            LastName = "LastName"
        };
        
        _mapMock.Setup(s => s.ConfigurationProvider);
        _userMock.Setup(s => s.AddAsync(It.Is<User>(x => x.Email == email), CancellationToken.None))
            .ReturnsAsync(user);
        
        // Act
        var result = (OkObjectResult)await _create.HandleAsync(command, CancellationToken.None);
        
        // Assert
        Assert.NotNull(result);
        result.StatusCode.Should().Be(200);
    }
}