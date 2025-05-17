using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.Entities;
using PhoneBook.Domain.Interfaces;

namespace PhoneBook.Persistence.Repositories;

public class ContactRepository : BaseRepository<Contact>, IContactRepository
{
    private readonly RepositoryContext _context;
    
    public ContactRepository(RepositoryContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Contact>> GetAllContactsAsync(bool trackChanges, CancellationToken cancellationToken)
    {
        return await FindAll(trackChanges).ToListAsync(cancellationToken);
    }

    public async Task<Contact?> GetContactByIdAsync(Guid id, bool trackChanges, CancellationToken cancellationToken)
    {
        return await FindByCondition(contact => contact.Id == id, trackChanges).SingleOrDefaultAsync(cancellationToken);
    }
}