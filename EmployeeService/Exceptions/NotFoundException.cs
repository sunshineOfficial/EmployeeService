namespace EmployeeService.Exceptions;

public abstract class NotFoundException(string message) : Exception(message);