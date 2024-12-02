using System.Text.Json.Serialization;

namespace EmployeeService.Models.User;

public class ChangePasswordRequest
{
    public string OldPassword { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
    [JsonIgnore] public string Login { get; set; } = string.Empty;
}