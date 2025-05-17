using PhoneBook.Domain.Entities;

namespace PhoneBook.Domain.Interfaces;

public interface IContactRepository : IBaseRepository<Contact>
{
    Task<IEnumerable<Contact>> GetAllContactsAsync(bool trackChanges, CancellationToken cancellationToken);
    Task<Contact?> GetContactByIdAsync(Guid id, bool trackChanges, CancellationToken cancellationToken);
}