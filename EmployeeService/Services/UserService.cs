using EmployeeService.Common;
using EmployeeService.Mappers;
using EmployeeService.Models.User;
using EmployeeService.Repositories.Interfaces;
using EmployeeService.Services.Interfaces;

namespace EmployeeService.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<User?> GetUser(int id)
    {
        var user = await userRepository.GetUser(id);

        return user?.MapToDomain();
    }

    public async Task<List<User>> GetUsers()
    {
        var users = await userRepository.GetUsers();

        return users.MapToDomain();
    }

    public async Task UpdateUser(UpdateUserRequest request)
    {
        var user = await userRepository.GetUser(request.Id);
        if (user == null)
        {
            return;
        }

        if (!string.IsNullOrEmpty(request.Username) && request.Username != user.Username)
        {
            var anotherUser = await userRepository.GetUser(request.Username);
            if (anotherUser != null)
            {
                return;
            }
        }

        if (!string.IsNullOrEmpty(request.Email) && request.Email != user.Email)
        {
            var anotherUser = await userRepository.GetUser(request.Email);
            if (anotherUser != null)
            {
                return;
            }
        }

        await userRepository.UpdateUser(request.MapToDb());
    }

    public async Task DeleteUser(int id)
    {
        var user = await userRepository.GetUser(id);
        if (user == null)
        {
            return;
        }

        await userRepository.DeleteUser(id);
    }

    public async Task ChangePassword(ChangePasswordRequest request)
    {
        var user = await userRepository.GetUser(request.Login);
        if (user == null || user.PasswordHash != Hash.GetHash(request.OldPassword))
        {
            return;
        }

        await userRepository.ChangePassword(user.Id, Hash.GetHash(request.NewPassword));
    }
}