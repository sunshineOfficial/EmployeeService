using EmployeeService.Common;
using EmployeeService.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers;

[Authorize]
[ApiController]
public class BaseController : ControllerBase
{
    private string AuthHeader => HttpContext.Request.Headers.Authorization.ToString();

    protected int Id => int.Parse(Jwt.GetId(AuthHeader) ?? string.Empty);
    protected Role Role => Enum.Parse<Role>(Jwt.GetRole(AuthHeader) ?? string.Empty);
    protected string? Email => Jwt.GetEmail(AuthHeader);
    protected string? Username => Jwt.GetUsername(AuthHeader);
}