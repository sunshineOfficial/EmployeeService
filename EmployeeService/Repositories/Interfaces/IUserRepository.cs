using EmployeeService.Dapper.Interfaces;
using EmployeeService.Entities;

namespace EmployeeService.Repositories.Interfaces;

public interface IUserRepository
{
    ITransaction BeginTransaction();
    Task<int> CreateUser(DbUser user);
    Task<DbUser?> GetUser(int id);
    Task<DbUser?> GetUser(string login);
    Task<DbUser?> GetUserByRefreshToken(string refreshToken);
    Task<List<DbUser>> GetUsers();
    Task UpdateRefreshToken(int id, string refreshToken, DateTime refreshTokenExpiredAfter);
    Task UpdateUser(DbUser user);
    Task DeleteUser(int id);
    Task ChangePassword(int id, string passwordHash);
}