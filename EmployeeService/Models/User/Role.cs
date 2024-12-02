using System.Text.Json.Serialization;

namespace EmployeeService.Models.User;

[Flags]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Role
{
    None = 0,
    User = 1,
    Admin = 2,
    All = User | Admin
}