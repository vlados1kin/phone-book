using PhoneBook.Domain.Interfaces;

namespace PhoneBook.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly RepositoryContext _context;
    private readonly Lazy<IContactRepository> _contactRepository;

    public UnitOfWork(RepositoryContext context)
    {
        _context = context;
        _contactRepository = new Lazy<IContactRepository>(() => new ContactRepository(context));
    }

    public IContactRepository Contact => _contactRepository.Value;
    
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}