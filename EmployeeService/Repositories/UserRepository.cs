using EmployeeService.Dapper.Interfaces;
using EmployeeService.Dapper.Models;
using EmployeeService.Entities;
using EmployeeService.Repositories.Interfaces;
using EmployeeService.Repositories.Scripts.User;

namespace EmployeeService.Repositories;

public class UserRepository(IDapperContext<IDapperSettings> dapperContext) : IUserRepository
{
    public ITransaction BeginTransaction()
    {
        return dapperContext.BeginTransaction();
    }

    public async Task<int> CreateUser(DbUser user)
    {
        return await dapperContext.CommandWithResponse<int>(new QueryObject(User.Create, user));
    }

    public async Task<DbUser?> GetUser(int id)
    {
        return await dapperContext.FirstOrDefault<DbUser>(new QueryObject(User.GetById, new { id }));
    }

    public async Task<DbUser?> GetUser(string login)
    {
        return await dapperContext.FirstOrDefault<DbUser>(new QueryObject(User.GetByLogin, new { login }));
    }

    public async Task<DbUser?> GetUserByRefreshToken(string refreshToken)
    {
        return await dapperContext.FirstOrDefault<DbUser>(new QueryObject(User.GetByRefreshToken, new { refreshToken }));
    }

    public async Task<List<DbUser>> GetUsers()
    {
        return await dapperContext.ListOrEmpty<DbUser>(new QueryObject(User.GetAll));
    }

    public async Task UpdateRefreshToken(int id, string refreshToken, DateTime refreshTokenExpiredAfter)
    {
        await dapperContext.Command(new QueryObject(User.UpdateRefreshToken, new { id, refreshToken, refreshTokenExpiredAfter }));
    }

    public async Task UpdateUser(DbUser user)
    {
        await dapperContext.Command(new QueryObject(User.Update, user));
    }

    public async Task DeleteUser(int id)
    {
        await dapperContext.Command(new QueryObject(User.Delete, new { id }));
    }

    public async Task ChangePassword(int id, string passwordHash)
    {
        await dapperContext.Command(new QueryObject(User.ChangePassword, new { id, passwordHash }));
    }
}