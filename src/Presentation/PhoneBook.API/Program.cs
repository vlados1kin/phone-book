using Microsoft.EntityFrameworkCore;
using PhoneBook.API.Middlewares;
using PhoneBook.Application.Services;
using PhoneBook.Persistence;
using PhoneBook.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureRepositoryContext(builder.Configuration);
builder.Services.ConfigureRepositories();
builder.Services.ConfigureMapper();
builder.Services.ConfigureQueries();
builder.Services.AddControllers();
builder.Services.AddTransient<ExceptionHandler>();

var app = builder.Build();

app.UseMiddleware<ExceptionHandler>();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<RepositoryContext>();
    context.Database.Migrate();
}

app.MapControllers();

app.Run();
