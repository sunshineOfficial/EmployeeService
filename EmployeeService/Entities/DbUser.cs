namespace EmployeeService.Entities;

public class DbUser
{
    public int Id { get; set; }
    public int Role { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string PasswordHash { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime RefreshTokenExpiredAfter { get; set; }
}