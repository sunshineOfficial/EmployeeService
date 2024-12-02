namespace EmployeeService.Dapper.Interfaces;

public interface IQueryObject
{
    string Sql { get; }
    object? Params { get; }
    int CommandTimeout { get; }
}