using EmployeeService.Models.User;

namespace EmployeeService.Services.Interfaces;

public interface IUserService
{
    Task<User?> GetUser(int id);
    Task<List<User>> GetUsers();
    Task UpdateUser(UpdateUserRequest request);
    Task DeleteUser(int id);
    Task ChangePassword(ChangePasswordRequest request);
}