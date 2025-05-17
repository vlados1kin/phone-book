using System.Linq.Expressions;
using PhoneBook.Domain.Entities;

namespace PhoneBook.Domain.Interfaces;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
    IQueryable<T> FindAll(bool trackChanges);
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool trackChanges);
    Task CreateAsync(T entity, CancellationToken cancellationToken = default);
    void Update(T entity);
    void Delete(T entity);
}