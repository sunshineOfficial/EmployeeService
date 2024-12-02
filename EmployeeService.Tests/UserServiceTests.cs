using EmployeeService.Common;
using EmployeeService.Entities;
using EmployeeService.Models.User;
using EmployeeService.Repositories.Interfaces;
using EmployeeService.Services;

namespace EmployeeService.Tests;

public class UserServiceTests
{
    [Theory, AutoMoqData]
    public async Task GetUser_ValidId_Success(
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        int id,
        DbUser dbUser,
        UserService userService)
    {
        // Arrange
        dbUser.Id = id;
        userRepositoryMock.Setup(x => x.GetUser(id)).ReturnsAsync(dbUser);

        // Act
        var user = await userService.GetUser(id);

        // Assert
        Assert.NotNull(user);
        Assert.Equal(id, user.Id);
        userRepositoryMock.Verify(x => x.GetUser(id), Times.Once);
    }

    [Theory, AutoMoqData]
    public async Task GetUser_InvalidId_ReturnsNull(
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        int id,
        UserService userService)
    {
        // Arrange
        userRepositoryMock.Setup(x => x.GetUser(id)).ReturnsAsync(() => null);

        // Act
        var user = await userService.GetUser(id);

        // Assert
        Assert.Null(user);
    }

    [Theory, AutoMoqData]
    public async Task UpdateUser_ValidUser_Success(
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        UserService userService)
    {
        // Arrange
        var request = new UpdateUserRequest
        {
            Id = 1,
            Username = "test3",
            Email = "test3@test.com",
            Name = "test3",
            Surname = "test3"
        };

        var user = new DbUser
        {
            Id = 1,
            Username = "test",
            Email = "test@test.com",
            Name = "test",
            Surname = "test"
        };

        userRepositoryMock.Setup(x => x.GetUser(request.Id)).ReturnsAsync(user);
        userRepositoryMock.Setup(x => x.GetUser(request.Username)).ReturnsAsync(() => null);
        userRepositoryMock.Setup(x => x.GetUser(request.Email)).ReturnsAsync(() => null);

        // Act
        await userService.UpdateUser(request);

        // Assert
        userRepositoryMock.Verify(x => x.UpdateUser(It.IsAny<DbUser>()), Times.Once);
    }

    [Theory, AutoMoqData]
    public async Task UpdateUser_InvalidId_DoesNotUpdate(
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        UserService userService)
    {
        // Arrange
        var request = new UpdateUserRequest
        {
            Id = 1,
            Username = "test3",
            Email = "test3@test.com",
            Name = "test3",
            Surname = "test3"
        };

        var user = new DbUser
        {
            Id = 1,
            Username = "test",
            Email = "test@test.com",
            Name = "test",
            Surname = "test"
        };

        var anotherUser = new DbUser
        {
            Id = 2,
            Username = "test2",
            Email = "test2@test.com",
            Name = "test2",
            Surname = "test2"
        };

        userRepositoryMock.Setup(x => x.GetUser(request.Id)).ReturnsAsync(() => null);
        userRepositoryMock.Setup(x => x.GetUser(anotherUser.Username)).ReturnsAsync(() => null);
        userRepositoryMock.Setup(x => x.GetUser(anotherUser.Email)).ReturnsAsync(() => null);

        // Act
        await userService.UpdateUser(request);

        // Assert
        userRepositoryMock.Verify(x => x.UpdateUser(It.IsAny<DbUser>()), Times.Never);
    }

    [Theory, AutoMoqData]
    public async Task UpdateUser_InvalidUsername_DoesNotUpdate(
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        UserService userService)
    {
        // Arrange
        var request = new UpdateUserRequest
        {
            Id = 1,
            Username = "test2",
            Email = "test3@test.com",
            Name = "test2",
            Surname = "test2"
        };

        var user = new DbUser
        {
            Id = 1,
            Username = "test",
            Email = "test@test.com",
            Name = "test",
            Surname = "test"
        };

        var anotherUser = new DbUser
        {
            Id = 2,
            Username = "test2",
            Email = "test2@test.com",
            Name = "test2",
            Surname = "test2"
        };

        userRepositoryMock.Setup(x => x.GetUser(request.Id)).ReturnsAsync(user);
        userRepositoryMock.Setup(x => x.GetUser(anotherUser.Username)).ReturnsAsync(anotherUser);
        userRepositoryMock.Setup(x => x.GetUser(anotherUser.Email)).ReturnsAsync(() => null);

        // Act
        await userService.UpdateUser(request);

        // Assert
        userRepositoryMock.Verify(x => x.UpdateUser(It.IsAny<DbUser>()), Times.Never);
    }

    [Theory, AutoMoqData]
    public async Task UpdateUser_InvalidEmail_DoesNotUpdate(
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        UserService userService)
    {
        // Arrange
        var request = new UpdateUserRequest
        {
            Id = 1,
            Username = "test3",
            Email = "test2@test.com",
            Name = "test2",
            Surname = "test2"
        };

        var user = new DbUser
        {
            Id = 1,
            Username = "test",
            Email = "test@test.com",
            Name = "test",
            Surname = "test"
        };

        var anotherUser = new DbUser
        {
            Id = 2,
            Username = "test2",
            Email = "test2@test.com",
            Name = "test2",
            Surname = "test2"
        };

        userRepositoryMock.Setup(x => x.GetUser(request.Id)).ReturnsAsync(user);
        userRepositoryMock.Setup(x => x.GetUser(anotherUser.Username)).ReturnsAsync(() => null);
        userRepositoryMock.Setup(x => x.GetUser(anotherUser.Email)).ReturnsAsync(anotherUser);

        // Act
        await userService.UpdateUser(request);

        // Assert
        userRepositoryMock.Verify(x => x.UpdateUser(It.IsAny<DbUser>()), Times.Never);
    }

    [Theory, AutoMoqData]
    public async Task DeleteUser_ValidId_Success(
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        int id,
        DbUser user,
        UserService userService)
    {
        // Arrange
        userRepositoryMock.Setup(x => x.GetUser(id)).ReturnsAsync(user);

        // Act
        await userService.DeleteUser(id);

        // Assert
        userRepositoryMock.Verify(x => x.DeleteUser(id), Times.Once);
    }

    [Theory, AutoMoqData]
    public async Task DeleteUser_InvalidId_DoesNotDelete(
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        int id,
        UserService userService)
    {
        // Arrange
        userRepositoryMock.Setup(x => x.GetUser(id)).ReturnsAsync(() => null);

        // Act
        await userService.DeleteUser(id);

        // Assert
        userRepositoryMock.Verify(x => x.DeleteUser(id), Times.Never);
    }

    [Theory, AutoMoqData]
    public async Task ChangePassword_ValidRequest_Success(
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        ChangePasswordRequest request,
        DbUser dbUser,
        UserService userService)
    {
        // Arrange
        dbUser.PasswordHash = Hash.GetHash(request.OldPassword);
        userRepositoryMock.Setup(x => x.GetUser(request.Login)).ReturnsAsync(dbUser);

        // Act
        await userService.ChangePassword(request);

        // Assert
        userRepositoryMock.Verify(x => x.ChangePassword(dbUser.Id, Hash.GetHash(request.NewPassword)), Times.Once);
    }

    [Theory, AutoMoqData]
    public async Task ChangePassword_InvalidRequest_DoesNotChangePassword(
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        ChangePasswordRequest request,
        DbUser dbUser,
        UserService userService)
    {
        // Arrange
        dbUser.PasswordHash = Hash.GetHash("test");
        request.OldPassword = Hash.GetHash("test2");
        userRepositoryMock.Setup(x => x.GetUser(request.Login)).ReturnsAsync(dbUser);

        // Act
        await userService.ChangePassword(request);

        // Assert
        userRepositoryMock.Verify(x => x.ChangePassword(dbUser.Id, Hash.GetHash(request.NewPassword)), Times.Never);
    }
}