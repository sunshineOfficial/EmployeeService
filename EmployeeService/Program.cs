using EmployeeService.Extensions;
using EmployeeService.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerWithAuth();
builder.Services.MigrateDatabase(builder.Configuration);
builder.Services.AddDapper();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddJwtAuth(builder.Configuration);

var app = builder.Build();

app.UseCors(cors =>
{
    cors.AllowAnyHeader();
    cors.AllowAnyMethod();
    cors.AllowAnyOrigin();
});
app.UseSwagger();
app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/employee/swagger.json", "EmployeeService API v1"));
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseAuthorization();
app.MapControllers();

app.Run();