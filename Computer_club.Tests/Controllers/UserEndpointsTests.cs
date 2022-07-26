// using AutoMapper;
// using Computer_club.Data.Entities.User;
// using Computer_club.Services.UserServices.UserRepository;
// using Computer_club.WebAPI.Endpoints.RoleAction.Create;
// using Moq;
//
// namespace Computer_club.Tests.Controllers;
//
// public class UserEndpointsTests
// {
//     private readonly Mock<IUserRepository<User>> _mockRepository;
//     private readonly Mock<IMapper> _mockMapper;
//     private readonly Create _create;
//
//     public UserEndpointsTests()
//     {
//         _mockRepository = new Mock<IUserRepository<User>>();
//         _create = new Create(_mockRepository.Object, _mockMapper.Object);
//     }
//
//     [Fact]
//     public async Task Create_ActionExecutes_ReturnsOkForCreate()
//     {
//         
//     }
// }