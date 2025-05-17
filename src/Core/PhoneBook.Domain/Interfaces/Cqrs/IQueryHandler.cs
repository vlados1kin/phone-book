namespace PhoneBook.Domain.Interfaces.Cqrs;

public interface IQueryHandler<in TQuery, TResponse> where TQuery : IQuery<TResponse>
{
    Task<TResponse> ExecuteAsync(TQuery query, CancellationToken cancellationToken);
}