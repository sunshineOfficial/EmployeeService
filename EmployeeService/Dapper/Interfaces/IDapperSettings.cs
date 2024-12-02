using EmployeeService.Dapper.Models;

namespace EmployeeService.Dapper.Interfaces;

public interface IDapperSettings
{
    string ConnectionString { get; }
    Provider Provider { get; }
}