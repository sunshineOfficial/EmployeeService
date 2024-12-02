using System.Security.Claims;
using EmployeeService.Models.Auth;

namespace EmployeeService.Services.Interfaces;

public interface ITokenService
{
    string CreateToken(IEnumerable<Claim> claims, int tokenExpiresAfterHours = 0);
    Task<AuthResponse?> RefreshToken(string refreshToken);
}