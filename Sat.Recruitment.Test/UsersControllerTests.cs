namespace Sat.Recruitment.Test
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Sat.Recruitment.Api;
    using Sat.Recruitment.Api.Common;
    using Sat.Recruitment.Api.Controllers;
    using Sat.Recruitment.Api.Models;
    using Sat.Recruitment.Api.Models.ViewModels;
    using Sat.Recruitment.Api.Services;
    using Xunit;

    [CollectionDefinition("Users Controller Tests", DisableParallelization = true)]
    public class UsersControllerTests
    {
        private readonly Mock<IUserService> _usersService;
        private readonly UsersController _userController;
        private readonly UserCreateModel _emptyCreateModel;
        private readonly UserCreateModel _mikeCreateModel;
        private readonly Result<User> _mockResult;

        public UsersControllerTests()
        {
            _usersService = new Mock<IUserService>();
            _userController = new UsersController(_usersService.Object);
            _emptyCreateModel = new UserCreateModel();
            _mikeCreateModel = new UserCreateModel
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = UserType.Normal,
                Money = 124
            };
            _mockResult = new Result<User>();
        }

        [Fact]
        public void ShouldReturnOKObjectResultWhenSuccesfullRequet()
        {
            // Arrange
            Type expectedResult = typeof(OkObjectResult);
            _usersService
                .Setup(x => x.CreateUser(_mikeCreateModel))
                .Returns(Task.FromResult(_mockResult.Success(new User())));

            // Act
            ActionResult<Result> result = _userController.CreateUserAsync(_mikeCreateModel).Result;

            // Assert
            Assert.Equal(expectedResult, result.Result.GetType());
        }

        [Fact]
        public void ShouldReturnBadRequestObjectResultWhenDuplicatedUser()
        {
            // Arrange
            Type expectedResult = typeof(BadRequestObjectResult);
            _usersService
                .Setup(x => x.CreateUser(_mikeCreateModel))
                .Returns(Task.FromResult(_mockResult.BadRequest("User is duplicated")));

            // Act
            ActionResult<Result> result = _userController.CreateUserAsync(_mikeCreateModel).Result;

            // Assert
            Assert.Equal(expectedResult, result.Result.GetType());
        }

        [Fact]
        public void ShouldReturnBadRequestObjectResultWhenEmptyRequest()
        {
            // Arrange
            Type expectedResult = typeof(BadRequestObjectResult);
            _usersService
                .Setup(x => x.CreateUser(_emptyCreateModel))
                .Returns(Task.FromResult(_mockResult.BadRequest("")));

            // Act
            ActionResult<Result> result = _userController.CreateUserAsync(_emptyCreateModel).Result;

            // Assert
            Assert.Equal(expectedResult, result.Result.GetType());
        }
    }
}
