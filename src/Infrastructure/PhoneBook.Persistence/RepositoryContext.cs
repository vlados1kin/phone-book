using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.Entities;

namespace PhoneBook.Persistence;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    {
    }
    
    public DbSet<Contact> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}