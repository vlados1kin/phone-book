using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.Entities;
using PhoneBook.Domain.Interfaces;

namespace PhoneBook.Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly RepositoryContext _context;

    public BaseRepository(RepositoryContext context)
    {
        _context = context;
    }
    
    public async Task<T?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().FindAsync([id], cancellationToken);
    }

    public IQueryable<T> FindAll(bool trackChanges)
    {
        return trackChanges ? _context.Set<T>() : _context.Set<T>().AsTracking();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool trackChanges)
    {
        return trackChanges ? _context.Set<T>().Where(condition) : _context.Set<T>().Where(condition).AsTracking();
    }

    public async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _context.Set<T>().AddAsync(entity, cancellationToken);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
}