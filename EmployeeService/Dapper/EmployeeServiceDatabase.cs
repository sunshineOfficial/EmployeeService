using EmployeeService.Dapper.Interfaces;
using EmployeeService.Dapper.Models;

namespace EmployeeService.Dapper;

public class EmployeeServiceDatabase(IConfiguration configuration) : IDapperSettings
{
    public string ConnectionString => configuration["EmployeeServiceDatabase:ConnectionString"] ?? string.Empty;
    public Provider Provider => Enum.Parse<Provider>(configuration["EmployeeServiceDatabase:Provider"] ?? string.Empty);
}