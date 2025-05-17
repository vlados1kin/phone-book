using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Domain.Entities;

namespace PhoneBook.Persistence.Configurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(contact => contact.Id);

        builder.Property(contact => contact.Name).IsRequired();

        builder.Property(contact => contact.MobilePhone).IsRequired();

        builder.Property(contact => contact.BirthDate).IsRequired();

        builder.HasData(new List<Contact>
        {
            new()
            {
                Id = new Guid("c16487f1-6d0a-4ce1-bffa-13755b63cf60"),
                Name = "Vladislav",
                MobilePhone = "+375 (29) 123-45-67",
                BirthDate = new DateOnly(2004, 09, 26),
                TitleJob = ".NET Developer"
            },
            new()
            {
                Id = new Guid("c86d2102-0a92-4039-be3f-230d15768498"),
                Name = "Test",
                MobilePhone = "+1 (111) 111-11-11",
                BirthDate = new DateOnly(2020, 01, 01),
                TitleJob = "Test"
            }
        });
    }
}