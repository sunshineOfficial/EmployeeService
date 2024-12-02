using EmployeeService.Models.Auth;

namespace EmployeeService.Services.Interfaces;

public interface IAuthService
{
    Task<AuthResponse?> Register(RegisterModel registerModel);
    Task<AuthResponse?> Login(LoginModel loginModel);
}