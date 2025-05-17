using PhoneBook.Domain.Interfaces.Mapper;

namespace PhoneBook.Application.Mapper;

public class MapperRegistry
{
    private readonly Dictionary<(Type, Type), object> Mappers = new();

    public void Registry<TSource, TDestination>(IMapper<TSource, TDestination> mapper)
    {
        Mappers[(typeof(TSource), typeof(TDestination))] = mapper;
    }

    public TDestination Map<TSource, TDestination>(TSource source)
    {
        if (Mappers.TryGetValue((typeof(TSource), typeof(TDestination)), out var mapper))
        {
            return ((IMapper<TSource, TDestination>)mapper).Map(source);
        }

        throw new InvalidOperationException($"Mapper<{nameof(TSource)}, {nameof(TDestination)}> not registered");
    }
}