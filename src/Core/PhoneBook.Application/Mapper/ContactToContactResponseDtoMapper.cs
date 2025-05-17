using PhoneBook.Application.DTO;
using PhoneBook.Domain.Entities;
using PhoneBook.Domain.Interfaces.Mapper;

namespace PhoneBook.Application.Mapper;

public class ContactToContactResponseDtoMapper : IMapper<Contact, ContactResponseDto>
{
    public ContactResponseDto Map(Contact source)
    {
        return new ContactResponseDto
        {
            Id = source.Id,
            Name = source.Name,
            MobilePhone = source.MobilePhone,
            TitleJob = source.TitleJob,
            BirthDate = source.BirthDate
        };
    }
}