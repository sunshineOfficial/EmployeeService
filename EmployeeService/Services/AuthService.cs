using System.Security.Claims;
using EmployeeService.Common;
using EmployeeService.Entities;
using EmployeeService.Models.Auth;
using EmployeeService.Models.Auth.Interfaces;
using EmployeeService.Models.User;
using EmployeeService.Repositories.Interfaces;
using EmployeeService.Services.Interfaces;

namespace EmployeeService.Services;

public class AuthService(IUserRepository userRepository, ITokenService tokenService, IAuthSettings authSettings) : IAuthService
{
    public async Task<AuthResponse?> Register(RegisterModel registerModel)
    {
        var user = await userRepository.GetUser(registerModel.Username) ?? await userRepository.GetUser(registerModel.Email);
        if (user != null)
        {
            return null;
        }

        var refreshToken = tokenService.CreateToken(new List<Claim>());
        var id = await userRepository.CreateUser(new DbUser
        {
            Role = (int)Role.User,
            Username = registerModel.Username,
            Email = registerModel.Email,
            Name = registerModel.Name,
            Surname = registerModel.Surname,
            PasswordHash = Hash.GetHash(registerModel.Password),
            RefreshToken = refreshToken,
            RefreshTokenExpiredAfter = DateTime.UtcNow.AddHours(authSettings.TokenExpiresAfterHours)
        });

        var claims = Jwt.GetClaims(id, (int)Role.User, registerModel.Email, registerModel.Username);
        var accessToken = tokenService.CreateToken(claims, 24);

        return new AuthResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };
    }

    public async Task<AuthResponse?> Login(LoginModel loginModel)
    {
        var user = await userRepository.GetUser(loginModel.Login);
        if (user == null || user.PasswordHash != Hash.GetHash(loginModel.Password))
        {
            return null;
        }

        var claims = Jwt.GetClaims(user.Id, user.Role, user.Email, user.Username);
        var accessToken = tokenService.CreateToken(claims, 24);

        return new AuthResponse
        {
            AccessToken = accessToken,
            RefreshToken = user.RefreshToken
        };
    }
}