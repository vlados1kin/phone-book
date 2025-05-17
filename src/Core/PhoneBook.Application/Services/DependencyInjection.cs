using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Application.Commands;
using PhoneBook.Application.DTO;
using PhoneBook.Application.Mapper;
using PhoneBook.Application.Queries;
using PhoneBook.Domain.Interfaces.Cqrs;

namespace PhoneBook.Application.Services;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureMapper(this IServiceCollection services)
    {
        services.AddSingleton<MapperRegistry>(_ =>
        {
            var mapper = new MapperRegistry();
            mapper.Registry(new ContactToContactResponseDtoMapper());
            mapper.Registry(new ContactRequestDtoToContactMapper());
            return mapper;
        });

        return services;
    }

    public static IServiceCollection ConfigureQueries(this IServiceCollection services)
    {
        services.AddScoped<IQueryHandler<GetAllContactsQuery, IEnumerable<ContactResponseDto>>, GetAllContactsQueryHandler>();
        services.AddScoped<IQueryHandler<GetContactByIdQuery, ContactResponseDto>, GetContactByIdQueryHandler>();
        services.AddScoped<ICommandHandler<CreateContactCommand, ContactResponseDto>, CreateContactCommandHandler>();
        services.AddScoped<ICommandHandler<UpdateContactCommand>, UpdateContactCommandHandler>();
        services.AddScoped<ICommandHandler<DeleteContactCommand>, DeleteContactCommandHandler>();

        return services;
    }
}