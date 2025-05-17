namespace PhoneBook.Domain.Interfaces.Mapper;

public interface IMapper<in TSource, out TDestination>
{
    TDestination Map(TSource source);
}