using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Domain.Interfaces;
using PhoneBook.Persistence.Repositories;

namespace PhoneBook.Persistence.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureRepositoryContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RepositoryContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("Database");
            options.UseNpgsql(connectionString, migration => migration.MigrationsAssembly("PhoneBook.Persistence"));
        });

        return services;
    }
    
    public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}