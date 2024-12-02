using EmployeeService.Models.Auth;
using EmployeeService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService, ITokenService tokenService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterModel registerModel)
    {
        var response = await authService.Register(registerModel);
        if (response == null)
        {
            return BadRequest();
        }

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginModel loginModel)
    {
        var response = await authService.Login(loginModel);
        if (response == null)
        {
            return BadRequest();
        }

        return Ok(response);
    }

    [HttpPut("refresh-token/{token}")]
    public async Task<IActionResult> RefreshToken(string token)
    {
        var response = await tokenService.RefreshToken(token);
        if (response == null)
        {
            return BadRequest();
        }

        return Ok(response);
    }
}