using PhoneBook.Application.DTO;
using PhoneBook.Domain.Entities;
using PhoneBook.Domain.Interfaces.Mapper;

namespace PhoneBook.Application.Mapper;

public class ContactRequestDtoToContactMapper : IMapper<ContactRequestDto, Contact>
{
    public Contact Map(ContactRequestDto source)
    {
        return new Contact
        {
            Name = source.Name,
            MobilePhone = source.MobilePhone,
            TitleJob = source.TitleJob,
            BirthDate = source.BirthDate
        };
    }
}