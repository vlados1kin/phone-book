namespace PhoneBook.Domain.Interfaces;

public interface IUnitOfWork
{
    IContactRepository Contact { get; }
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}